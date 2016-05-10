using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretator
{
    class SyntaxAnalizator
    {
        public List<LexemString> OPS { get { return _OPS; } }

        public SyntaxAnalizator(List<Lexem> lexems)
        {
            CreateTemplateForOPS(lexems);

            for (int i = 0; i < _originalLexems.Count; i++)
            {
                _OPS.Add(new LexemString() { String = CreateOPS(_originalLexems[i].String) });
            }
            
            return;
        }

        List<LexemString> _originalLexems = new List<LexemString>(); // Оригинальные строки лексем
        List<LexemString> _OPS = new List<LexemString>();            // Набор преобразованных в ОПС строк

        // Проверка на то, является ли лексема последней в строке
        public bool LexemIsLast(LexemString lexString, Lexem lex)
        {
            if (lexString.String[lexString.String.Count - 1].Name == lex.Name)
            {
                return true;
            }

            return false;
        }

        // Приоритет символа
        private int GetPriority(LexemAnalizator.Type type)
        {
            switch (type)
            {
                case LexemAnalizator.Type.Num: return 0;
                case LexemAnalizator.Type.Id: return 0;

                case LexemAnalizator.Type.Multiply: return 2;
                case LexemAnalizator.Type.Divide: return 2;

                case LexemAnalizator.Type.Plus: return 3;
                case LexemAnalizator.Type.Minus: return 3;

                case LexemAnalizator.Type.LeftSquareBracket: return 4;
                case LexemAnalizator.Type.RightSquareBracket: return 4;

                case LexemAnalizator.Type.Less: return 5;
                case LexemAnalizator.Type.Greater: return 5;
                case LexemAnalizator.Type.Equal: return 5;
                case LexemAnalizator.Type.LessOrEqual: return 5;
                case LexemAnalizator.Type.GreaterOrEqual: return 5;
                case LexemAnalizator.Type.NotEqual: return 5;

                case LexemAnalizator.Type.And: return 6;
                case LexemAnalizator.Type.Or: return 6;
                case LexemAnalizator.Type.Not: return 6;

                case LexemAnalizator.Type.LeftRoundBracket: return 7;
                case LexemAnalizator.Type.RightRoundBracket: return 7; 

                case LexemAnalizator.Type.If: return 8;
                case LexemAnalizator.Type.While: return 8;
                case LexemAnalizator.Type.Gets: return 8;
                case LexemAnalizator.Type.Write: return 8;
                case LexemAnalizator.Type.Read: return 8;

                default: return 9;
            }
        }

        // Преобразование лексем для обработки в вид ОПС
        private void CreateTemplateForOPS(List<Lexem> lexems)
        {
            bool programIsBegin = false;
            int numberOfLine = 1;
            List<Lexem> line = new List<Lexem>();
            for (int i = 0; i < lexems.Count; i++)
            {
                if (!programIsBegin)
                {
                    if (lexems[i].Name == "begin")
                    {
                        programIsBegin = true;
                        numberOfLine = lexems[i].LinePos + 1;
                    }
                }
                else
                {
                    if (lexems[i].Name != "EOF")
                    {
                        if (numberOfLine == lexems[i].LinePos)
                        {

                            line.Add(lexems[i]);
                        }
                        else
                        {
                            _originalLexems.Add(new LexemString() { String = line });
                            line = new List<Lexem>();
                            line.Add(lexems[i]);
                            numberOfLine = lexems[i].LinePos;
                        }
                    }
                }
            }
        }

        // Составление ОПС
        private List<Lexem> CreateOPS(List<Lexem> original)
        {
            Stack<Lexem> stackOperations = new Stack<Lexem>();
            List<Lexem> tempOPS = new List<Lexem>();

            Lexem tempForBracket;      // Переменная для проверки вытащенного элемента из стека
            int tempLengthOfStack = 0; // Первоначальная длина стека до первого .Pop();

            for (int i = 0; i < original.Count; i++)
            {
                switch (original[i].Type)
                {
                    #region ID
                    case LexemAnalizator.Type.Id:
                        tempOPS.Add(original[i]);
                        break;
                    #endregion

                    #region NUM
                    case LexemAnalizator.Type.Num:
                        tempOPS.Add(original[i]);
                        break;
                    #endregion

                    #region If
                    case LexemAnalizator.Type.If:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region Else 
                    case LexemAnalizator.Type.Else:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region While
                    case LexemAnalizator.Type.While:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region Read
                    case LexemAnalizator.Type.Read:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region Write
                    case LexemAnalizator.Type.Write:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region LeftFigurBracket
                    case LexemAnalizator.Type.LeftFigurBracket:
                        tempOPS.Add(original[i]);
                        break;
                    #endregion

                    #region RightFigurBracket
                    case LexemAnalizator.Type.RightFigurBracket:
                        tempOPS.Add(original[i]);
                        break;
                    #endregion

                    #region LeftRoundBracket
                    case LexemAnalizator.Type.LeftRoundBracket:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region RightRoundBracket
                    case LexemAnalizator.Type.RightRoundBracket:
                        do
                        {
                            tempForBracket = stackOperations.Pop();
                            if (tempForBracket.Type != LexemAnalizator.Type.LeftRoundBracket)
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                break;
                            }
                        }
                        while (true);
                        break;
                    #endregion

                    #region LeftSquareBracket
                    case LexemAnalizator.Type.LeftSquareBracket:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion

                    #region RightSquareBracket
                    case LexemAnalizator.Type.RightSquareBracket:
                        do
                        {
                            tempForBracket = stackOperations.Pop();
                            if (tempForBracket.Type != LexemAnalizator.Type.LeftSquareBracket)
                            {
                                tempOPS.Add(tempForBracket);                            
                            }
                            else
                            {
                                tempOPS.Add(new Lexem() { Name = "<index>", Type = LexemAnalizator.Type.Undefined });
                                break;
                            }
                        }
                        while (true);
                        break;
                    #endregion

                    #region And 
                    case LexemAnalizator.Type.And:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.And) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Or
                    case LexemAnalizator.Type.Or:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Or) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Not
                    case LexemAnalizator.Type.Not:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Not) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Less
                    case LexemAnalizator.Type.Less:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Less) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Greater
                    case LexemAnalizator.Type.Greater:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Greater) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Equal
                    case LexemAnalizator.Type.Equal:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Equal) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region LessOrEqual
                    case LexemAnalizator.Type.LessOrEqual:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.LessOrEqual) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region GreaterOrEqual
                    case LexemAnalizator.Type.GreaterOrEqual:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.GreaterOrEqual) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region NotEqual
                    case LexemAnalizator.Type.NotEqual:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.NotEqual) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Plus +
                    case LexemAnalizator.Type.Plus:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Plus) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Minus -
                    case LexemAnalizator.Type.Minus:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Minus) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Divide /
                    case LexemAnalizator.Type.Divide:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Divide) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Multiply *
                    case LexemAnalizator.Type.Multiply:
                        tempLengthOfStack = stackOperations.Count;
                        for (int j = 0; j < tempLengthOfStack; j++)
                        {
                            tempForBracket = stackOperations.Pop();
                            if (GetPriority(LexemAnalizator.Type.Multiply) > GetPriority(tempForBracket.Type))
                            {
                                tempOPS.Add(tempForBracket);
                            }
                            else
                            {
                                stackOperations.Push(tempForBracket);
                                stackOperations.Push(original[i]);
                                break;
                            }
                        }
                        break;
                    #endregion

                    #region Gets =
                    case LexemAnalizator.Type.Gets:
                        stackOperations.Push(original[i]);
                        break;
                    #endregion
                }
            }

            // В конце строки выбрасываем остатки из стека
            tempLengthOfStack = stackOperations.Count;
            for (int j = 0; j < tempLengthOfStack; j++)
            {
                tempOPS.Add(stackOperations.Pop());
            }

            return tempOPS;
        }
    }
}
