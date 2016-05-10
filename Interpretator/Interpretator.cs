using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpretator
{
    class Interpretator
    {
        public List<Number> Numbers { get { return _numbers; } set { _numbers = value; } }
        public List<Massive> Massives { get { return _massives; } set { _massives = value; } }

        List<Number> _numbers;      // Переменные, используемые программой
        List<Massive> _massives;    // Массивы, используемые программой
        Lexem _tempLexem;           // Временная лексема для хранения кончесного результата
        bool _onlyRead = false;     // Режим только для чтения

        // Старт интепретатора
        public Interpretator(ref List<Number> numbers, ref List<Massive> massives)
        {
            _numbers = numbers;
            _massives = massives;
            return;
        }

        // Подготовка к решению ОПС
        public Lexem ExecuteOPS(LexemString inOPS, bool onlyRead)
        {
            _tempLexem = new Lexem() { Name = "", Type = LexemAnalizator.Type.Undefined };
            _onlyRead = onlyRead;
            AnalizOPS(inOPS);
            return _tempLexem;
        }

        // Поиск требуемой переменной
        public int FindNumber(string name)
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                if (_numbers[i].Name == name) return i;
            }

            return -1;
        }

        // Поиск требуемого массива
        public int FindMassive(string name)
        {
            for (int i = 0; i < _massives.Count; i++)
            {
                if (_massives[i].Name == name) return i;
            }

            return -1;
        }

        // state может принимать 9 состояний:
        // 1: ID(var) - ID(var)
        // 2: ID(var) - ID(mas)
        // 3: ID(mas) - ID(var)
        // 4: ID(mas) - ID(mas)
        // 5: ID(var) - NUM
        // 6: ID(mas) - NUM
        // 7: NUM     - ID(var)
        // 8: NUM     - ID(mas)
        // 9: NUM     - NUM
        // где ID - название переменной/массива, NUM - число, var - значение из переменной, mas - значение из ячейки массива 
        
        #region Арифметические операторы
        // Выполнение операции плюс
        private void Plus(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            switch (state)
            {
                case 1:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) +
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 2:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) +
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 3:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) +
                                        Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 4:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) +
                                            Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 5:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) +
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 6:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) +
                                        Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 7:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) +
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 8:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) +
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 9:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) +
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;
            }
        }

        // Выполнение операции минус
        private void Minus(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            switch (state)
            {
                case 1:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) -
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 2:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) -
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 3:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) -
                                        Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 4:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) -
                                            Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 5:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) -
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 6:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) -
                                        Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 7:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) -
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 8:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) -
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 9:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) -
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;
            }
        }

        // Выполнение операции умножение
        private void Multiply(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            switch (state)
            {
                case 1:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) *
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 2:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) *
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 3:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) *
                                        Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 4:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) *
                                            Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 5:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) *
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 6:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) *
                                        Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 7:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) *
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 8:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) *
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 9:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) *
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;
            }
        }

        // Выполнение операции деление
        private void Divide(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            switch (state)
            {
                case 1:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) /
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 2:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) /
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 3:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) /
                                        Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 4:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) /
                                            Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 5:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_numbers[indexF].Value) /
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 6:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(_massives[indexF].Value[first.Index]) /
                                        Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 7:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) /
                                    Convert.ToInt32(_numbers[indexS].Value)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 8:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) /
                                        Convert.ToInt32(_massives[indexS].Value[second.Index])).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;

                case 9:
                    tempLexStack.Push(new Lexem()
                    {
                        Name = (Convert.ToInt32(first.Name) /
                                    Convert.ToInt32(second.Name)).ToString(),
                        Type = LexemAnalizator.Type.Num
                    });
                    break;
            }
        }
        #endregion

        #region Логические операторы
        // Меньше
        private void Less(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) < Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) < Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) < Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) < Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) < (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) < Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) < Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) < Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) < Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }

        // Больше
        private void Greater(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) > Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) > Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) > Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) > Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) > (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) > Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) > Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) > Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) > Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }

        // Равно
        private void Equal(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) == Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) == Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) == Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) == Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) == (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) == Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) == Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) == Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) == Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }

        // Меньше или равно
        private void LessOrEqual(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) <= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) <= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) <= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) <= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) <= (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) <= Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) <= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) <= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) <= Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }

        // Больше или равно
        private void GreaterOrEqual(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) >= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) >= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) >= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) >= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) >= (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) >= Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) >= Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) >= Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) >= Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }

        // Не равно
        private void NotEqual(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, int state)
        {
            bool logical = false;
            switch (state)
            {
                case 1:
                    if (Convert.ToInt32(_numbers[indexF].Value) != Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 2:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(_numbers[indexF].Value) != Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 3:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) != Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 4:
                    if (first.Index >= 0 && second.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) != Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 5:
                    if (Convert.ToInt32(_numbers[indexF].Value) != (Convert.ToInt32(second.Name))) logical = true;
                    break;

                case 6:
                    if (first.Index >= 0)
                        if (Convert.ToInt32(_massives[indexF].Value[first.Index]) != Convert.ToInt32(second.Name)) logical = true;
                    break;

                case 7:
                    if (Convert.ToInt32(first.Name) != Convert.ToInt32(_numbers[indexS].Value)) logical = true;
                    break;

                case 8:
                    if (second.Index >= 0)
                        if (Convert.ToInt32(first.Name) != Convert.ToInt32(_massives[indexS].Value[second.Index])) logical = true;
                    break;

                case 9:
                    if (Convert.ToInt32(first.Name) != Convert.ToInt32(second.Name)) logical = true;
                    break;
            }
            tempLexStack.Push(new Lexem()
            {
                Name = logical.ToString(),
                Type = LexemAnalizator.Type.Boolean
            });
        }
        #endregion

        // Выполнение заданной операции
        private void Operation(ref Stack<Lexem> tempLexStack, ref Lexem first, ref int indexF, ref Lexem second, ref int indexS, string operation)
        {
            if (first.Type == LexemAnalizator.Type.Id)
            {
                if ((indexF = FindNumber(first.Name)) != -1)
                {
                    if (second.Type == LexemAnalizator.Type.Id)
                    {
                        if ((indexS = FindNumber(second.Name)) != -1)
                        {
                            switch (operation)
                            {
                                case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;

                                case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                                case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 1); break;
                            }
                        }
                        else
                        {
                            if ((indexS = FindMassive(second.Name)) != -1)
                            {
                                switch (operation)
                                {
                                    case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;

                                    case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                    case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 2); break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (second.Type == LexemAnalizator.Type.Num)
                        {
                            switch (operation)
                            {
                                case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;

                                case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                                case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 5); break;
                            }
                        }
                    }
                }
                else
                {
                    if ((indexF = FindMassive(first.Name)) != -1)
                    {
                        if (second.Type == LexemAnalizator.Type.Id)
                        {
                            if ((indexS = FindNumber(second.Name)) != -1)
                            {
                                switch (operation)
                                {
                                    case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;

                                    case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                    case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 3); break;
                                }
                            }
                            else
                            {
                                if ((indexS = FindMassive(second.Name)) != -1)
                                {
                                    switch (operation)
                                    {
                                        case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;

                                        case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                        case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 4); break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (second.Type == LexemAnalizator.Type.Num)
                            {
                                switch (operation)
                                {
                                    case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;

                                    case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                    case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 6); break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (first.Type == LexemAnalizator.Type.Num)
                {
                    if (second.Type == LexemAnalizator.Type.Id)
                    {
                        if ((indexS = FindNumber(second.Name)) != -1)
                        {
                            switch (operation)
                            {
                                case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;

                                case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                                case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 7); break;
                            }
                        }
                        else
                        {
                            if ((indexS = FindMassive(second.Name)) != -1)
                            {
                                switch (operation)
                                {
                                    case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;

                                    case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                    case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 8); break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (second.Type == LexemAnalizator.Type.Num)
                        {
                            switch (operation)
                            {
                                case "Plus": Plus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "Minus": Minus(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "Multiply": Multiply(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "Divide": Divide(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;

                                case "Less": Less(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "Greater": Greater(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "Equal": Equal(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "LessOrEqual": LessOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "GreaterOrEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                                case "NotEqual": GreaterOrEqual(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, 9); break;
                            }
                        }
                    }
                }
            }
        }

        // Реализациия ОПС
        private void AnalizOPS(LexemString inOPS)
        {
            Lexem first; int indexF = 0;                    // Первый элемент операции
            Lexem second; int indexS = 0;                   // Второй эелемент операции
            Stack<Lexem> tempLexStack = new Stack<Lexem>(); // Временнй стек для хранения терминалов, содержащихся в ОПС

            for (int i = 0; i < inOPS.String.Count; i++)
            {
                switch (inOPS.String[i].Type)
                {
                    #region ID
                    case LexemAnalizator.Type.Id:
                        tempLexStack.Push(inOPS.String[i]);
                        break;
                    #endregion

                    #region NUM
                    case LexemAnalizator.Type.Num:
                        tempLexStack.Push(inOPS.String[i]);
                        break;
                    #endregion

                    #region And &&
                    case LexemAnalizator.Type.And:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        if ((second.Name == first.Name) && (first.Name == "True") &&
                            (first.Type == LexemAnalizator.Type.Boolean) && (second.Type == LexemAnalizator.Type.Boolean))
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "True",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        else
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "False",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        break;
                    #endregion

                    #region Or ||
                    case LexemAnalizator.Type.Or:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        if (((second.Name == "True") || (first.Name == "True")) &&
                            (first.Type == LexemAnalizator.Type.Boolean) && (second.Type == LexemAnalizator.Type.Boolean))
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "True",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        else
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "False",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        break;
                    #endregion

                    #region Not !
                    case LexemAnalizator.Type.Not:
                        first = tempLexStack.Pop();

                        if ((first.Name == "True") && (first.Type == LexemAnalizator.Type.Boolean))
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "False",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        else
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = "True",
                                Type = LexemAnalizator.Type.Boolean
                            });
                        }
                        break;
                    #endregion

                    #region Less <
                    case LexemAnalizator.Type.Less:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Less");
                        break;
                    #endregion

                    #region Greater >
                    case LexemAnalizator.Type.Greater:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Greater");
                        break;
                    #endregion

                    #region Equal ==
                    case LexemAnalizator.Type.Equal:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Equal");
                        break;
                    #endregion

                    #region LessOrEqual >
                    case LexemAnalizator.Type.LessOrEqual:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "LessOrEqual");
                        break;
                    #endregion

                    #region GreaterOrEqual >
                    case LexemAnalizator.Type.GreaterOrEqual:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "GreaterOrEqual");
                        break;
                    #endregion

                    #region NotEqual >
                    case LexemAnalizator.Type.NotEqual:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "NotEqual");
                        break;
                    #endregion

                    #region Gets =
                    case LexemAnalizator.Type.Gets:
                        if (!_onlyRead)
                        {
                            second = tempLexStack.Pop(); // Присваиваемый элемент
                            first = tempLexStack.Pop();  // Куда присваивается

                            // Место, куда присваивается значение - переменная
                            if ((indexF = FindNumber(first.Name)) != -1)
                            {
                                if (second.Type == LexemAnalizator.Type.Id)
                                {
                                    // Присваиваемый элемент - переменная
                                    if ((indexS = FindNumber(second.Name)) != -1)
                                    {
                                        _numbers[indexF].Value = _numbers[indexS].Value;
                                    }
                                    else
                                    {
                                        // Присваиваемый элемент - массив
                                        if ((indexS = FindMassive(second.Name)) != -1)
                                        {
                                            _numbers[indexF].Value = _massives[indexS].Value[second.Index];
                                        }
                                    }
                                }
                                else
                                {
                                    if (second.Type == LexemAnalizator.Type.Num)
                                    {
                                        _numbers[indexF].Value = Convert.ToInt32(second.Name);
                                    }
                                }

                            }
                            else
                            {
                                // Место, куда присваивается значение - элемент массива
                                if ((indexF = FindMassive(first.Name)) != -1)
                                {
                                    if (second.Type == LexemAnalizator.Type.Id)
                                    {
                                        // Присваиваемый элемент - переменная
                                        if ((indexS = FindNumber(second.Name)) != -1)
                                        {
                                            _massives[indexF].Value[first.Index] = _numbers[indexS].Value;
                                        }
                                        else
                                        {
                                            // Присваиваемый элемент - массив
                                            if ((indexS = FindMassive(second.Name)) != -1)
                                            {
                                                _massives[indexF].Value[first.Index] = _massives[indexS].Value[second.Index];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (second.Type == LexemAnalizator.Type.Num)
                                        {
                                            _massives[indexF].Value[first.Index] = Convert.ToInt32(second.Name);
                                        }
                                    }

                                }
                            }
                        }
                        break;
                    #endregion

                    #region Plus +
                    case LexemAnalizator.Type.Plus:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Plus");
                        break;
                    #endregion

                    #region Minus -
                    case LexemAnalizator.Type.Minus:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Minus");
                        break;
                    #endregion

                    #region Multiply *
                    case LexemAnalizator.Type.Multiply:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Multiply");
                        break;
                    #endregion

                    #region Divide /
                    case LexemAnalizator.Type.Divide:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        #region Проверка на деление на нуль
                        if (second.Type == LexemAnalizator.Type.Id)
                        {
                            if ((indexS = FindNumber(second.Name)) != -1)
                            {
                                if (_numbers[indexS].Value == 0)
                                {
                                    MessageBox.Show("Деление на 0");
                                    _tempLexem = new Lexem() { Name = "Error", Type = LexemAnalizator.Type.Undefined };
                                    return;
                                }
                            }
                            else
                            {
                                if ((indexS = FindMassive(second.Name)) != -1)
                                {
                                    if (_massives[indexS].Value[second.Index] == 0)
                                    {
                                        MessageBox.Show("Деление на 0");
                                        _tempLexem = new Lexem() { Name = "Error", Type = LexemAnalizator.Type.Undefined };
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (second.Type == LexemAnalizator.Type.Num)
                            {
                                if (second.Name == "0")
                                {
                                    MessageBox.Show("Деление на 0");
                                    _tempLexem = new Lexem() { Name = "Error", Type = LexemAnalizator.Type.Undefined };
                                    return;
                                }
                            }
                        }
                        #endregion

                        Operation(ref tempLexStack, ref first, ref indexF, ref second, ref indexS, "Divide");
                        break;
                    #endregion

                    #region Undefined
                    case LexemAnalizator.Type.Undefined:
                        second = tempLexStack.Pop();
                        first = tempLexStack.Pop();

                        if (second.Type == LexemAnalizator.Type.Num)
                        {
                            tempLexStack.Push(new Lexem()
                            {
                                Name = first.Name,
                                Type = LexemAnalizator.Type.Id,
                                Index = Convert.ToInt32(second.Name)
                            });
                        }
                        else
                        {
                            if (second.Type == LexemAnalizator.Type.Id)
                            {
                                if ((indexS = FindNumber(second.Name)) != -1)
                                {
                                    tempLexStack.Push(new Lexem()
                                    {
                                        Name = first.Name,
                                        Type = LexemAnalizator.Type.Id,
                                        Index = Convert.ToInt32(_numbers[indexS].Value)
                                    });
                                }
                            }
                        }


                        break;
                        #endregion
                }
            }

            // Если что-то осталось после всех операций - перекидываем назад к вызывающему методу
            // В основном нам нужны True и False, остальные не имеют важности
            if (tempLexStack.Count > 0)
            {
                _tempLexem = tempLexStack.Pop();
            }
        }
    }
}
