using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a 'WebRequest' object with the specified url. 	
            WebRequest myWebRequest = WebRequest.Create(richTextBox2.Text);

            // Send the 'WebRequest' and wait for response.
            WebResponse myWebResponse = myWebRequest.GetResponse();

            using (Stream dataStream = myWebResponse.GetResponseStream())
            {
                // Đọc stream dữ liệu
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    // Đọc nội dung HTML
                    string htmlContent = reader.ReadToEnd();

                    // In nội dung HTML ra console
                    richTextBox1.Text = htmlContent;
                }
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < myWebResponse.Headers.Count; ++i)
            {
                int stt = i + 1;
                string header = myWebResponse.Headers.Keys[i];
                string value = myWebResponse.Headers[i];

                dataGridView1.Rows.Add(stt, header, value);
            }
            myWebResponse.Close();
        }
    }
}
