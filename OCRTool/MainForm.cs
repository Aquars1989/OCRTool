namespace OCRTool
{
    public partial class MainForm : Form
    {
        private bool _Selection = false;
        private SelectionForm _SelectionForm = null;
        private System.Timers.Timer _TimerSacn = new System.Timers.Timer() { Interval = 500 };

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
        private StreamWriter _CCOutput = null;
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
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPreView_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Selection = !Selection;
        }

        private void btnCC_Click(object sender, EventArgs e)
        {

        }
    }
}