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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = richTextBox1.Text;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        string htmlContent = client.DownloadString(url);
                        System.IO.File.WriteAllText("page.html", htmlContent);

                        List<string> resources = GetWebResources(htmlContent);

                        foreach (string resource in resources)
                        {
                            string resourceName = System.IO.Path.GetFileName(resource);
                            client.DownloadFile(new Uri(resource), resourceName);
                        }
                    }
                    MessageBox.Show("Complete web page saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving complete web page: " + ex.Message);
                }
            }
        }

        private List<string> GetWebResources(string html)
        {
            List<string> resources = new List<string>();

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(href|src)=[\""]([^\""]+)[\""]");
            System.Text.RegularExpressions.MatchCollection matches = regex.Matches(html);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string resource = match.Groups[2].Value;
                if (!string.IsNullOrEmpty(resource))
                {
                    resources.Add(resource);
                }
            }
            return resources;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = richTextBox1.Text;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        webBrowser1.Navigate(new Uri(url));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading URL: " + ex.Message);
                }
            }

            WebRequest myWebRequest = WebRequest.Create(richTextBox1.Text);

            WebResponse myWebResponse = myWebRequest.GetResponse();

            using (Stream dataStream = myWebResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    string htmlContent = reader.ReadToEnd();

                    richTextBox2.Text = htmlContent;
                }
            }
        }
    }
}
