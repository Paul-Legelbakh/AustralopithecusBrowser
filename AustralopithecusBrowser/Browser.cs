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

        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return") webBrowser1.Navigate(@"http://www." + textBoxURL.Text);
        }
    }
}
