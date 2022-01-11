namespace MyAnimeManager_1._0.Forms
{
    partial class DirectoryView
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
            this.panelNoDirectory = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNoDirectory.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNoDirectory
            // 
            this.panelNoDirectory.Controls.Add(this.panel3);
            this.panelNoDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoDirectory.Location = new System.Drawing.Point(0, 0);
            this.panelNoDirectory.Name = "panelNoDirectory";
            this.panelNoDirectory.Size = new System.Drawing.Size(800, 450);
            this.panelNoDirectory.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(108)))));
            this.panel3.Controls.Add(this.buttonSelectDirectory);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 44);
            this.panel3.TabIndex = 1;
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(146)))));
            this.buttonSelectDirectory.FlatAppearance.BorderSize = 0;
            this.buttonSelectDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectDirectory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectDirectory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSelectDirectory.Location = new System.Drawing.Point(668, 6);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(120, 33);
            this.buttonSelectDirectory.TabIndex = 1;
            this.buttonSelectDirectory.Text = "Set Directory";
            this.buttonSelectDirectory.UseVisualStyleBackColor = false;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(230, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Your Anime Directory is Not Set";
            // 
            // DirectoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelNoDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DirectoryView";
            this.Text = "Directory";
            this.panelNoDirectory.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNoDirectory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label label2;
    }
}