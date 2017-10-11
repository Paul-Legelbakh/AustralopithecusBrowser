using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AustralopithecusBrowser
{
    public partial class Browser : UserControl
    {
        private HtmlHistory history;
        public Browser()
        {
            InitializeComponent();
        }
        public void GoForward()
        {
            if(webBrowser1.CanGoForward) webBrowser1.GoForward();
        }
        public void SetHome()
        {
            textBoxURL.Text = "google.com";
            string url = "http://google.com";
            webBrowser1.Navigate(new Uri(url));
        }
        public void GoBack()
        {
            if(webBrowser1.CanGoBack) webBrowser1.GoBack();
        }
        public void RefreshPage()
        {
            if(!webBrowser1.Url.Equals("about:blank"))
            {
                webBrowser1.Refresh();
            }
        }
        public void StopPage()
        {
            webBrowser1.Stop();
        }
        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                string url = textBoxURL.Text;
                if (!url.StartsWith("http://www.") && !url.StartsWith("https://www."))
                {
                    url = "http://www." + url;
                }
                webBrowser1.Navigate(new Uri(url));
                webBrowser1.ScriptErrorsSuppressed = false;
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBoxURL.Text = webBrowser1.Url.ToString();
        }
    }
}
