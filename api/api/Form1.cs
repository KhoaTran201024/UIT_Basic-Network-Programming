using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://worldtimeapi.org/api/timezone/America/New_York";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(responseData);
                        string currentTime = result.datetime;
                        DateTime newYorkTime = DateTime.Parse(currentTime);

                        // Hiển thị giờ ở New York
                        richTextBox1.Text += $"Giờ ở New York: {newYorkTime.ToString()}\n";
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy dữ liệu từ API.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
