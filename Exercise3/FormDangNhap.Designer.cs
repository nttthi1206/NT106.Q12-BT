﻿
namespace BT3_LTMCB
{
    partial class FormDangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            checkBoxShowPassword = new CheckBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(551, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 38);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(388, 68);
            label1.Name = "label1";
            label1.Size = new Size(196, 35);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG NHẬP";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(417, 377);
            button1.Name = "button1";
            button1.Size = new Size(145, 38);
            button1.TabIndex = 2;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(297, 176);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 268);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Cursor = Cursors.SizeNESW;
            textBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(551, 260);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(125, 38);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(297, 478);
            label4.Name = "label4";
            label4.Size = new Size(206, 23);
            label4.TabIndex = 6;
            label4.Text = "Bạn chưa có tài khoản?";
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(573, 470);
            button2.Name = "button2";
            button2.Size = new Size(103, 38);
            button2.TabIndex = 7;
            button2.Text = "Đăng ký";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(297, 319);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(142, 22);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxShowPassword.Location = new Point(724, 263);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(160, 32);
            checkBoxShowPassword.TabIndex = 9;
            checkBoxShowPassword.Text = "Hiện mật khẩu";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += CheckBoxShowPassword_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 564);
            Controls.Add(checkBoxShowPassword);
            Controls.Add(linkLabel1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Button button2;
        private LinkLabel linkLabel1;
        private CheckBox checkBox1;
        private CheckBox checkBoxShowPassword;
    }
}