using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace lab2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy nội dung từ input.txt
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            string content = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                StreamReader sr = new StreamReader(filePath);
                content = sr.ReadToEnd();
            }

            // Khởi tạo ứng dụng Excel
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true; // Hiển thị ứng dụng Excel

            // Tạo một workbook mới
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Chia nội dung thành các dòng
            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Copy dữ liệu vào bảng Excel
            worksheet.Cells[1, 1] = "MSSV";
            worksheet.Cells[1, 2] = "Tên";
            worksheet.Cells[1, 3] = "SĐT";
            worksheet.Cells[1, 4] = "Toán";
            worksheet.Cells[1, 5] = "Văn";
            worksheet.Cells[1, 6] = "Trung bình";
            double toan, van, avg;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(';'); // Phân tách các ô dữ liệu bằng tab
                toan = double.Parse(cells[cells.Length - 2]);
                van = double.Parse(cells[cells.Length - 1]);
                avg = (toan + van) / (double)2;
                Array.Resize(ref cells, cells.Length + 1);
                cells[cells.Length - 1] = avg.ToString();
                for (int j = 0; j < cells.Length; j++)
                {
                    if(j == 2) // Sửa lỗi mất số 0 đầu tiên trong số điện thoại
                    {
                        if(cells[j][0] == '0')
                        {
                            worksheet.Cells[i + 2, j + 1] = '\'' + cells[j];
                            Excel.Range range = worksheet.Cells[i + 2, j + 1];
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            continue;
                        }
                    }
                    worksheet.Cells[i + 2, j + 1] = cells[j];
                }
            }

            // Cài đặt cột để tự động thích ứng với nội dung
            worksheet.Columns.AutoFit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Tệp tin văn bản (*.txt)|*.txt";
            sfd.FileName = "input.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ans = richTextBox1.Text;

                File.WriteAllText(sfd.FileName, ans);
            }
        }
    }
}
