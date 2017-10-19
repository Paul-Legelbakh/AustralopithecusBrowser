using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AustralopithecusBrowser
{
    public partial class Form1 : Form
    {
        public static List<History> history = new List<History>();
        private int pageInc = 1;
        public Form1()
        {
            InitializeComponent();
            CreateTab();
            LoadHistory();
            try
            {
                if (File.Exists("Home.bin"))
                {
                    FileStream fs = new FileStream("Home.bin", FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    Browser.home = (string)formatter.Deserialize(fs);
                    fs.Close();
                }
                else Browser.home = "http://google.com";
            }
            catch { }
            
        }
        private void DeleteTab()
        {
            tabControl1.SelectedTab.Dispose();
            //tabControl1.Controls.RemoveAt(tabControl1.SelectedIndex);
        }
        public static void SaveHistory()
        {
            try
            {
                FileStream fs = new FileStream("History.bin", FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, history);
                fs.Close();
            }
            catch { }
        }
        public void LoadHistory()
        {
            try
            {
                if (File.Exists("History.bin"))
                {
                    FileStream fs = new FileStream("History.bin", FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    history = (List<History>)formatter.Deserialize(fs);
                    fs.Close();
                }
            }
            catch { }
        }

        private void SetPageTitle(object sender, string titleSite)
        {
            tabControl1.SelectedTab.Text = titleSite;
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
            browser.title = SetPageTitle;
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
            AustralopithecusHistory viewHistory = new AustralopithecusHistory();
            viewHistory.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void установитьКакДомашнююToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var control in tabControl1.SelectedTab.Controls)
            {
                if (control is Browser)
                {
                    Browser current = (Browser)control;
                    current.GetPageUrl();
                    try
                    {
                        FileStream fs = new FileStream("Home.bin", FileMode.OpenOrCreate);
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, Browser.home);
                        fs.Close();
                    }
                    catch { }
                }
            }
        }
    }
}
