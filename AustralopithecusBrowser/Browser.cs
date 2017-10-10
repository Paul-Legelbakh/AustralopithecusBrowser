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
        public Browser()
        {
            InitializeComponent();
        }
        public void GoForward()
        {
            webBrowser1.GoForward();
        }
        public void GoBack()
        {
            webBrowser1.GoBack();
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
                //string url = textBoxURL.Text;
                //if (url.IndexOf("http://www.") == -1)
                //{
                //    webBrowser1.Navigate(@"http://www." + url);
                //}
                //else webBrowser1.Navigate(@url);
            }
        }
    }
}
