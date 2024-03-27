using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính của OpenFileDialog
            openFileDialog.Title = "Chọn một hoặc nhiều tệp tin";
            openFileDialog.Filter = "Tệp tin văn bản (*.txt)|*.txt|Tất cả các tệp tin (*.*)|*.*";
            openFileDialog.Multiselect = true;

            // Hiển thị hộp thoại và xử lý kết quả
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Đọc đồng thời nhiều tệp tin bằng cách sử dụng đa luồng
                List<Task<string>> readTasks = new List<Task<string>>();
                foreach (string filePath in openFileDialog.FileNames)
                {
                    readTasks.Add(ReadFileAsync(filePath));
                }

                // Đợi tất cả các công việc đọc hoàn thành
                await Task.WhenAll(readTasks);

                // Hiển thị kết quả trong TextBox
                foreach (var task in readTasks)
                {
                    richTextBox1.AppendText(task.Result + Environment.NewLine);
                }
            }
        }

        private async Task<string> ReadFileAsync(string filePath)
        {
            try
            {
                // Asynchronously read all lines from the file
                string[] lines = await Task.Run(() => File.ReadAllLines(filePath));

                // Calculate the number of lines
                int lineCount = lines.Length;

                // Return the result as a string
                return $"{Path.GetFileName(filePath)}: {lineCount} lines\n";
            }
            catch (Exception ex)
            {
                return $"{Path.GetFileName(filePath)}: Error reading file - {ex.Message}\n";
            }
        }


    }
}
