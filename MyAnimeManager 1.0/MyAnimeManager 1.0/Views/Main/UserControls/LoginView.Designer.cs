namespace MyAnimeManager_1._0.Views.Main.Forms
{
    partial class LoginView
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
            this.webViewLogin = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // webViewLogin
            // 
            this.webViewLogin.CreationProperties = null;
            this.webViewLogin.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewLogin.Location = new System.Drawing.Point(0, 0);
            this.webViewLogin.Name = "webViewLogin";
            this.webViewLogin.Size = new System.Drawing.Size(389, 498);
            this.webViewLogin.TabIndex = 0;
            this.webViewLogin.ZoomFactor = 1D;
            this.webViewLogin.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webViewLogin_NavigationCompleted);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 498);
            this.Controls.Add(this.webViewLogin);
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginView";
            ((System.ComponentModel.ISupportInitialize)(this.webViewLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewLogin;
    }
}