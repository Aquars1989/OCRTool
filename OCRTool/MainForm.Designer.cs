namespace OCRTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtThresh = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.btnPreView = new System.Windows.Forms.ToolStripButton();
            this.btnCC = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Black;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtThresh,
            this.toolStripLabel2,
            this.cboLanguage,
            this.btnPreView,
            this.btnCC,
            this.btnSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(533, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Thresh";
            // 
            // txtThresh
            // 
            this.txtThresh.Name = "txtThresh";
            this.txtThresh.Size = new System.Drawing.Size(100, 25);
            this.txtThresh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThresh_KeyDown);
            this.txtThresh.Validating += new System.ComponentModel.CancelEventHandler(this.txtThresh_Validating);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel2.Text = "Language";
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(121, 25);
            // 
            // btnPreView
            // 
            this.btnPreView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPreView.BackColor = System.Drawing.Color.LightGray;
            this.btnPreView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreView.Image = ((System.Drawing.Image)(resources.GetObject("btnPreView.Image")));
            this.btnPreView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(23, 22);
            this.btnPreView.Text = "Show/Hide PreView";
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // btnCC
            // 
            this.btnCC.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCC.BackColor = System.Drawing.Color.LightGray;
            this.btnCC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCC.Image = ((System.Drawing.Image)(resources.GetObject("btnCC.Image")));
            this.btnCC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(23, 22);
            this.btnCC.Text = "Start/Stop CC";
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSelect.BackColor = System.Drawing.Color.LightGray;
            this.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(23, 22);
            this.btnSelect.Text = "Select Rect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picPreview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtResult);
            this.splitContainer1.Size = new System.Drawing.Size(533, 271);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 1;
            // 
            // picPreview
            // 
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(533, 89);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.Gainsboro;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(533, 178);
            this.txtResult.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 296);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "OCR Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtThresh;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cboLanguage;
        private ToolStripButton btnPreView;
        private ToolStripButton btnCC;
        private ToolStripButton btnSelect;
        private PictureBox picPreview;
        private TextBox txtResult;
    }
}