namespace CoolBoy.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbLog = new System.Windows.Forms.ListBox();
            this.cmsLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmClearBox = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPref = new System.Windows.Forms.Button();
            this.cmsApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLog.SuspendLayout();
            this.cmsApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.ContextMenuStrip = this.cmsLog;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 12);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(401, 290);
            this.lbLog.TabIndex = 0;
            this.lbLog.TabStop = false;
            // 
            // cmsLog
            // 
            this.cmsLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClearBox,
            this.tsmClearFile});
            this.cmsLog.Name = "cmsLog";
            this.cmsLog.Size = new System.Drawing.Size(258, 48);
            // 
            // tsmClearBox
            // 
            this.tsmClearBox.Name = "tsmClearBox";
            this.tsmClearBox.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.tsmClearBox.Size = new System.Drawing.Size(257, 22);
            this.tsmClearBox.Text = "Clear log &window";
            this.tsmClearBox.Click += new System.EventHandler(this.tsmClearBox_Click);
            // 
            // tsmClearFile
            // 
            this.tsmClearFile.Name = "tsmClearFile";
            this.tsmClearFile.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.tsmClearFile.Size = new System.Drawing.Size(257, 22);
            this.tsmClearFile.Text = "Clear log &file";
            this.tsmClearFile.Click += new System.EventHandler(this.tsmClearFile_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(65, 316);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(282, 316);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPref
            // 
            this.btnPref.Location = new System.Drawing.Point(174, 316);
            this.btnPref.Name = "btnPref";
            this.btnPref.Size = new System.Drawing.Size(75, 23);
            this.btnPref.TabIndex = 2;
            this.btnPref.Text = "Preferences";
            this.btnPref.UseVisualStyleBackColor = true;
            this.btnPref.Click += new System.EventHandler(this.btnPref_Click);
            // 
            // cmsApplication
            // 
            this.cmsApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout});
            this.cmsApplication.Name = "cmsApplication";
            this.cmsApplication.Size = new System.Drawing.Size(133, 26);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.tsmAbout.Size = new System.Drawing.Size(132, 22);
            this.tsmAbout.Text = "&About";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 351);
            this.ContextMenuStrip = this.cmsApplication;
            this.Controls.Add(this.btnPref);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "CoolBoy Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.cmsLog.ResumeLayout(false);
            this.cmsApplication.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.ContextMenuStrip cmsLog;
        private System.Windows.Forms.ToolStripMenuItem tsmClearBox;
        private System.Windows.Forms.ToolStripMenuItem tsmClearFile;
        private System.Windows.Forms.Button btnPref;
        private System.Windows.Forms.ContextMenuStrip cmsApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
    }
}

