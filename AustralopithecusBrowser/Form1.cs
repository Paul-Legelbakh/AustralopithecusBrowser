using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AustralopithecusBrowser
{
    public partial class Form1 : Form
    {
        //private List<History> history = new List<History>();
        private int pageInc = 1;
        public Form1()
        {
            InitializeComponent();
            CreateTab();
        }
        private void DeleteTab()
        {
            tabControl1.Controls.RemoveAt(tabControl1.SelectedIndex);
        }
        private void CreateTab()
        {
            Browser browser = new Browser();
            browser.Dock = DockStyle.Fill;
            TabPage newPage = new TabPage();
            newPage.Controls.Add(browser);
            tabControl1.Controls.Add(newPage);
            newPage.Text = "Page " + pageInc;
            pageInc++;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateTab();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTab();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var control in tabControl1.SelectedTab.Controls)
            {
                if(control is Browser)
                {
                    Browser current = (Browser)control;
                    current.GoBack();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var control in tabControl1.SelectedTab.Controls)
            {
                if (control is Browser)
                {
                    Browser current = (Browser)control;
                    current.GoForward();
                }
            }
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var control in tabControl1.SelectedTab.Controls)
            {
                if (control is Browser)
                {
                    Browser current = (Browser)control;
                    current.SetHome();
                }
            }
        }
        private void овитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var control in tabControl1.SelectedTab.Controls)
            {
                if (control is Browser)
                {
                    Browser current = (Browser)control;
                    current.RefreshPage();
                }
            }
        }

        private void прекратитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var control in tabControl1.SelectedTab.Controls)
            {
                if (control is Browser)
                {
                    Browser current = (Browser)control;
                    current.StopPage();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void оБраузереToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //history.DomHistory;
        }
    }
}
