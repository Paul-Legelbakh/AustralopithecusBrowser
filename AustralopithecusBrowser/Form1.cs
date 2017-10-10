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
    }
}
