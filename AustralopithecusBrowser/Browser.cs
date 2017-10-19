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
        public static string home;
        public delegate void NavigatedUrl(object sender, string title);
        public NavigatedUrl title;
        public Browser()
        {
            InitializeComponent();
            if (AustralopithecusHistory.str != "") webBrowser1.Navigate(new Uri(AustralopithecusHistory.str));
        }
        public void GetPageUrl()
        {
            home = webBrowser1.Url.ToString();
        }
        public void DeletePage()
        {
            webBrowser1.Dispose();
        }
        public void GoForward()
        {
            if(webBrowser1.CanGoForward) webBrowser1.GoForward();
        }
        public void SetHome()
        {
            webBrowser1.Navigate(new Uri(home));
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
            try
            {
                if (e.KeyCode.ToString() == "Return")
                {
                    string url = textBoxURL.Text;
                    if (!url.StartsWith("http://www.") && !url.StartsWith("https://www."))
                    {
                        url = "http://www." + url;
                    }
                    webBrowser1.Navigate(new Uri(url));
                }
            } catch { }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            UseWaitCursor = true;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UseWaitCursor = false;
            History objHistory = new History();
            //Form1.tabControl1.SelectedTab.Text = webBrowser1.Document.Title;
            objHistory.Url = webBrowser1.Url.ToString();
            Form1.history.Add(objHistory);
            Form1.SaveHistory();
            textBoxURL.Text = webBrowser1.Url.ToString();
            title?.Invoke(this, webBrowser1.Document.Title.ToString());
        }
    }
}
