using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCRTool
{
    public partial class SelectionForm : Form
    {
        public event EventHandler Selected;
        public event EventHandler Cancel;

        /// <summary>
        /// origin point when draging
        /// </summary>
        private Point _Archor = Point.Empty;

        /// <summary>
        /// selected rectangle when draging
        /// </summary>
        private Rectangle _SelectedRect = Rectangle.Empty;

        protected void OnSelected()
        {
            if (Selected != null)
            {
                Selected(this, new EventArgs());
            }
        }

        protected void OnCancel()
        {
            if (Cancel != null)
            {
                Cancel(this, new EventArgs());
            }
        }

        private SelectionState _SelectionState = SelectionForm.SelectionState.NotSelect;
        public SelectionState State
        {
            get { return _SelectionState; }
            set
            {
                _SelectionState = value;
                switch (value)
                {
                    case SelectionForm.SelectionState.NotSelect:
                        WindowState = FormWindowState.Maximized;
                        break;
                    case SelectionForm.SelectionState.Selecting:
                        break;
                    case SelectionForm.SelectionState.Selected:
                        WindowState = FormWindowState.Normal;
                        Location = _SelectedRect.Location;
                        Size = _SelectedRect.Size;
                        OnSelected();
                        break;
                }
                this.Invalidate();
            }
        }

        public SelectionForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            State = SelectionState.NotSelect;
        }

        private void SelectionForm_MouseDown(object sender, MouseEventArgs e)
        {
            _Archor = e.Location;
            State = SelectionState.Selecting;
        }

        private void SelectionForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (State == SelectionState.Selecting)
            {
                int left, top, height, width;
                Point pot = e.Location;
                if (pot.X >= _Archor.X)
                {
                    left = _Archor.X;
                    width = pot.X - _Archor.X;
                }
                else
                {
                    left = pot.X;
                    width = _Archor.X - pot.X;
                }

                if (pot.Y >= _Archor.Y)
                {
                    top = _Archor.Y;
                    height = pot.Y - _Archor.Y;
                }
                else
                {
                    top = pot.Y;
                    height = _Archor.Y - pot.Y;
                }
                _SelectedRect = new Rectangle(left, top, width, height);
                Invalidate();
            }
        }

        private void SelectionForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (State == SelectionState.Selecting)
            {
                State = SelectionState.Selected;
            }
        }

        private void SelectionForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && State != SelectionState.Selected)
            {
                OnCancel();
            }
        }

        private void SelectionForm_Paint(object sender, PaintEventArgs e)
        {
            switch (State)
            {
                case SelectionForm.SelectionState.NotSelect:
                    break;
                case SelectionForm.SelectionState.Selecting:
                    using (Pen penBorder = new Pen(Color.Red, 2) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                    {
                        e.Graphics.FillRectangle(Brushes.Lime, _SelectedRect);
                        e.Graphics.DrawRectangle(penBorder, _SelectedRect);
                    }
                    break;
                case SelectionForm.SelectionState.Selected:
                    e.Graphics.Clear(Color.Lime);
                    using (Pen penBorder = new Pen(Color.Red, 2) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                    {
                        e.Graphics.DrawRectangle(penBorder, ClientRectangle);
                    }
                    break;
            }
        }

        public enum SelectionState
        {
            NotSelect,
            Selecting,
            Selected
        }
    }
}
