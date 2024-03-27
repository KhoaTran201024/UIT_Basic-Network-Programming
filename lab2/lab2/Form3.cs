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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                StreamReader sr = new StreamReader(filePath);
                string content = sr.ReadToEnd();

                richTextBox1.Text = content;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string line in richTextBox1.Lines)
            {
                string[] parts = line.Split(' ');

                if (parts.Length != 3)
                {
                    continue;
                }

                double num1 = double.Parse(parts[0]);
                double num2 = double.Parse(parts[2]);

                double ans = 0;
                switch (parts[1])
                {
                    case "+":
                        ans = num1 + num2;
                        break;
                    case "-":
                        ans = num1 - num2;
                        break;
                    case "*":
                        ans = num1 * num2;
                        break;
                    case "/":
                        ans = num1 / num2;
                        break;
                }

                richTextBox2.Text += line + " = " + ans + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Tệp tin văn bản (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ans = richTextBox2.Text;

                File.WriteAllText(sfd.FileName, ans);
            }
        }
    }
}
