using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace lab4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            List<Device> devices = new List<Device>
        {
            new Device { Name = "iPhone 12", UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 14_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1", Width = 390, Height = 844 },
            new Device { Name = "Samsung Galaxy S21", UserAgent = "Mozilla/5.0 (Linux; Android 11; SM-G991B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.105 Mobile Safari/537.36", Width = 412, Height = 915 },
            new Device { Name = "iPad Pro", UserAgent = "Mozilla/5.0 (iPad; CPU OS 14_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1", Width = 1024, Height = 1366 }
            // Thêm các thiết bị khác tại đây
        };

            // Gán danh sách thiết bị vào ComboBox
            comboBox1.DataSource = devices;

            InitializeWebView2Async();
        }

        private async void InitializeWebView2Async()
        {
            var environment = await CoreWebView2Environment.CreateAsync();
            await webView21.EnsureCoreWebView2Async(environment);
            webView21.Source = new Uri("https://nc.uit.edu.vn");
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            // Lấy thiết bị được chọn từ ComboBox
            Device selectedDevice = (Device)comboBox1.SelectedItem;

            // Hiển thị User-Agent tương ứng trong TextBox
            richTextBox2.Text = selectedDevice.UserAgent;

            // Cấu hình User-Agent và kích thước màn hình cho WebView2
            if (webView21.CoreWebView2 != null)
            {
                // Cấu hình User-Agent và kích thước màn hình cho WebView2
                webView21.CoreWebView2.Settings.UserAgent = selectedDevice.UserAgent;
                webView21.Width = selectedDevice.Width;
                webView21.Height = selectedDevice.Height;

                // Tải lại trang để áp dụng User-Agent mới
                webView21.Reload();
            }
        }
    }
    public class Device
    {
        public string Name { get; set; }
        public string UserAgent { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
