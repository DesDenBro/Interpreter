using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpretator
{
    class Realizer
    {
        public List<string> Result { get { return _result; } }

        Interpretator _inter;                          // Объект для обработки ОПС

        List<LexemString> _OPS;                        // Готовые ОПС и программы для них
        Stack<Lexem> _afterInter;                      // Результат ОПС и программа для выполнения
        Stack<Lexem> _conditions;                      // Стек открытых условий (if, else, while)
        List<While> _whiles;                           // Коллекция активных циклов While   
        List<string> _result;                          // Все результаты, выводимые интерпретатором через write 
        Stack<bool> _ifBool;                           // Булевы значения прочитанных if

        bool _stopTap = false;                         // Остановка реализации в связи с ошибкой исполнения
        bool _ifTap = true;                            // Условие работы If
        bool _lastIfCondition = true;                  // Состояние последнего закрытого If
        int _countOfOpenIfBracketBeforeFalseIf = 0;    // Колличество открытых скобок перед тем, как мы соскочили на else
        bool _whileTap = false;                        // При считывании While мы ничего не исполняем 
        int _indexTempWhile;                           // Хранение индекса while, который прорабатывается в данный момент 


        // Старт интепретатора
        public Realizer(List<LexemString> OPS, List<Number> numbers, List<Massive> massives)
        {
            _OPS = OPS;
            _conditions = new Stack<Lexem>();
            _ifBool = new Stack<bool>();
            _result = new List<string>();
            _whiles = new List<While>();
            _inter = new Interpretator(ref numbers, ref massives);

            for (int i = 0; i < _OPS.Count; i++)
            {
                if (!_stopTap)
                {
                    RealizeProgramm(_OPS[i]);
                }
                else return;

                if (_whiles.Count > 0)
                {
                    if (!_whiles[0].BracketsIsClosed)
                    {
                        if (_whiles[LastOpenedWhile()].Strings.Count != 0)
                        {
                            if (_whiles[LastOpenedWhile()].Active == true
                                 && !_whiles[LastOpenedWhile()].BracketsIsClosed
                                 && _OPS[i].String[0].Type != LexemAnalizator.Type.RightFigurBracket
                                 && _conditions.Count >= _whiles[LastOpenedWhile()].Strings[0].String[_whiles[LastOpenedWhile()].Strings[0].String.Count - 1].SimbolPos)
                            {
                                _whiles[LastOpenedWhile()].Strings.Add(_OPS[i]);
                            }
                        }
                        else
                        {
                            if (_whiles[LastOpenedWhile()].Active == true && !_whiles[LastOpenedWhile()].BracketsIsClosed)
                            {
                                _whiles[LastOpenedWhile()].Strings.Add(_OPS[i]);
                            }
                        }
                    }
                }

                // Если считывание while закончилось, то запускаем его до момента остановки активности
                if (_whiles.Count > 0 && _whiles[0].BracketsIsClosed)
                {
                    _whileTap = false;
                    ClearWhilesFromBruckets();
                    RealizeWhile(0);
                    _whiles.Clear();
                }   
            }
            return;
        }

        // Получаем результат ОПС и смотрим, есть ли для него подпрограмма
        private void CheckInProgram(LexemString checkingOPS)
        {
            _afterInter = new Stack<Lexem>();                   // Обнуляем прошлый результат
            LexemString tempLexStrForInter = new LexemString()  // Временная строка терминалов для последующей реализации
                 { String = new List<Lexem>() };

            // ↓ Кладется в стек
            Lexem tempResultInter = new Lexem();                // Результат, получившийся после работы интерпретатора с ОПС
            Lexem tempProgrammInCommand = new Lexem()           // Программа для обработки полученного результа (может и не быть)
                { Name = "", Type = LexemAnalizator.Type.Undefined };          
            // ↑

            for (int i = 0; i < checkingOPS.String.Count; i++)
            {
                switch (checkingOPS.String[i].Type)
                {
                    // Если находит хоть одну из программ для результата ОПС - запоминает ее
                    case LexemAnalizator.Type.Write:
                    case LexemAnalizator.Type.Read: 
                    case LexemAnalizator.Type.If: 
                    case LexemAnalizator.Type.Else:
                    case LexemAnalizator.Type.While: 
                    case LexemAnalizator.Type.IfWhile:
                    case LexemAnalizator.Type.InWhile:
                    case LexemAnalizator.Type.LeftFigurBracket:
                    case LexemAnalizator.Type.RightFigurBracket: tempProgrammInCommand = checkingOPS.String[i]; break;
                    // Иначе просто отправляет для последующей обработки итнерпретатором
                    default: tempLexStrForInter.String.Add(checkingOPS.String[i]); break;
                }
            }
            if (_whileTap || !_ifTap) // Нельзя что-то делать, если условие не выполняется на данном участке или идет считывание для цикла
                tempResultInter = _inter.ExecuteOPS(tempLexStrForInter, true);
            else
                tempResultInter = _inter.ExecuteOPS(tempLexStrForInter, false);

            if (tempResultInter.Name != "Error")
            {
                _afterInter.Push(tempResultInter);
                _afterInter.Push(tempProgrammInCommand);  
            }
            else _stopTap = true;          
        }

        // Вернуть последний НЕ ЗАКРЫТЫЙ while
        private int LastOpenedWhile()
        {
            for (int i = _whiles.Count - 1; i >= 0; i--)
            {
                if (_whiles[i].BracketsIsClosed == false)
                {
                    return i;
                }
            }
            return -1;
        }

        // Отчистка _whiles от фигурных скобок, обозначающих границы цикла
        private void ClearWhilesFromBruckets()
        {
            for (int i = 0; i < _whiles.Count; i++)
            {
                _whiles[i].Strings.RemoveAt(1);
                _whiles[i].Strings.RemoveAt(_whiles[i].Strings.Count - 1);
            }
        }

        // Запуск сохраненных _whiles
        private void RealizeWhile(int neededWhileIndex)
        {
            While tempWhile = new While();

            for (int i = 0; i < _whiles.Count; i++)
            {
                if (_whiles[i].Index == neededWhileIndex)
                {
                    tempWhile = _whiles[i];
                    break;
                }
            }

            tempWhile.Active = true;
            do
            {
                // Временное хранение индекса while, который используется именно сейчас
                _indexTempWhile = tempWhile.Index;
                for (int k = 0; k < tempWhile.Strings.Count; k++)
                {
                    if (tempWhile.Active)
                        RealizeProgramm(tempWhile.Strings[k]);
                }
            }
            while (tempWhile.Active);
        }

        // Реализациия программы
        private void RealizeProgramm(LexemString inOPS)
        {
            CheckInProgram(inOPS);
            if (_stopTap) return;

            Lexem result; int indexF = 0;
            Lexem program;
            program = _afterInter.Pop();
            result = _afterInter.Pop();
     
            if (program.Name != "")
            {
                // Если у нас if - false и не идет чтение ОПС в цикл
                if (!_ifTap && !_whileTap)
                {
                    if (program.Type == LexemAnalizator.Type.LeftFigurBracket)
                    {
                        _conditions.Push(new Lexem() { Name = "LeftFigurBracket", Type = LexemAnalizator.Type.LeftFigurBracket });
                    }
                    else
                    {
                        if (program.Type == LexemAnalizator.Type.RightFigurBracket)
                        {
                            _conditions.Pop();
                        }
                    }

                    if (_countOfOpenIfBracketBeforeFalseIf == _conditions.Count)
                    {
                        _ifTap = true;
                        if (_ifBool.Count > 0) _lastIfCondition = _ifBool.Pop();
                    }
                }
                else // Обычное выполнение или чтение строк в цикл
                {
                    switch (program.Type)
                    {
                        #region Write
                        case LexemAnalizator.Type.Write:
                            if (!_whileTap)
                            {
                                if (result.Type == LexemAnalizator.Type.Id)
                                {
                                    if ((indexF = _inter.FindNumber(result.Name)) != -1)
                                    {
                                        _result.Add(_inter.Numbers[indexF].Value.ToString());
                                    }
                                    else
                                    {
                                        if ((indexF = _inter.FindMassive(result.Name)) != -1)
                                        {
                                            _result.Add(_inter.Massives[indexF].Value[result.Index].ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if (result.Type == LexemAnalizator.Type.Num)
                                    {
                                        _result.Add(result.Name);
                                    }
                                }
                            }
                            break;
                        #endregion

                        #region Read
                        case LexemAnalizator.Type.Read:
                            if (!_whileTap)
                            {
                                ReadData rd = new ReadData();
                                rd.ShowDialog();
                                if (rd.DialogResult == DialogResult.OK)
                                {
                                    if (result.Type == LexemAnalizator.Type.Id)
                                    {
                                        if ((indexF = _inter.FindNumber(result.Name)) != -1)
                                        {
                                            _inter.Numbers[indexF].Value = Convert.ToInt32(rd.Number);
                                        }
                                        else
                                        {
                                            if ((indexF = _inter.FindMassive(result.Name)) != -1)
                                            {
                                                _inter.Massives[indexF].Value[result.Index] = Convert.ToInt32(rd.Number);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        #endregion

                        #region If
                        case LexemAnalizator.Type.If:
                            if (!_whileTap)
                            {
                                if (result.Name == "True" && result.Type == LexemAnalizator.Type.Boolean)
                                {
                                    _conditions.Push(new Lexem() { Name = "if", Type = LexemAnalizator.Type.If });
                                    _ifBool.Push(true);
                                    _countOfOpenIfBracketBeforeFalseIf++;

                                    _ifTap = true;
                                }
                                else
                                {
                                    if (result.Name == "False" && result.Type == LexemAnalizator.Type.Boolean)
                                    {
                                        _ifBool.Push(false);

                                        _ifTap = false;
                                    }
                                }
                            }
                            break;
                        #endregion

                        #region Else
                        case LexemAnalizator.Type.Else:
                            if (!_whileTap)
                            {
                                if (_lastIfCondition)
                                {
                                    // если if был True -  не выполняем else
                                    _ifTap = false;
                                }
                                else
                                {
                                    // если if был False - выполняем и записываем его в _confition
                                    _conditions.Push(new Lexem() { Name = "else", Type = LexemAnalizator.Type.Else });
                                    _countOfOpenIfBracketBeforeFalseIf++;

                                    _ifTap = true;
                                }
                            }
                            break;
                        #endregion

                        #region While
                        case LexemAnalizator.Type.While:
                            LexemString tempString = inOPS;
                            tempString.String[tempString.String.Count - 1].Name = "IfWhile";
                            tempString.String[tempString.String.Count - 1].Type = LexemAnalizator.Type.IfWhile;
                            tempString.String[tempString.String.Count - 1].SimbolPos = _conditions.Count;
                            // Вложенный
                            if (_whiles.Count > 0)
                            {
                                // Добавляем ссылку в последний открытый цикл на будущий while
                                _whiles[LastOpenedWhile()].Strings.Add(new LexemString()
                                {
                                    String = new List<Lexem>() {
                                    new Lexem() { Name = "InWhile", Type = LexemAnalizator.Type.InWhile, Index = _whiles.Count} }
                                });
                            }
                            _whiles.Add(new While() { Strings = new List<LexemString>(), BracketsIsClosed = false, Active = true, Index = _whiles.Count });
                            _whileTap = true;
                            break;
                        #endregion

                        #region IfWhile
                        case LexemAnalizator.Type.IfWhile:
                            if (result.Name == "False" && result.Type == LexemAnalizator.Type.Boolean)
                            {
                                _whiles[_indexTempWhile].Active = false;
                            }
                            break;
                        #endregion

                        #region InWhile
                        case LexemAnalizator.Type.InWhile:
                            RealizeWhile(program.Index);
                            break;
                        #endregion

                        #region LeftFigurBracket
                        case LexemAnalizator.Type.LeftFigurBracket:
                            if (_whileTap)
                            {
                                _conditions.Push(new Lexem() { Name = "LeftFigurBracket", Type = LexemAnalizator.Type.LeftFigurBracket });
                                _countOfOpenIfBracketBeforeFalseIf++;
                            }
                            break;
                        #endregion

                        #region RightFigurBracket
                        case LexemAnalizator.Type.RightFigurBracket:
                            _conditions.Pop();
                            while (_conditions.Count != _ifBool.Count && !_whileTap)
                            {
                                _lastIfCondition = _ifBool.Pop();
                            }
                            _countOfOpenIfBracketBeforeFalseIf--;
                            if (_whiles.Count > 0 && _whileTap)
                            {
                                if (_conditions.Count > _whiles[LastOpenedWhile()].Strings[0].String[_whiles[LastOpenedWhile()].Strings[0].String.Count - 1].SimbolPos)
                                {
                                    _whiles[LastOpenedWhile()].Strings.Add(new LexemString() { String = inOPS.String });
                                }
                                else
                                {
                                    if (_conditions.Count == _whiles[LastOpenedWhile()].Strings[0].String[_whiles[LastOpenedWhile()].Strings[0].String.Count - 1].SimbolPos)
                                    {
                                        _whiles[LastOpenedWhile()].Strings.Add(new LexemString() { String = inOPS.String });
                                        _whiles[LastOpenedWhile()].BracketsIsClosed = true;
                                    }
                                }
                            }
                            break;
                            #endregion
                    }
                }
            }
        }
    }
}
