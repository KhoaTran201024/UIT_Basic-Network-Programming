namespace lab2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDocFile = new System.Windows.Forms.Button();
            this.btnGhiFile = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.RichTextBox();
            this.txtViTriLuu = new System.Windows.Forms.RichTextBox();
            this.ofdChonFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdLuuFile = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(32, 12);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(151, 71);
            this.btnDocFile.TabIndex = 0;
            this.btnDocFile.Text = "Read File";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // btnGhiFile
            // 
            this.btnGhiFile.Location = new System.Drawing.Point(212, 12);
            this.btnGhiFile.Name = "btnGhiFile";
            this.btnGhiFile.Size = new System.Drawing.Size(151, 71);
            this.btnGhiFile.TabIndex = 1;
            this.btnGhiFile.Text = "Save File";
            this.btnGhiFile.UseVisualStyleBackColor = true;
            this.btnGhiFile.Click += new System.EventHandler(this.btnGhiFile_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(32, 153);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(298, 140);
            this.txtNoiDung.TabIndex = 2;
            this.txtNoiDung.Text = "";
            // 
            // txtViTriLuu
            // 
            this.txtViTriLuu.Location = new System.Drawing.Point(368, 153);
            this.txtViTriLuu.Name = "txtViTriLuu";
            this.txtViTriLuu.ReadOnly = true;
            this.txtViTriLuu.Size = new System.Drawing.Size(298, 140);
            this.txtViTriLuu.TabIndex = 3;
            this.txtViTriLuu.Text = "";
            // 
            // ofdChonFile
            // 
            this.ofdChonFile.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtViTriLuu);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.btnGhiFile);
            this.Controls.Add(this.btnDocFile);
            this.Name = "Form1";
            this.Text = "B1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.Button btnGhiFile;
        private System.Windows.Forms.RichTextBox txtNoiDung;
        private System.Windows.Forms.RichTextBox txtViTriLuu;
        private System.Windows.Forms.OpenFileDialog ofdChonFile;
        private System.Windows.Forms.SaveFileDialog sfdLuuFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

