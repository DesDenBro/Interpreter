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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        LexemAnalizator _lex;
        SyntaxAnalizator _syn;
        Realizer _realiz;

        // Тест с 4 while, 2 if и 2 else
        private void test()
        {
            int i = 0, m = 10, x = 0, y = 0, z = 0;

            while (i < 5)
            {
                while (x < 4)
                {
                    x++;
                    z++;
                    while (y < 3)
                    {
                        y++;
                        if (i == 1)
                        {
                            z++;
                            if (z > 20)
                            {
                                z += 3;
                            }
                            else
                            {
                                while (m > 0)
                                {
                                    m--;
                                    z++;
                                }
                                m = 10;

                            }
                        }
                        else
                        {
                            z--;
                        }
                    }
                    y = 0;
                }
                x = 0;
                y = 0;
                i++;
            }

            Result_tb.Text += "\r\n" + i + "\r\n" + x + "\r\n" + y + "\r\n" + z;
        }

        // Показать результаты работы лексического анализатора
        private void ShowLexAnalizResult(LexemAnalizator lexem)
        {
            LexAnaliz_tb.Text = "Лексемы:\r\n";
            for (int i = 0; i < lexem.Lexems.Count; i++)
            {
                LexAnaliz_tb.Text += lexem.Lexems[i].Name + " " +
                                  "Линия: " + lexem.Lexems[i].LinePos + " " +
                                  "Номер: " + lexem.Lexems[i].SimbolPos + " " +
                                  "Тип: " + lexem.Lexems[i].Type + "\r\n";
            }
            LexAnaliz_tb.Text += "\r\nПеременные:\r\n";
            for (int i = 0; i < lexem.Numbers.Count; i++)
            {
                LexAnaliz_tb.Text += lexem.Numbers[i].Name + " - " + lexem.Numbers[i].Value + "\r\n";
            }
            LexAnaliz_tb.Text += "Массивы:\r\n";
            for (int i = 0; i < lexem.Massives.Count; i++)
            {
                LexAnaliz_tb.Text += lexem.Massives[i].Name + " - ";
                for (int j = 0; j < lexem.Massives[i].Value.Length; j++)
                {
                    LexAnaliz_tb.Text += lexem.Massives[i].Value[j] + " ";
                }
            }
        }

        // Показать результаты работы синтаксического анализатора
        private void ShowSyntaxAnalizResult(SyntaxAnalizator syntax)
        {
            SyntaxAnaliz_tb.Text = "Созданные ОПС на основе исходных лексем:\r\n";
            for (int i = 0; i < syntax.OPS.Count; i++)
            {
                for (int j = 0; j < syntax.OPS[i].String.Count; j++)
                {
                    SyntaxAnaliz_tb.Text += syntax.OPS[i].String[j].Name + " ";
                }
                SyntaxAnaliz_tb.Text += "\r\n";
            }
        }

        // Показать результаты работы интерпертатора
        private void ShowRealizerResult(Realizer interpretator)
        {
            Result_tb.Text = "";
            for (int i = 0; i < interpretator.Result.Count; i++)
            {
                Result_tb.Text += interpretator.Result[i] + "\r\n";
            }
            test();
        }

        // Кнопка старта
        private void Start_btn_Click(object sender, EventArgs e)
        {
            _lex = new LexemAnalizator(OriginalCode_tb.Text);
            ShowLexAnalizResult(_lex);

            _syn = new SyntaxAnalizator(_lex.Lexems);
            ShowSyntaxAnalizResult(_syn);

            _realiz = new Realizer(_syn.OPS, _lex.Numbers, _lex.Massives);
            ShowRealizerResult(_realiz);
        }

        // Вызов клавиатуры
        private void Keyboard_btn_Click(object sender, EventArgs e)
        {
            Keyboard kb = new Keyboard(OriginalCode_tb.Text);
            kb.ShowDialog();
            if (kb.DialogResult == DialogResult.OK)
            {
                OriginalCode_tb.Text = kb.Code;
            }
        }

        // Отчистка текстбоксов
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            OriginalCode_tb.Text = "";
            LexAnaliz_tb.Text = "";
            SyntaxAnaliz_tb.Text = "";
            Result_tb.Text = "";
        }
    }
}