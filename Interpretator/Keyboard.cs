using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpretator
{
    public partial class Keyboard: Form
    {
        public Keyboard(string code)
        {
            InitializeComponent();
            _code = code;
            Code_tb.Text = _code;
        }

        string _code = "";
        public string Code { get { return _code; } }

        private void Int_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "◙ ");
        }

        private void IntM_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "◘ ");
        }

        private void Plus_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "↑");
        }

        private void Minus_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "↓");
        }

        private void Multiply_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "↨");
        }

        private void Divide_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "↔");
        }

        private void And_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "§");
        }

        private void Or_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "‼");
        }

        private void Not_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "▬");
        }

        private void Less_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╢");
        }

        private void Greater_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╟");
        }

        private void Equal_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╬");
        }

        private void LessOrEqual_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╣");
        }

        private void GreaterOrEqual_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╠");
        }

        private void NotEqual_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╥");
        }

        private void RoundBrackets_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "└┐");
        }

        private void FigurBrackets_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "<>");
        }

        private void SquareBrackets_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "▀▄");
        }

        private void Begin_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "▼");
        }

        private void End_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "▲");
        }

        private void EndOfLine_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "▓");
        }

        private void If_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╔ ");
        }

        private void Else_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╗");
        }

        private void While_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "╓ ");
        }

        private void Read_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "► ");
        }

        private void Write_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "◄ ");
        }

        private void Gets_btn_Click(object sender, EventArgs e)
        {
            Code_tb.Text = Code_tb.Text.Insert(Code_tb.SelectionStart, "∟ ");
        }

        private void Ready_btn_Click(object sender, EventArgs e)
        {
            _code = Code_tb.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
