using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace lab4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string name = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string gender = await PredictGenderAsync(name);
                //MessageBox.Show($"Predicted gender: {gender}", "Prediction Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox2.Text = gender;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> PredictGenderAsync(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.genderize.io?name={name}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // Throw if not success

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody.Contains("\"gender\":\"male\"") ? "Male" : "Female";
            }
        }
    }
}
