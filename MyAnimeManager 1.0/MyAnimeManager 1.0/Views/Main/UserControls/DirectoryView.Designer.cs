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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryView));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.panelNoDirectory = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDirectory = new System.Windows.Forms.Panel();
            this.panelDirectoriesList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuTextBoxSearch = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuDropdown1 = new Bunifu.Framework.UI.BunifuDropdown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.imageListFolders = new System.Windows.Forms.ImageList(this.components);
            this.panelDirectoryLoading = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelNoDirectory.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelDirectory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelDirectoryLoading.SuspendLayout();
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
            // panelDirectory
            // 
            this.panelDirectory.Controls.Add(this.panelDirectoriesList);
            this.panelDirectory.Controls.Add(this.panelDirectoryLoading);
            this.panelDirectory.Controls.Add(this.panel1);
            this.panelDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirectory.Location = new System.Drawing.Point(0, 0);
            this.panelDirectory.Name = "panelDirectory";
            this.panelDirectory.Size = new System.Drawing.Size(800, 450);
            this.panelDirectory.TabIndex = 2;
            // 
            // panelDirectoriesList
            // 
            this.panelDirectoriesList.AutoScroll = true;
            this.panelDirectoriesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirectoriesList.Location = new System.Drawing.Point(0, 44);
            this.panelDirectoriesList.Name = "panelDirectoriesList";
            this.panelDirectoriesList.Size = new System.Drawing.Size(800, 406);
            this.panelDirectoriesList.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(146)))));
            this.panel1.Controls.Add(this.bunifuTextBoxSearch);
            this.panel1.Controls.Add(this.bunifuDropdown1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 44);
            this.panel1.TabIndex = 2;
            // 
            // bunifuTextBoxSearch
            // 
            this.bunifuTextBoxSearch.AcceptsReturn = false;
            this.bunifuTextBoxSearch.AcceptsTab = false;
            this.bunifuTextBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuTextBoxSearch.AnimationSpeed = 200;
            this.bunifuTextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuTextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuTextBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTextBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBoxSearch.BackgroundImage")));
            this.bunifuTextBoxSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.bunifuTextBoxSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.bunifuTextBoxSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuTextBoxSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.bunifuTextBoxSearch.BorderRadius = 1;
            this.bunifuTextBoxSearch.BorderThickness = 1;
            this.bunifuTextBoxSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuTextBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBoxSearch.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuTextBoxSearch.DefaultText = "";
            this.bunifuTextBoxSearch.FillColor = System.Drawing.Color.White;
            this.bunifuTextBoxSearch.HideSelection = true;
            this.bunifuTextBoxSearch.IconLeft = null;
            this.bunifuTextBoxSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBoxSearch.IconPadding = 10;
            this.bunifuTextBoxSearch.IconRight = null;
            this.bunifuTextBoxSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBoxSearch.Lines = new string[0];
            this.bunifuTextBoxSearch.Location = new System.Drawing.Point(612, 5);
            this.bunifuTextBoxSearch.MaxLength = 32767;
            this.bunifuTextBoxSearch.MinimumSize = new System.Drawing.Size(100, 35);
            this.bunifuTextBoxSearch.Modified = false;
            this.bunifuTextBoxSearch.Multiline = false;
            this.bunifuTextBoxSearch.Name = "bunifuTextBoxSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBoxSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBoxSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBoxSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBoxSearch.OnIdleState = stateProperties4;
            this.bunifuTextBoxSearch.PasswordChar = '\0';
            this.bunifuTextBoxSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBoxSearch.PlaceholderText = "Search Anime";
            this.bunifuTextBoxSearch.ReadOnly = false;
            this.bunifuTextBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuTextBoxSearch.SelectedText = "";
            this.bunifuTextBoxSearch.SelectionLength = 0;
            this.bunifuTextBoxSearch.SelectionStart = 0;
            this.bunifuTextBoxSearch.ShortcutsEnabled = true;
            this.bunifuTextBoxSearch.Size = new System.Drawing.Size(185, 35);
            this.bunifuTextBoxSearch.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.bunifuTextBoxSearch.TabIndex = 3;
            this.bunifuTextBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuTextBoxSearch.TextMarginBottom = 0;
            this.bunifuTextBoxSearch.TextMarginLeft = 5;
            this.bunifuTextBoxSearch.TextMarginTop = 0;
            this.bunifuTextBoxSearch.TextPlaceholder = "Search Anime";
            this.bunifuTextBoxSearch.UseSystemPasswordChar = false;
            this.bunifuTextBoxSearch.WordWrap = true;
            this.bunifuTextBoxSearch.TextChange += new System.EventHandler(this.bunifuTextBox1_TextChange);
            this.bunifuTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bunifuTextBoxSearch_KeyDown);
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BorderRadius = 3;
            this.bunifuDropdown1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.items = new string[] {
        "Show All",
        "By Season",
        "By Genre",
        "By Rating"};
            this.bunifuDropdown1.Location = new System.Drawing.Point(82, 8);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bunifuDropdown1.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bunifuDropdown1.selectedIndex = 0;
            this.bunifuDropdown1.Size = new System.Drawing.Size(105, 29);
            this.bunifuDropdown1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(76, 44);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(146)))));
            this.iconPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 20;
            this.iconPictureBox1.Location = new System.Drawing.Point(10, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.iconPictureBox1.Size = new System.Drawing.Size(20, 34);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // imageListFolders
            // 
            this.imageListFolders.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListFolders.ImageSize = new System.Drawing.Size(150, 150);
            this.imageListFolders.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelDirectoryLoading
            // 
            this.panelDirectoryLoading.Controls.Add(this.label3);
            this.panelDirectoryLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDirectoryLoading.Location = new System.Drawing.Point(0, 44);
            this.panelDirectoryLoading.Name = "panelDirectoryLoading";
            this.panelDirectoryLoading.Size = new System.Drawing.Size(800, 406);
            this.panelDirectoryLoading.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(800, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loading Directory. Please Wait.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DirectoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDirectory);
            this.Controls.Add(this.panelNoDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DirectoryView";
            this.Text = "Directory";
            this.Load += new System.EventHandler(this.DirectoryView_Load);
            this.panelNoDirectory.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelDirectory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelDirectoryLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNoDirectory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdown1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox bunifuTextBoxSearch;
        private System.Windows.Forms.ImageList imageListFolders;
        private System.Windows.Forms.FlowLayoutPanel panelDirectoriesList;
        private System.Windows.Forms.Panel panelDirectoryLoading;
        private System.Windows.Forms.Label label3;
    }
}