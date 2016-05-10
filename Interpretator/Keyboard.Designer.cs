namespace Interpretator
{
    partial class Keyboard
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
            this.Int_btn = new System.Windows.Forms.Button();
            this.IntM_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Not_btn = new System.Windows.Forms.Button();
            this.Or_btn = new System.Windows.Forms.Button();
            this.And_btn = new System.Windows.Forms.Button();
            this.NotEqual_btn = new System.Windows.Forms.Button();
            this.GreaterOrEqual_btn = new System.Windows.Forms.Button();
            this.LessOrEqual_btn = new System.Windows.Forms.Button();
            this.Equal_btn = new System.Windows.Forms.Button();
            this.Greater_btn = new System.Windows.Forms.Button();
            this.Less_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EndOfLine_btn = new System.Windows.Forms.Button();
            this.End_btn = new System.Windows.Forms.Button();
            this.Begin_btn = new System.Windows.Forms.Button();
            this.SquareBrackets_btn = new System.Windows.Forms.Button();
            this.RoundBrackets_btn = new System.Windows.Forms.Button();
            this.FigurBrackets_btn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Divide_btn = new System.Windows.Forms.Button();
            this.Multiply_btn = new System.Windows.Forms.Button();
            this.Minus_btn = new System.Windows.Forms.Button();
            this.Plus_btn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Gets_btn = new System.Windows.Forms.Button();
            this.Write_btn = new System.Windows.Forms.Button();
            this.Read_btn = new System.Windows.Forms.Button();
            this.While_btn = new System.Windows.Forms.Button();
            this.Else_btn = new System.Windows.Forms.Button();
            this.If_btn = new System.Windows.Forms.Button();
            this.Code_tb = new System.Windows.Forms.TextBox();
            this.Ready_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Int_btn
            // 
            this.Int_btn.Location = new System.Drawing.Point(6, 19);
            this.Int_btn.Name = "Int_btn";
            this.Int_btn.Size = new System.Drawing.Size(81, 23);
            this.Int_btn.TabIndex = 0;
            this.Int_btn.Text = "Int ◙";
            this.Int_btn.UseVisualStyleBackColor = true;
            this.Int_btn.Click += new System.EventHandler(this.Int_btn_Click);
            // 
            // IntM_btn
            // 
            this.IntM_btn.Location = new System.Drawing.Point(6, 49);
            this.IntM_btn.Name = "IntM_btn";
            this.IntM_btn.Size = new System.Drawing.Size(81, 23);
            this.IntM_btn.TabIndex = 1;
            this.IntM_btn.Text = "Int[ ] ◘";
            this.IntM_btn.UseVisualStyleBackColor = true;
            this.IntM_btn.Click += new System.EventHandler(this.IntM_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Int_btn);
            this.groupBox1.Controls.Add(this.IntM_btn);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Переменные";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Not_btn);
            this.groupBox2.Controls.Add(this.Or_btn);
            this.groupBox2.Controls.Add(this.And_btn);
            this.groupBox2.Controls.Add(this.NotEqual_btn);
            this.groupBox2.Controls.Add(this.GreaterOrEqual_btn);
            this.groupBox2.Controls.Add(this.LessOrEqual_btn);
            this.groupBox2.Controls.Add(this.Equal_btn);
            this.groupBox2.Controls.Add(this.Greater_btn);
            this.groupBox2.Controls.Add(this.Less_btn);
            this.groupBox2.Location = new System.Drawing.Point(9, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 141);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Условия";
            // 
            // Not_btn
            // 
            this.Not_btn.Location = new System.Drawing.Point(149, 20);
            this.Not_btn.Name = "Not_btn";
            this.Not_btn.Size = new System.Drawing.Size(67, 23);
            this.Not_btn.TabIndex = 8;
            this.Not_btn.Text = "Not ▬";
            this.Not_btn.UseVisualStyleBackColor = true;
            this.Not_btn.Click += new System.EventHandler(this.Not_btn_Click);
            // 
            // Or_btn
            // 
            this.Or_btn.Location = new System.Drawing.Point(77, 19);
            this.Or_btn.Name = "Or_btn";
            this.Or_btn.Size = new System.Drawing.Size(65, 23);
            this.Or_btn.TabIndex = 7;
            this.Or_btn.Text = "Or ‼";
            this.Or_btn.UseVisualStyleBackColor = true;
            this.Or_btn.Click += new System.EventHandler(this.Or_btn_Click);
            // 
            // And_btn
            // 
            this.And_btn.Location = new System.Drawing.Point(6, 19);
            this.And_btn.Name = "And_btn";
            this.And_btn.Size = new System.Drawing.Size(65, 23);
            this.And_btn.TabIndex = 6;
            this.And_btn.Text = "And §";
            this.And_btn.UseVisualStyleBackColor = true;
            this.And_btn.Click += new System.EventHandler(this.And_btn_Click);
            // 
            // NotEqual_btn
            // 
            this.NotEqual_btn.Location = new System.Drawing.Point(114, 108);
            this.NotEqual_btn.Name = "NotEqual_btn";
            this.NotEqual_btn.Size = new System.Drawing.Size(102, 23);
            this.NotEqual_btn.TabIndex = 5;
            this.NotEqual_btn.Text = "Not equal ╥";
            this.NotEqual_btn.UseVisualStyleBackColor = true;
            this.NotEqual_btn.Click += new System.EventHandler(this.NotEqual_btn_Click);
            // 
            // GreaterOrEqual_btn
            // 
            this.GreaterOrEqual_btn.Location = new System.Drawing.Point(114, 79);
            this.GreaterOrEqual_btn.Name = "GreaterOrEqual_btn";
            this.GreaterOrEqual_btn.Size = new System.Drawing.Size(102, 23);
            this.GreaterOrEqual_btn.TabIndex = 4;
            this.GreaterOrEqual_btn.Text = "Greater or equal ╠";
            this.GreaterOrEqual_btn.UseVisualStyleBackColor = true;
            this.GreaterOrEqual_btn.Click += new System.EventHandler(this.GreaterOrEqual_btn_Click);
            // 
            // LessOrEqual_btn
            // 
            this.LessOrEqual_btn.Location = new System.Drawing.Point(114, 49);
            this.LessOrEqual_btn.Name = "LessOrEqual_btn";
            this.LessOrEqual_btn.Size = new System.Drawing.Size(102, 23);
            this.LessOrEqual_btn.TabIndex = 3;
            this.LessOrEqual_btn.Text = "Less or equal ╣";
            this.LessOrEqual_btn.UseVisualStyleBackColor = true;
            this.LessOrEqual_btn.Click += new System.EventHandler(this.LessOrEqual_btn_Click);
            // 
            // Equal_btn
            // 
            this.Equal_btn.Location = new System.Drawing.Point(6, 108);
            this.Equal_btn.Name = "Equal_btn";
            this.Equal_btn.Size = new System.Drawing.Size(102, 23);
            this.Equal_btn.TabIndex = 2;
            this.Equal_btn.Text = "Equal ╬";
            this.Equal_btn.UseVisualStyleBackColor = true;
            this.Equal_btn.Click += new System.EventHandler(this.Equal_btn_Click);
            // 
            // Greater_btn
            // 
            this.Greater_btn.Location = new System.Drawing.Point(6, 79);
            this.Greater_btn.Name = "Greater_btn";
            this.Greater_btn.Size = new System.Drawing.Size(102, 23);
            this.Greater_btn.TabIndex = 1;
            this.Greater_btn.Text = "Greater ╟";
            this.Greater_btn.UseVisualStyleBackColor = true;
            this.Greater_btn.Click += new System.EventHandler(this.Greater_btn_Click);
            // 
            // Less_btn
            // 
            this.Less_btn.Location = new System.Drawing.Point(6, 49);
            this.Less_btn.Name = "Less_btn";
            this.Less_btn.Size = new System.Drawing.Size(102, 23);
            this.Less_btn.TabIndex = 0;
            this.Less_btn.Text = "Less ╢";
            this.Less_btn.UseVisualStyleBackColor = true;
            this.Less_btn.Click += new System.EventHandler(this.Less_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EndOfLine_btn);
            this.groupBox3.Controls.Add(this.End_btn);
            this.groupBox3.Controls.Add(this.Begin_btn);
            this.groupBox3.Controls.Add(this.SquareBrackets_btn);
            this.groupBox3.Controls.Add(this.RoundBrackets_btn);
            this.groupBox3.Controls.Add(this.FigurBrackets_btn);
            this.groupBox3.Location = new System.Drawing.Point(9, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 111);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Граничные знаки";
            // 
            // EndOfLine_btn
            // 
            this.EndOfLine_btn.Location = new System.Drawing.Point(114, 78);
            this.EndOfLine_btn.Name = "EndOfLine_btn";
            this.EndOfLine_btn.Size = new System.Drawing.Size(102, 24);
            this.EndOfLine_btn.TabIndex = 8;
            this.EndOfLine_btn.Text = "; (▓)";
            this.EndOfLine_btn.UseVisualStyleBackColor = true;
            this.EndOfLine_btn.Click += new System.EventHandler(this.EndOfLine_btn_Click);
            // 
            // End_btn
            // 
            this.End_btn.Location = new System.Drawing.Point(114, 49);
            this.End_btn.Name = "End_btn";
            this.End_btn.Size = new System.Drawing.Size(102, 23);
            this.End_btn.TabIndex = 7;
            this.End_btn.Text = "End ▲";
            this.End_btn.UseVisualStyleBackColor = true;
            this.End_btn.Click += new System.EventHandler(this.End_btn_Click);
            // 
            // Begin_btn
            // 
            this.Begin_btn.Location = new System.Drawing.Point(114, 19);
            this.Begin_btn.Name = "Begin_btn";
            this.Begin_btn.Size = new System.Drawing.Size(102, 23);
            this.Begin_btn.TabIndex = 6;
            this.Begin_btn.Text = "Begin ▼";
            this.Begin_btn.UseVisualStyleBackColor = true;
            this.Begin_btn.Click += new System.EventHandler(this.Begin_btn_Click);
            // 
            // SquareBrackets_btn
            // 
            this.SquareBrackets_btn.Location = new System.Drawing.Point(6, 77);
            this.SquareBrackets_btn.Name = "SquareBrackets_btn";
            this.SquareBrackets_btn.Size = new System.Drawing.Size(102, 25);
            this.SquareBrackets_btn.TabIndex = 4;
            this.SquareBrackets_btn.Text = "[ ] (▀ ▄)";
            this.SquareBrackets_btn.UseVisualStyleBackColor = true;
            this.SquareBrackets_btn.Click += new System.EventHandler(this.SquareBrackets_btn_Click);
            // 
            // RoundBrackets_btn
            // 
            this.RoundBrackets_btn.Location = new System.Drawing.Point(6, 49);
            this.RoundBrackets_btn.Name = "RoundBrackets_btn";
            this.RoundBrackets_btn.Size = new System.Drawing.Size(102, 23);
            this.RoundBrackets_btn.TabIndex = 2;
            this.RoundBrackets_btn.Text = "( ) (└ ┐)";
            this.RoundBrackets_btn.UseVisualStyleBackColor = true;
            this.RoundBrackets_btn.Click += new System.EventHandler(this.RoundBrackets_btn_Click);
            // 
            // FigurBrackets_btn
            // 
            this.FigurBrackets_btn.Location = new System.Drawing.Point(6, 19);
            this.FigurBrackets_btn.Name = "FigurBrackets_btn";
            this.FigurBrackets_btn.Size = new System.Drawing.Size(102, 23);
            this.FigurBrackets_btn.TabIndex = 0;
            this.FigurBrackets_btn.Text = "{ } (< >)";
            this.FigurBrackets_btn.UseVisualStyleBackColor = true;
            this.FigurBrackets_btn.Click += new System.EventHandler(this.FigurBrackets_btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Divide_btn);
            this.groupBox4.Controls.Add(this.Multiply_btn);
            this.groupBox4.Controls.Add(this.Minus_btn);
            this.groupBox4.Controls.Add(this.Plus_btn);
            this.groupBox4.Location = new System.Drawing.Point(112, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 81);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Операции";
            // 
            // Divide_btn
            // 
            this.Divide_btn.Location = new System.Drawing.Point(63, 49);
            this.Divide_btn.Name = "Divide_btn";
            this.Divide_btn.Size = new System.Drawing.Size(51, 23);
            this.Divide_btn.TabIndex = 3;
            this.Divide_btn.Text = "/ (↔)";
            this.Divide_btn.UseVisualStyleBackColor = true;
            this.Divide_btn.Click += new System.EventHandler(this.Divide_btn_Click);
            // 
            // Multiply_btn
            // 
            this.Multiply_btn.Location = new System.Drawing.Point(63, 19);
            this.Multiply_btn.Name = "Multiply_btn";
            this.Multiply_btn.Size = new System.Drawing.Size(51, 23);
            this.Multiply_btn.TabIndex = 2;
            this.Multiply_btn.Text = "* (↨)";
            this.Multiply_btn.UseVisualStyleBackColor = true;
            this.Multiply_btn.Click += new System.EventHandler(this.Multiply_btn_Click);
            // 
            // Minus_btn
            // 
            this.Minus_btn.Location = new System.Drawing.Point(6, 49);
            this.Minus_btn.Name = "Minus_btn";
            this.Minus_btn.Size = new System.Drawing.Size(51, 23);
            this.Minus_btn.TabIndex = 1;
            this.Minus_btn.Text = "- (↓)";
            this.Minus_btn.UseVisualStyleBackColor = true;
            this.Minus_btn.Click += new System.EventHandler(this.Minus_btn_Click);
            // 
            // Plus_btn
            // 
            this.Plus_btn.Location = new System.Drawing.Point(6, 19);
            this.Plus_btn.Name = "Plus_btn";
            this.Plus_btn.Size = new System.Drawing.Size(51, 23);
            this.Plus_btn.TabIndex = 0;
            this.Plus_btn.Text = "+ (↑)";
            this.Plus_btn.UseVisualStyleBackColor = true;
            this.Plus_btn.Click += new System.EventHandler(this.Plus_btn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Gets_btn);
            this.groupBox5.Controls.Add(this.Write_btn);
            this.groupBox5.Controls.Add(this.Read_btn);
            this.groupBox5.Controls.Add(this.While_btn);
            this.groupBox5.Controls.Add(this.Else_btn);
            this.groupBox5.Controls.Add(this.If_btn);
            this.groupBox5.Location = new System.Drawing.Point(10, 363);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 110);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Операторы";
            // 
            // Gets_btn
            // 
            this.Gets_btn.Location = new System.Drawing.Point(113, 79);
            this.Gets_btn.Name = "Gets_btn";
            this.Gets_btn.Size = new System.Drawing.Size(102, 23);
            this.Gets_btn.TabIndex = 5;
            this.Gets_btn.Text = "= (∟)";
            this.Gets_btn.UseVisualStyleBackColor = true;
            this.Gets_btn.Click += new System.EventHandler(this.Gets_btn_Click);
            // 
            // Write_btn
            // 
            this.Write_btn.Location = new System.Drawing.Point(113, 50);
            this.Write_btn.Name = "Write_btn";
            this.Write_btn.Size = new System.Drawing.Size(102, 23);
            this.Write_btn.TabIndex = 4;
            this.Write_btn.Text = "Write (◄)";
            this.Write_btn.UseVisualStyleBackColor = true;
            this.Write_btn.Click += new System.EventHandler(this.Write_btn_Click);
            // 
            // Read_btn
            // 
            this.Read_btn.Location = new System.Drawing.Point(113, 21);
            this.Read_btn.Name = "Read_btn";
            this.Read_btn.Size = new System.Drawing.Size(102, 23);
            this.Read_btn.TabIndex = 3;
            this.Read_btn.Text = "Read (►)";
            this.Read_btn.UseVisualStyleBackColor = true;
            this.Read_btn.Click += new System.EventHandler(this.Read_btn_Click);
            // 
            // While_btn
            // 
            this.While_btn.Location = new System.Drawing.Point(7, 79);
            this.While_btn.Name = "While_btn";
            this.While_btn.Size = new System.Drawing.Size(100, 23);
            this.While_btn.TabIndex = 2;
            this.While_btn.Text = "While (╓)";
            this.While_btn.UseVisualStyleBackColor = true;
            this.While_btn.Click += new System.EventHandler(this.While_btn_Click);
            // 
            // Else_btn
            // 
            this.Else_btn.Location = new System.Drawing.Point(7, 50);
            this.Else_btn.Name = "Else_btn";
            this.Else_btn.Size = new System.Drawing.Size(100, 23);
            this.Else_btn.TabIndex = 1;
            this.Else_btn.Text = "Else (╗)";
            this.Else_btn.UseVisualStyleBackColor = true;
            this.Else_btn.Click += new System.EventHandler(this.Else_btn_Click);
            // 
            // If_btn
            // 
            this.If_btn.Location = new System.Drawing.Point(7, 20);
            this.If_btn.Name = "If_btn";
            this.If_btn.Size = new System.Drawing.Size(100, 23);
            this.If_btn.TabIndex = 0;
            this.If_btn.Text = "If (╔)";
            this.If_btn.UseVisualStyleBackColor = true;
            this.If_btn.Click += new System.EventHandler(this.If_btn_Click);
            // 
            // Code_tb
            // 
            this.Code_tb.Location = new System.Drawing.Point(239, 12);
            this.Code_tb.Multiline = true;
            this.Code_tb.Name = "Code_tb";
            this.Code_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Code_tb.Size = new System.Drawing.Size(412, 461);
            this.Code_tb.TabIndex = 7;
            // 
            // Ready_btn
            // 
            this.Ready_btn.Location = new System.Drawing.Point(530, 479);
            this.Ready_btn.Name = "Ready_btn";
            this.Ready_btn.Size = new System.Drawing.Size(121, 29);
            this.Ready_btn.TabIndex = 8;
            this.Ready_btn.Text = "Готово";
            this.Ready_btn.UseVisualStyleBackColor = true;
            this.Ready_btn.Click += new System.EventHandler(this.Ready_btn_Click);
            // 
            // Keyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 514);
            this.Controls.Add(this.Ready_btn);
            this.Controls.Add(this.Code_tb);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Keyboard";
            this.Text = "Набор кода";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Int_btn;
        private System.Windows.Forms.Button IntM_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button NotEqual_btn;
        private System.Windows.Forms.Button GreaterOrEqual_btn;
        private System.Windows.Forms.Button LessOrEqual_btn;
        private System.Windows.Forms.Button Equal_btn;
        private System.Windows.Forms.Button Greater_btn;
        private System.Windows.Forms.Button Less_btn;
        private System.Windows.Forms.Button Not_btn;
        private System.Windows.Forms.Button Or_btn;
        private System.Windows.Forms.Button And_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button FigurBrackets_btn;
        private System.Windows.Forms.Button RoundBrackets_btn;
        private System.Windows.Forms.Button SquareBrackets_btn;
        private System.Windows.Forms.Button End_btn;
        private System.Windows.Forms.Button Begin_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Divide_btn;
        private System.Windows.Forms.Button Multiply_btn;
        private System.Windows.Forms.Button Minus_btn;
        private System.Windows.Forms.Button Plus_btn;
        private System.Windows.Forms.Button EndOfLine_btn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button While_btn;
        private System.Windows.Forms.Button Else_btn;
        private System.Windows.Forms.Button If_btn;
        private System.Windows.Forms.Button Write_btn;
        private System.Windows.Forms.Button Read_btn;
        private System.Windows.Forms.Button Gets_btn;
        private System.Windows.Forms.TextBox Code_tb;
        private System.Windows.Forms.Button Ready_btn;
    }
}