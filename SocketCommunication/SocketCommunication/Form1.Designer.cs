﻿namespace SocketCommunication
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.rtbReceivedMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 132);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 132);
            this.button2.TabIndex = 1;
            this.button2.Text = "Start Client";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(123, 258);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(202, 116);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "";
            // 
            // rtbReceivedMessages
            // 
            this.rtbReceivedMessages.Location = new System.Drawing.Point(449, 242);
            this.rtbReceivedMessages.Name = "rtbReceivedMessages";
            this.rtbReceivedMessages.Size = new System.Drawing.Size(202, 116);
            this.rtbReceivedMessages.TabIndex = 3;
            this.rtbReceivedMessages.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbReceivedMessages);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.RichTextBox rtbReceivedMessages;
    }
}

