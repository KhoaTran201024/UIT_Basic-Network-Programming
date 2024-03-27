using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVMaking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            // Ẩn tất cả các label trước khi hiển thị label tương ứng
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            // Lấy Tag của Button được click để xác định label tương ứng
            Button clickedButton = (Button)sender;
            string correspondingLabelName = clickedButton.Tag.ToString();

            // Hiển thị label tương ứng với Button được click
            Control correspondingLabel = Controls.Find(correspondingLabelName, true).FirstOrDefault();
            if (correspondingLabel != null && correspondingLabel is Label)
            {
                ((Label)correspondingLabel).Visible = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
