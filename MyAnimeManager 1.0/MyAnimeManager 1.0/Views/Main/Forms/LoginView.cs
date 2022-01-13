using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.Main.Forms
{
    public partial class LoginView : Form, ILoginView
    {
        public event EventHandler AuthenticationCodeObtainedEventRaised;
        private String code;
        public LoginView()
        {
            InitializeComponent();
        }

        public async void ShowLoginForm()
        {
            this.Show();
            await webViewLogin.EnsureCoreWebView2Async();
            webViewLogin.CoreWebView2.Navigate("https://myanimelist.net/v1/oauth2/authorize?client_id=798f54733a1dd810ed0760206d54b815&code_challenge=NklUDX_CzS8qrMGWaDzgKs6VqrinuVFHa0xnpWPDy7_fggtM6kAar4jnTwOgzK7nPYfE9n60rsY4fhDExWzr5bf7sEvMMmSXcT2hWkCstFGIJKoaimoq5GvAEQD8NZ8g&response_type=code");
        }

        public String GetCode()
        {
            return code;
        }

        private void webViewLogin_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            string url = webViewLogin.Source.ToString();
            if (url.Contains("myanimemanager.000webhostapp.com"))
            {
                this.code = url.Substring(url.LastIndexOf('=') + 1);
                EventHelpers.RaiseEvent(this, AuthenticationCodeObtainedEventRaised, e);
                webViewLogin.CoreWebView2.Navigate("about:blank");
                this.Hide();
            }
        }
    }
}
