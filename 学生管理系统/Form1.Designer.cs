﻿namespace 学生管理系统
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.showView = new System.Windows.Forms.ListView();
            this.Sno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ssex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sdept = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "学生选课系统";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // showView
            // 
            this.showView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sno,
            this.Sname,
            this.Ssex,
            this.Sage,
            this.Sdept});
            this.showView.HideSelection = false;
            this.showView.Location = new System.Drawing.Point(35, 191);
            this.showView.Name = "showView";
            this.showView.Size = new System.Drawing.Size(611, 337);
            this.showView.TabIndex = 1;
            this.showView.UseCompatibleStateImageBehavior = false;
            this.showView.View = System.Windows.Forms.View.Details;
            this.showView.SelectedIndexChanged += new System.EventHandler(this.showView_SelectedIndexChanged);
            // 
            // Sno
            // 
            this.Sno.DisplayIndex = 1;
            this.Sno.Text = "Sno";
            this.Sno.Width = 118;
            // 
            // Sname
            // 
            this.Sname.DisplayIndex = 0;
            this.Sname.Text = "Sname";
            this.Sname.Width = 103;
            // 
            // Ssex
            // 
            this.Ssex.Text = "Ssex";
            this.Ssex.Width = 122;
            // 
            // Sage
            // 
            this.Sage.Text = "Sage";
            this.Sage.Width = 128;
            // 
            // Sdept
            // 
            this.Sdept.Text = "Sdept";
            this.Sdept.Width = 346;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "修改数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "增加数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(662, 452);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 53);
            this.button3.TabIndex = 4;
            this.button3.Text = "删除数据";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(624, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 44);
            this.button4.TabIndex = 5;
            this.button4.Text = "查找学生";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(393, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 28);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sno";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 599);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showView);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView showView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader Sno;
        private System.Windows.Forms.ColumnHeader Sname;
        private System.Windows.Forms.ColumnHeader Ssex;
        private System.Windows.Forms.ColumnHeader Sage;
        private System.Windows.Forms.ColumnHeader Sdept;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}

