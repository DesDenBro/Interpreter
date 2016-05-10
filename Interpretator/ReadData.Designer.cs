namespace Interpretator
{
    partial class ReadData
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
            this.Data_tb = new System.Windows.Forms.TextBox();
            this.Send_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Data_tb
            // 
            this.Data_tb.Location = new System.Drawing.Point(12, 29);
            this.Data_tb.Multiline = true;
            this.Data_tb.Name = "Data_tb";
            this.Data_tb.Size = new System.Drawing.Size(284, 77);
            this.Data_tb.TabIndex = 0;
            this.Data_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Data_tb_KeyPress);
            // 
            // Send_btn
            // 
            this.Send_btn.Location = new System.Drawing.Point(12, 112);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(284, 33);
            this.Send_btn.TabIndex = 1;
            this.Send_btn.Text = "Отправить";
            this.Send_btn.UseVisualStyleBackColor = true;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите число:";
            // 
            // ReadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.Data_tb);
            this.Name = "ReadData";
            this.Text = "Считывание числа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Data_tb;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.Label label1;
    }
}