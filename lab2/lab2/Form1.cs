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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tệp tin văn bản (*.txt)|*.txt";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string content = sr.ReadToEnd();
                txtNoiDung.Text = content;
                label1.Text = "Read Content";

                txtViTriLuu.Text += "Read from " + ofd.FileName + "\n";
            }
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Tệp tin văn bản (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string noiDung = txtNoiDung.Text.ToUpper();

                File.WriteAllText(sfd.FileName, noiDung);

                txtViTriLuu.Text += "Save to " + sfd.FileName + "\n";
                label1.Text = "Saved Content";
                txtNoiDung.Text = noiDung;
            }

            
        }
    }
}
