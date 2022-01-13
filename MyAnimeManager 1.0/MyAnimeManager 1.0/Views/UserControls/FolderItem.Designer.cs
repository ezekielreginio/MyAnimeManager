namespace MyAnimeManager_1._0.Views.UserControls
{
    partial class FolderItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxFolderIcon = new System.Windows.Forms.PictureBox();
            this.labelFolderName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFolderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFolderIcon
            // 
            this.pictureBoxFolderIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxFolderIcon.Image = global::MyAnimeManager_1._0.Properties.Resources.default_folder_icon;
            this.pictureBoxFolderIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFolderIcon.Name = "pictureBoxFolderIcon";
            this.pictureBoxFolderIcon.Size = new System.Drawing.Size(150, 120);
            this.pictureBoxFolderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFolderIcon.TabIndex = 0;
            this.pictureBoxFolderIcon.TabStop = false;
            this.pictureBoxFolderIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFolderIcon_MouseUp);
            // 
            // labelFolderName
            // 
            this.labelFolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFolderName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderName.ForeColor = System.Drawing.Color.White;
            this.labelFolderName.Location = new System.Drawing.Point(0, 120);
            this.labelFolderName.Name = "labelFolderName";
            this.labelFolderName.Size = new System.Drawing.Size(150, 30);
            this.labelFolderName.TabIndex = 1;
            this.labelFolderName.Text = "label1";
            this.labelFolderName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFolderName.Click += new System.EventHandler(this.labelFolderName_Click);
            // 
            // FolderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.labelFolderName);
            this.Controls.Add(this.pictureBoxFolderIcon);
            this.Name = "FolderItem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFolderIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFolderIcon;
        private System.Windows.Forms.Label labelFolderName;
    }
}
