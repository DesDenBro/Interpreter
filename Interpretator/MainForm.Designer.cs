namespace Interpretator
{
    partial class MainForm
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
            this.OriginalCode_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.LexAnaliz_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SyntaxAnaliz_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Result_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Keyboard_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OriginalCode_tb
            // 
            this.OriginalCode_tb.Location = new System.Drawing.Point(12, 30);
            this.OriginalCode_tb.Multiline = true;
            this.OriginalCode_tb.Name = "OriginalCode_tb";
            this.OriginalCode_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OriginalCode_tb.Size = new System.Drawing.Size(247, 488);
            this.OriginalCode_tb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходный код:";
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(184, 524);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(75, 33);
            this.Start_btn.TabIndex = 2;
            this.Start_btn.Text = "Запуск";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // LexAnaliz_tb
            // 
            this.LexAnaliz_tb.Location = new System.Drawing.Point(277, 30);
            this.LexAnaliz_tb.Multiline = true;
            this.LexAnaliz_tb.Name = "LexAnaliz_tb";
            this.LexAnaliz_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LexAnaliz_tb.Size = new System.Drawing.Size(266, 527);
            this.LexAnaliz_tb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Лексический анализатор:";
            // 
            // SyntaxAnaliz_tb
            // 
            this.SyntaxAnaliz_tb.Location = new System.Drawing.Point(562, 30);
            this.SyntaxAnaliz_tb.Multiline = true;
            this.SyntaxAnaliz_tb.Name = "SyntaxAnaliz_tb";
            this.SyntaxAnaliz_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SyntaxAnaliz_tb.Size = new System.Drawing.Size(266, 527);
            this.SyntaxAnaliz_tb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Синтаксический анализатор:";
            // 
            // Result_tb
            // 
            this.Result_tb.Location = new System.Drawing.Point(847, 30);
            this.Result_tb.Multiline = true;
            this.Result_tb.Name = "Result_tb";
            this.Result_tb.Size = new System.Drawing.Size(266, 527);
            this.Result_tb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Конечный результат:";
            // 
            // Keyboard_btn
            // 
            this.Keyboard_btn.Location = new System.Drawing.Point(86, 524);
            this.Keyboard_btn.Name = "Keyboard_btn";
            this.Keyboard_btn.Size = new System.Drawing.Size(92, 33);
            this.Keyboard_btn.TabIndex = 9;
            this.Keyboard_btn.Text = "Набор кода";
            this.Keyboard_btn.UseVisualStyleBackColor = true;
            this.Keyboard_btn.Click += new System.EventHandler(this.Keyboard_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Location = new System.Drawing.Point(12, 524);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(68, 33);
            this.Clear_btn.TabIndex = 10;
            this.Clear_btn.Text = "Отчистка";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 569);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Keyboard_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Result_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SyntaxAnaliz_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LexAnaliz_tb);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OriginalCode_tb);
            this.Name = "MainForm";
            this.Text = "Интерпретатор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OriginalCode_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.TextBox LexAnaliz_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SyntaxAnaliz_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Result_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Keyboard_btn;
        private System.Windows.Forms.Button Clear_btn;
    }
}

