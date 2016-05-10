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
    public partial class ReadData : Form
    {
        public ReadData()
        {
            InitializeComponent();
        }

        string _number = "";
        public string Number { get { return _number; } }

        private void Data_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }

            if (e.KeyChar == '-')
            {
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    Send_btn.Focus();
                return;
            }

            e.Handled = true;
        }

        private void Send_btn_Click(object sender, EventArgs e)
        {
            _number = Data_tb.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}