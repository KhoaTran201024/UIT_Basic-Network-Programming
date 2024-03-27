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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tệp tin văn bản (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                StreamReader sr = new StreamReader(filePath);
                string content = sr.ReadToEnd();
                richTextBox2.Text = content;

                richTextBox1.Text += "File Name: " + Path.GetFileName(filePath) + "\n";

                richTextBox1.Text += "URL: " + filePath + "\n";

                string[] lines = File.ReadAllLines(filePath);
                int numLines = lines.Length;
                richTextBox1.Text += "Line Number: " + numLines + "\n";

                int numWords = 0;
                int numChars = 0;
                foreach (string line in lines)
                {
                    numChars += line.Length;
                    string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    numWords += words.Length;
                }
                richTextBox1.Text += "Number of Words: " + numWords + "\n";
                richTextBox1.Text += "Number of Characters: " + numChars + "\n";

                richTextBox1.Text += "\n";
            }
        }
    }
}
