namespace CoolBoy.Forms
{
    partial class frmPreferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.cb = new System.Windows.Forms.CheckBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.fbdWeb = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.tbxStart = new System.Windows.Forms.TextBox();
            this.gbLocation.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.tbxStart);
            this.gbLocation.Controls.Add(this.tbxFolder);
            this.gbLocation.Controls.Add(this.btnFolder);
            this.gbLocation.Controls.Add(this.lblStart);
            this.gbLocation.Controls.Add(this.lblFolder);
            this.gbLocation.Location = new System.Drawing.Point(12, 12);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(462, 124);
            this.gbLocation.TabIndex = 0;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "Website location";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.cb);
            this.gbOptions.Location = new System.Drawing.Point(12, 146);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(462, 55);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Website options";
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Location = new System.Drawing.Point(10, 23);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(203, 17);
            this.cb.TabIndex = 0;
            this.cb.Text = "Send file listing if there\'s no start page";
            this.cb.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(399, 215);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(7, 26);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(62, 13);
            this.lblFolder.TabIndex = 1;
            this.lblFolder.Text = "Web folder:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(7, 92);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(59, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Start page:";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(343, 55);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(113, 23);
            this.btnFolder.TabIndex = 3;
            this.btnFolder.Text = "Select web folder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // tbxFolder
            // 
            this.tbxFolder.Location = new System.Drawing.Point(75, 23);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(381, 20);
            this.tbxFolder.TabIndex = 4;
            // 
            // tbxStart
            // 
            this.tbxStart.Location = new System.Drawing.Point(75, 89);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Size = new System.Drawing.Size(381, 20);
            this.tbxStart.TabIndex = 5;
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 251);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.gbLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPreferences";
            this.Text = "CoolBoy Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.TextBox tbxStart;
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog fbdWeb;
    }
}