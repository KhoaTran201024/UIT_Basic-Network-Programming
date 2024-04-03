using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = "";
                    webBrowser1.Url = null;

                    string selectedPath = fbd.SelectedPath;
                    webBrowser1.Url = new Uri(selectedPath);
                    richTextBox1.Text = selectedPath;
                }
            }
        }
    }
}
