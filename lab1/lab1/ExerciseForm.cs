using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class ExerciseForm : Form
    {
        private int exerciseNumber;
        private Form1 mainForm;

        public ExerciseForm(int exerciseNumber, Form1 mainForm)
        {
            InitializeComponent();
            this.exerciseNumber = exerciseNumber;
            this.mainForm = mainForm;
            this.Text = "Exercise " + exerciseNumber.ToString();
            if (exerciseNumber == 1)
            {
                txtNum3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                button3.Visible = false;
                label7.Visible = false;
                richTextBox2.Visible = false;
            }
            else if (exerciseNumber == 2)
            {
                label5.Visible = false;
                label6.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                btnAdd.Visible = false;
                btnSubtract.Visible = false;
                btnMultiply.Visible = false;
                btnDivide.Visible = false;
                label7.Visible = false;
                richTextBox2.Visible = false;
                button3.Text = "Tìm";
            }
            else if (exerciseNumber == 3)
            {
                button3.Text = "Đọc";
                label3.Visible = false;
                label4.Visible = false;
                txtNum2.Visible = false;
                txtNum3.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                btnAdd.Visible = false;
                btnSubtract.Visible = false;
                btnMultiply.Visible = false;
                btnDivide.Visible = false;
                label7.Visible = false;
                richTextBox2.Visible = false;
            }
            else if (exerciseNumber == 4)
            {
                button3.Text = "Đổi";
                label3.Visible = false;
                label4.Visible = false;
                txtNum2.Visible = false;
                txtNum3.Visible = false;
                btnAdd.Visible = false;
                btnSubtract.Visible = false;
                btnMultiply.Visible = false;
                btnDivide.Visible = false;
                label7.Visible = false;
                richTextBox2.Visible = false;
            }
            else if (exerciseNumber == 5)
            {
                button3.Text = "Xuất";
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                txtNum1.Visible = false;
                txtNum2.Visible = false;
                txtNum3.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                btnAdd.Visible = false;
                btnSubtract.Visible = false;
                btnMultiply.Visible = false;
                btnDivide.Visible = false;
                MessageBox.Show("Vui lòng nhập điểm của môn học, cách nhau bằng dấu cách, thang điểm 10.");
            }
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (exerciseNumber == 2)
            {
                double num1, num2, num3, result1, result2;
                if (double.TryParse(txtNum1.Text, out num1) && double.TryParse(txtNum2.Text, out num2) && double.TryParse(txtNum3.Text, out num3))
                {
                    result1 = Math.Max(num1, Math.Max(num2, num3));
                    result2 = Math.Min(num1, Math.Min(num2, num3));
                    richTextBox1.AppendText($"Số lớn nhất: {result1}\n");
                    richTextBox1.AppendText($"Số bé nhất: {result2}");
                }
            }
            else if (exerciseNumber == 3)
            {
                string[] so = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín"};
                int num;
                if (int.TryParse(txtNum1.Text, out num))
                {
                    if(num < -9 || num > 9)
                    {
                        MessageBox.Show("Nhập số từ -9 đến 9!");
                    }
                    else if(num < 0)
                    {
                        richTextBox1.Text = "Âm " + so[Math.Abs(num)];
                    }
                    else
                    {
                        richTextBox1.Text = so[num];
                    }
                }
                else
                {
                    MessageBox.Show("Nhập không hợp lệ! Vui lòng nhập lại.");
                }
            }
            else if (exerciseNumber == 4)
            {
                string inputType = comboBox1.SelectedItem.ToString();
                string outputType = comboBox2.SelectedItem.ToString();
                string inputValue = txtNum1.Text;
                if (inputType == outputType)
                {
                    MessageBox.Show("Vui lòng chọn hệ số đầu ra khác với hệ số đầu vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsValidInput(inputType, inputValue))
                {
                    MessageBox.Show("Giá trị đầu vào không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string result = ConvertNumber(inputType, outputType, inputValue);
                richTextBox1.Text = result;
            }
            else if (exerciseNumber == 5)
            {
                double[] scores;
                double avg = 0, max = -1, min = 11;
                int passed = 0;
                string input = richTextBox2.Text.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Vui lòng nhập điểm của môn học, cách nhau bằng dấu cách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] scoreStrings = input.Split(' ');
                scores = new double[scoreStrings.Length];

                for (int i = 0; i < scoreStrings.Length; i++)
                {
                    if (!double.TryParse(scoreStrings[i], out scores[i]))
                    {
                        MessageBox.Show("Vui lòng nhập điểm số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                for (int i = 0; i < scores.Length; i++)
                {
                    avg += scores[i];
                    max = Math.Max(max, scores[i]);
                    min = Math.Min(min, scores[i]);
                    if (scores[i] >= 5)
                    {
                        passed++;
                    }
                    richTextBox1.AppendText($"Môn {i + 1}: {scores[i]}\n");
                }
                avg = (double)avg / scores.Length;
                richTextBox1.AppendText($"Điểm trung bình: {avg}\n");
                richTextBox1.AppendText($"Điểm cao nhất: {max}\n");
                richTextBox1.AppendText($"Điểm thấp nhất: {min}\n");
                richTextBox1.AppendText($"Số môn đậu: {passed}\n");
                richTextBox1.AppendText($"Số môn rớt: {scores.Length - passed}\n");
            }
        }

        private string ConvertNumber(string inputType, string outputType, string inputValue)
        {
            switch (inputType)
            {
                case "Demical":
                    if (outputType == "Binary")
                        return Convert.ToString(int.Parse(inputValue), 2);
                    else if (outputType == "Hexa")
                        return Convert.ToString(int.Parse(inputValue), 16);
                    break;
                case "Binary":
                    if (outputType == "Demical")
                        return Convert.ToInt32(inputValue, 2).ToString();
                    else if (outputType == "Hexa")
                        return Convert.ToString(Convert.ToInt32(inputValue, 2), 16);
                    break;
                case "Hexa":
                    if (outputType == "Demical")
                        return Convert.ToInt32(inputValue, 16).ToString();
                    else if (outputType == "Binary")
                        return Convert.ToString(Convert.ToInt32(inputValue, 16), 2);
                    break;
            }
            return inputValue; // Trường hợp không chuyển đổi
        }

        private bool IsValidInput(string inputType, string inputValue)
        {
            // Kiểm tra tính hợp lệ của giá trị đầu vào dựa trên loại hệ số
            switch (inputType)
            {
                case "Demical":
                    return int.TryParse(inputValue, out _);
                case "Binary":
                    return IsBinary(inputValue);
                case "Hexa":
                    return IsHex(inputValue);
                default:
                    return false;
            }
        }

        private bool IsBinary(string value)
        {
            foreach (char c in value)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }

        private bool IsHex(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && (c < 'A' || c > 'F') && (c < 'a' || c > 'f'))
                    return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các ô nhập
            txtNum1.Clear();
            txtNum2.Clear();
            txtNum3.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            // Thêm các ô nhập khác nếu có
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text, out num1) && int.TryParse(txtNum2.Text, out num2))
            {
                // Kiểm tra phép toán và thực hiện tính toán
                // Thực hiện phép cộng
                long result = num1 + num2;
                richTextBox1.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Nhập không hợp lệ! Vui lòng nhập lại.");
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text, out num1) && int.TryParse(txtNum2.Text, out num2))
            {
                // Kiểm tra phép toán và thực hiện tính toán
                // Thực hiện phép trừ
                long result = num1 - num2;
                richTextBox1.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Nhập không hợp lệ! Vui lòng nhập lại.");
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text, out num1) && int.TryParse(txtNum2.Text, out num2))
            {
                // Kiểm tra phép toán và thực hiện tính toán
                // Thực hiện phép nhân
                long result = num1 * num2;
                richTextBox1.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Nhập không hợp lệ! Vui lòng nhập lại.");
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text, out num1) && int.TryParse(txtNum2.Text, out num2))
            {
                // Kiểm tra mẫu số khác 0 trước khi thực hiện phép chia
                if (num2 != 0)
                {
                    double result = (double)num1 / num2;
                    richTextBox1.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Mẫu số không thể là 0!");
                }
            }
            else
            {
                MessageBox.Show("Nhập không hợp lệ! Vui lòng nhập lại.");
            }
        }
    }
}
