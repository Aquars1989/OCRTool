using System.Threading;
using System;
using OpenCvSharp;
using Tesseract;

namespace OCRTool
{
    public partial class MainForm : Form
    {
        private bool _Selection = false;
        private SelectionForm? _SelectionForm = null;
        private System.Windows.Forms.Timer _TimerSacn = new System.Windows.Forms.Timer() { Interval = 500 };
        private const string TessdataPath = "tessdata";
        private int _Thresh = 200;

        public bool Selection
        {
            get { return _Selection; }
            set
            {
                _Selection = value;
                if (_Selection)
                {
                    if (_SelectionForm == null)
                    {
                        _SelectionForm = new SelectionForm();
                        _SelectionForm.Selected += (s, e) =>
                        {
                            this.Activate();
                            _TimerSacn.Enabled = true;
                        };
                        _SelectionForm.Cancel += (s, e) =>
                        {
                            Selection = false;
                        };
                    }
                    _SelectionForm.State = SelectionForm.SelectionState.NotSelect;
                    _SelectionForm.Show();
                    btnSelect.BackColor = Color.Yellow;
                }
                else
                {
                    if (_SelectionForm != null)
                    {
                        _SelectionForm.Close();
                        _SelectionForm = null;
                    }
                    btnSelect.BackColor = Color.LightGray;
                    CC = false;
                }
            }
        }

        private bool _Preview = false;
        public bool Preview
        {
            get { return _Preview; }
            set
            {
                _Preview = value;
                if (_Preview)
                {
                    splitContainer1.Panel1Collapsed = false;
                    btnPreView.BackColor = Color.Yellow;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    btnPreView.BackColor = Color.LightGray;
                }
            }
        }

        private DateTime _CCStart = DateTime.Now;
        private StreamWriter? _CCOutput = null;
        private bool _CC = false;
        public bool CC
        {
            get { return _CC; }
            set
            {
                _CC = Selection & value;
                if (_CC)
                {
                    if (_CCOutput != null)
                    {
                        _CCOutput.Dispose();
                        _CCOutput = null;
                    }
                    _CCOutput = File.AppendText($"CC_{DateTime.Now:yyyyMMddHHmmss}.txt");
                    _CCStart = DateTime.Now;
                    txtResult.Text = "";
                    btnCC.BackColor = Color.Yellow;
                    _TimerSacn.Interval = 200;
                }
                else
                {
                    if (_CCOutput != null)
                    {
                        _CCOutput.Dispose();
                        _CCOutput = null;
                    }
                    btnCC.BackColor = Color.LightGray;
                    _TimerSacn.Interval = 500;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            _TimerSacn.Tick += _TimerSacn_Tick;
        }


        private void btnPreView_Click(object sender, EventArgs e)
        {
            Preview = !Preview;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Selection = !Selection;
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            CC = !CC;
        }

        private void _TimerSacn_Tick(object? sender, EventArgs e)
        {
            if (_SelectionForm == null || _SelectionForm.State != SelectionForm.SelectionState.Selected)
            {
                _TimerSacn.Enabled = false;
                return;
            }

            Bitmap image = new Bitmap(_SelectionForm.Size.Width, _SelectionForm.Size.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(_SelectionForm.Location, new System.Drawing.Point(0, 0), _SelectionForm.Size);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                Mat simg = Mat.FromStream(ms, ImreadModes.Grayscale);
                Mat ThresholdImg = simg.Threshold(_Thresh, 255, ThresholdTypes.Binary);

                using (MemoryStream ms2 = ThresholdImg.ToMemoryStream())
                {
                    Bitmap img = new Bitmap(ms2);
                    picPreview.Image = img;
                    string result = ImageToText(ms2);
                    if (CC && txtResult.Text != result && !string.IsNullOrWhiteSpace(result))
                    {
                        TimeSpan span = DateTime.Now - _CCStart;
                        _CCOutput?.WriteLine($"{span.Hours:00}:{span.Minutes:00}:{span.Seconds:00}.{span.Milliseconds:000} - {result.Replace("\n", " ").Trim()}");
                    }
                    txtResult.Text = result;
                    ms2.Close();
                }
                image.Dispose();
                ms.Close();
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            Preview = true;

            if (!Directory.Exists(TessdataPath))
            {
                MessageBox.Show("Tessdata directory not exists.");
                Close();
                return;
            }

            string[] files = Directory.GetFiles(TessdataPath, "*.traineddata");
            if (files.Length == 0)
            {
                MessageBox.Show("Tessdata not exists.");
                Close();
                return;
            }

            foreach (string file in files)
            {
                cboLanguage.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            cboLanguage.Text = "eng";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.S)
                {
                    btnSelect.PerformClick();
                }
                else if (e.KeyCode == Keys.X)
                {
                    btnPreView.PerformClick();
                }
                else if (e.KeyCode == Keys.C)
                {
                    btnCC.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Escape && Selection)
            {
                Selection = false;
            }
        }

        private void txtThresh_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (int.TryParse(txtThresh.Text, out int n))
            {
                _Thresh = n;
            }
            else
            {
                MessageBox.Show("Thresh must be a number.");
                txtThresh.Text = _Thresh.ToString();
            }
        }

        private void txtThresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtThresh.Text = _Thresh.ToString();
            }
        }

        public string ImageToText(MemoryStream stream)
        {
            if (string.IsNullOrWhiteSpace(cboLanguage.Text)) return "";
            using (var engine = new TesseractEngine(TessdataPath, cboLanguage.Text, EngineMode.Default))
            {
                using (var img = Pix.LoadFromMemory(stream.ToArray()))
                using (var page = engine.Process(img))
                {
                    return page.GetText();
                }
            }
        }

        ~MainForm()
        {
            if (_CCOutput != null)
            {
                _CCOutput.Dispose();
                _CCOutput = null;
            }
        }

        
    }
}