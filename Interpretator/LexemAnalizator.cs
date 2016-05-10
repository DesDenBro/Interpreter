using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpretator
{
    public class LexemAnalizator
    {
        public List<Lexem> Lexems { get { return _lexems; } }
        public List<Number> Numbers { get { return _numbers; } }
        public List<Massive> Massives { get { return _massives; } }

        // Старт работы лексического анализатора
        public LexemAnalizator(string inputCode)
        {
            _originalCode = inputCode;
            if (_originalCode == "") return; // Ничего нет
            _state = 0;
            while (!_codeIsOver)
            {
                LexAnaliz();
            }
            return;
        }

        // Нахождение переменной по ее имени
        private int FindVariable(string name)
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                if (_numbers[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        // Нахождение массива по его имени
        private int FindMassive(string name)
        {
            for (int i = 0; i < _massives.Count; i++)
            {
                if (_massives[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        // Проверка на существание переменной/массива при использовании в коде
        private bool ThisVariableAlreadyExist(string name, Type type)
        {
            if (type == Type.Int)  if (FindVariable(name) >= 0) return true;
            if (type == Type.IntM) if (FindMassive(name) >= 0) return true;
            return false;
        }

        // Получить новый символ
        private char GetNewSimbol()
        {
            _numberSimbolNow++;
            _numberSimbolOnLine++;
            return _originalCode[_numberSimbolNow];
        }

        //Добавление лексемы
        private void AddNewLexemInLexems(string name, Type type, ref string wroteLexem)
        {
            if (wroteLexem != "" && type != Type.Id && type != Type.Num)
            {
                string numberOrWord = CheckNumberOrWord(wroteLexem);
                if (numberOrWord == "number")
                {
                    _lexems.Add(new Lexem() { Name = wroteLexem,
                                              Type = Type.Num,
                                              LinePos = _numberLineNow,
                                              SimbolPos = _numberSimbolOnLine });
                }
                else
                {
                    if (numberOrWord == "word")
                    {
                       _lexems.Add(new Lexem() { Name = wroteLexem,
                                                 Type = Type.Id,
                                                 LinePos = _numberLineNow,
                                                 SimbolPos = _numberSimbolOnLine });
                    }
                }
                
            }

            _lexems.Add(new Lexem() { Name = name,
                                      Type = type,
                                      LinePos = _numberLineNow,
                                      SimbolPos = _numberSimbolOnLine });
            wroteLexem = "";
            
        }

        // Проверка на то, является ли лексема числом или словом
        private string CheckNumberOrWord(string original)
        {
            int temp;
            bool isNum = int.TryParse(original, out temp);
            if (isNum) return "number";
            else return "word";
        }

        // Переход к следующей строке в коде
        private void GoToNextLine()
        {
            _numberLineNow++;
            _numberSimbolNow += 2;
            _numberSimbolOnLine = 0;
        }

        // Получение ASCII кода по символу
        private int GetASCIICode(char original)
        {
            switch (original)
            {
                case '╔': return 201; 
                case '╗': return 187; 
                case '╓': return 214;  
                case '►': return 16;  
                case '◄': return 17;   
                case '◙': return 10;   
                case '◘': return 8;   
                case '▼': return 31;   
                case '▲': return 30;   
                case '§': return 21;   
                case '‼': return 19;   
                case '▬': return 22;   
                case '<': return 60;  
                case '>': return 62;   
                case '└': return 192;  
                case '┐': return 191;  
                case '▀': return 223;  
                case '▄': return 220;  
                case '╢': return 182;  
                case '╟': return 199;  
                case '╬': return 206;  
                case '╣': return 185;  
                case '╠': return 204;  
                case '╥': return 210;  
                case '∟': return 28;   
                case '↑': return 24;   
                case '↓': return 25;  
                case '↔': return 29;   
                case '↨': return 23;   

                case '▓': return 178;
                case ' ': return 32;
            }
            if ((int)original > 255) return 0;

            return (int)original;
        }

        // Наложение команд подпрограмм на таблицу ASCII (256)
        int[] _tableASCII = new int[] { 0,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 9 , 0 , 8 ,
            0 , 0 , 0 , 0 , 0 , 6 , 7,  0 , 13, 0 ,
            12, 14, 31, 28, 29, 0 , 0 , 27, 30, 11,
            10, 33, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 2 , 2 , 2 ,
            2 , 2 , 2 , 2 , 2 , 2 , 2 , 0 , 0 , 15,
            0 , 16, 0 , 0 , 1 , 1 , 1 , 1 , 1 , 1 ,
            1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,
            1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,
            0 , 0 , 0 , 0 , 0 , 0 , 1 , 1 , 1 , 1 ,
            1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,
            1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 ,
            1 , 1 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 32, 0 , 0 ,
            0 , 21, 0 , 0 , 24, 0 , 4 , 0 , 0 , 0 ,
            18, 17, 0 , 0 , 0 , 0 , 0 , 0 , 22, 0 ,
            3 , 0 , 0 , 25, 0 , 23, 0 , 0 , 0 , 26,
            0 , 0 , 0 , 5 , 0 , 0 , 0 , 0 , 0 , 20,
            0 , 0 , 19, 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
            0 , 0 , 0 , 0 , 0
        };
            
        // Таблица переходов
        int[,] _programs = new int[,] 
        {
               // ERR   ID     NUM    If     Else   While  Read   Write  Int    IntM   Begin   End    And    Or     Not    {      }      (       )      [       ]      <      >      ==     <=     >=     !=     =      +      -      /      *     ;      " "
 /*Read*/       { -1,   10,     20,   30,    40,    50,    60,    70,    80,    90,    100,    110,   0,     0,     0,     150,   160,   170,    180,   190,    200,   0,     0,     0,     0,     0,     0,     270,   280,   290,  300,   310,   320,   330 } ,
 /*Int var*/    { -1,   10,     0,    0,     0,     0,     0,     0,     0,     0,     0,      0,     0,     0,     0,     0,     0,     0,      0,     0,      0,     0,     0,     0,     0,     0,     0,     270,   0,     0,    0,     0,     321,   331 } ,
 /*Mass var*/   { -1,   10,     0,    0,     0,     0,     0,     0,     0,     0,     0,      0,     0,     0,     0,     0,     0,     0,      0,     0,      0,     0,     0,     0,     0,     0,     0,     270,   0,     0,    0,     0,     322,   332 } ,
 /*Gets*/       { -1,   10,     20,   0,     0,     0,     0,     0,     0,     0,     0,      0,     0,     0,     0,     0,     0,     170,    180,   191,    201,   0,     0,     0,     0,     0,     0,     270,   0,     0,    0,     0,     323,   333 } ,
 /*Logical*/    { -1,   10,     20,   0,     0,     0,     0,     0,     0,     0,     0,      0,     120,   130,   140,   150,   160,   170,    180,   190,    200,   210,   220,   230,   240,   250,   260,   0,     280,   290,  300,   310,   0,     330 }
        };

        public enum Type
        {
            // Все данные типы соотносятся с номерами подпрограмм
            // Получив номер подпрограммы из таблицы TableASCII можно вызвать ее и исполнить, переслав в массив _programs, который смотри на state
            //   Название     |    ASCII и смысл     | Подпрограмма  | LexAnaliz | SyntAnaliz | Interpretator | 
            Id,                 // Индетификатор       1 (a-z, A-Z)       +            +             +              
            Num,                // Целое число         2 (0-9)            +            +             +              
            If,                 // ╔ (201) Если	       3                  +            +             +              
            Else,               // ╗ (187) Иначе	   4                  +            +             +              
            While,              // ╓ (214) Пока	       5                  +            +             +          
            IfWhile,            // Условие цикла       -                  -            -             +              
            InWhile,            // Внутренний while    -                  -            -             +
            Read,               // ► (16)  Ввод  	   6                  +            +             +             
            Write,              // ◄ (17)  Вывод	   7                  +            +             +              
            Int,                // ◙ (10)  Int		   8                  +            -             -              
            IntM,               // ◘ (8)   Массив      9                  +            -             -              
            Begin,              // ▼ (31)  Старт	   10                 +            +             -              
            End,                // ▲ (30)  Конец	   11                 +            +             -              
            And,                // § (21)  И		   12                 +            +             +              
            Or,                 // ‼ (19)  Или		   13                 +            +             +              
            Not,                // ▬ (22)  Не		   14                 +            +             +             
            LeftFigurBracket,   // < (60)  {           15                 +            +             +              
            RightFigurBracket,  // > (62)  }           16                 +            +             +              
            LeftRoundBracket,   // └ (192) (		   17                 +            +             -              
            RightRoundBracket,  // ┐ (191) )		   18                 +            +             -             
            LeftSquareBracket,  // ▀ (223) [		   19                 +            +             -              
            RightSquareBracket, // ▄ (220) ]		   20                 +            +             -              
            Less,               // ╢ (182) <		   21                 +            +             +              
            Greater,            // ╟ (199) >		   22                 +            +             +              
            Equal,              // ╬ (206) ==		   23                 +            +             +              
            LessOrEqual,        // ╣ (185) <=		   24                 +            +             +              
            GreaterOrEqual,     // ╠ (204) >=		   25                 +            +             +              
            NotEqual,           // ╥ (210) !=		   26                 +            +             +              
            Gets,               // ∟ (28)  Присв. 	   27                 +            +             +              
            Plus,               // ↑ (24)  +		   28                 +            +             +              
            Minus,              // ↓ (25)  -		   29                 +            +             +              
            Divide,             // ↔ (29)  /		   30                 +            +             +              
            Multiply,           // ↨ (23)  *		   31                 +            +             +              

            EndOfLine,          // ▓ (178) ;		   32                 +            -             -              
            Eof,                // Конец файла         -                  +            -             -              
            Undefined,          // Неопределен         -                  -            +             +              
            Boolean             // true или false      -                  -            -             +              
            // Пробел           // Пробел              33                 +            -             -              

            // Обозначения:
            //   +   - сделано
            //   -   - не используется в данном участке программы
        }

        string _originalCode = "";    // Исходный код
        List<Lexem> _lexems = new List<Lexem>();        // Набор ВСЕХ лексем
        List<Number> _numbers = new List<Number>();     // Переменные
        List<Massive> _massives = new List<Massive>();  // Массивы
        int _numberSimbolNow = -1;     // Считываемый символ
        int _numberSimbolOnLine = 1;   // Символ на строке
        int _numberLineNow = 1;        // Считываемая линия
        int _state = -1;               // Состояния: 
                                       // 0 - просто считывание, 
                                       // 1 - распознование int, 
                                       // 2 - распознование массива int, 
                                       // 3 - присвоение 
                                       // 4 - логические скобки
        bool _bracketForLogic = false; // Скобки для распознования условий
        string _newVariableName = "";  // Имя новой переменной
        string _newNumber = "";        // Новое считываемое число
        string _newLexemName = "";     // Новая лексема
        bool _programmWork = false;    // True в отрезке между Begin и End
        bool _codeIsOver = false;      // Конец исходного кода достигнут
        int _countOfOpenLogicakBrackets = 0;  // Количество открытых скобок логических выражений

        private void LexAnaliz()
        {
            char simbolNow = GetNewSimbol();
            switch (_programs[_state, _tableASCII[GetASCIICode(simbolNow)]])
            {
                #region Int
                case 80: // Int
                    AddNewLexemInLexems("int", Type.Int, ref _newLexemName);
                    _state = 1;
                    break;
                #endregion

                #region IntM
                case 90: // IntM
                    AddNewLexemInLexems("array", Type.IntM, ref _newLexemName);
                    _state = 2;
                    break;
                #endregion

                #region Simbols
                case 10: // Simbols
                    _newVariableName += simbolNow;
                    _newLexemName += simbolNow;
                    break;
                #endregion

                #region Numbers
                case 20: // Numbers
                    _newNumber += simbolNow;
                    _newLexemName += simbolNow;
                    break;
                #endregion

                #region Space " "
                case 330:
                    if (_newLexemName != "")
                    {
                        string numberOrWord = CheckNumberOrWord(_newLexemName);
                        if (numberOrWord == "number")
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Num, ref _newLexemName);
                        }
                        else
                        {
                            if (numberOrWord == "word")
                            {
                                if (_programmWork &&
                                    (ThisVariableAlreadyExist(_newLexemName, Type.Int) ||
                                        ThisVariableAlreadyExist(_newLexemName, Type.IntM)))
                                {
                                    AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);
                                }
                                else
                                {
                                    MessageBox.Show("Введенной переменной не существует");
                                    _codeIsOver = true;
                                }
                            }
                        }
                    }

                    if (_programmWork)
                    {
                        _newNumber = "";
                        _newVariableName = "";
                    }
                    break;

                case 331:
                    if (_newVariableName != "")
                    {
                        if (!ThisVariableAlreadyExist(_newLexemName, Type.Int))
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);

                            _numbers.Add(new Number() { Name = _newVariableName, Value = 0 });
                        }
                        else
                        {
                            MessageBox.Show("Такая переменная уже существует");
                            _codeIsOver = true;
                        }
                    }

                    if (_programmWork)
                    {
                        _newNumber = "";
                        _newVariableName = "";
                    }
                    break;

                case 332: 
                    if (_newVariableName != "")
                    {
                        if (!ThisVariableAlreadyExist(_newLexemName, Type.IntM))
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);

                            _massives.Add(new Massive() { Name = _newVariableName });
                        }
                        else
                        {
                            MessageBox.Show("Такой массив уже существует");
                            _codeIsOver = true;
                        }
                    }

                    if (_programmWork)
                    {
                        _newNumber = "";
                        _newVariableName = "";
                    }
                    break;

                case 333:
                    if (_newNumber != "")
                    {
                        _numbers[FindVariable(_newVariableName)].Value = Convert.ToInt32(_newNumber);
                        AddNewLexemInLexems(_newNumber, Type.Num, ref _newLexemName);

                        _newNumber = "";
                    }

                    if (_programmWork)
                    {
                        _newNumber = "";
                        _newVariableName = "";
                    }
                    break;
                #endregion

                #region EndOfLine ;
                case 320: 
                    if (_newLexemName != "")
                    {
                        string numberOrWord = CheckNumberOrWord(_newLexemName);
                        if (numberOrWord == "number")
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Num, ref _newLexemName);
                        }
                        else
                        {
                            if (numberOrWord == "word")
                            {
                                if (_programmWork &&
                                    (ThisVariableAlreadyExist(_newLexemName, Type.Int) ||
                                        ThisVariableAlreadyExist(_newLexemName, Type.IntM)))
                                {
                                    AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);
                                }
                                else
                                {
                                    MessageBox.Show("Введенной переменной не существует");
                                    _codeIsOver = true;
                                }
                            }
                        }
                    }

                    _state = 0;
                    _newNumber = "";
                    _newVariableName = "";

                    AddNewLexemInLexems(";", Type.EndOfLine, ref _newLexemName);

                    GoToNextLine();
                    break;

                case 321:
                    if (_newVariableName != "")
                    {
                        if (!ThisVariableAlreadyExist(_newLexemName, Type.Int))
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);

                            _numbers.Add(new Number() { Name = _newVariableName, Value = 0 });
                        }
                        else
                        {
                            MessageBox.Show("Такая переменная уже существует");
                            _codeIsOver = true;
                        }
                    }

                    
                    _state = 0;
                    _newNumber = "";
                    _newVariableName = "";

                    AddNewLexemInLexems(";", Type.EndOfLine, ref _newLexemName);

                    GoToNextLine();
                    break;

                case 322:
                    if (_newVariableName != "")
                    {
                        if (!ThisVariableAlreadyExist(_newLexemName, Type.IntM))
                        {
                            AddNewLexemInLexems(_newLexemName, Type.Id, ref _newLexemName);

                            _massives.Add(new Massive() { Name = _newVariableName });
                        }
                        else
                        {
                            MessageBox.Show("Такой массив уже существует");
                            _codeIsOver = true;
                        }
                    }

                    
                    _state = 0;
                    _newNumber = "";
                    _newVariableName = "";

                    AddNewLexemInLexems(";", Type.EndOfLine, ref _newLexemName);

                    GoToNextLine();
                    break;

                case 323:
                    if (_newNumber != "")
                    {
                        _numbers[FindVariable(_newVariableName)].Value = Convert.ToInt32(_newNumber);
                        AddNewLexemInLexems(_newNumber, Type.Num, ref _newLexemName);

                        _newNumber = "";
                    }

                    _state = 0;
                    _newNumber = "";
                    _newVariableName = "";

                    AddNewLexemInLexems(";", Type.EndOfLine, ref _newLexemName);

                    GoToNextLine();
                    break;

                #endregion

                #region If 
                case 30: // if
                    AddNewLexemInLexems("if", Type.If, ref _newLexemName);
                    _bracketForLogic = true; // Требуется описание логики в скобках ( )
                    _state = 4;
                    break;
                #endregion

                #region Else
                case 40: // else
                    AddNewLexemInLexems("else", Type.Else, ref _newLexemName);

                    GoToNextLine();
                    break;
                #endregion

                #region While
                case 50: // while
                    AddNewLexemInLexems("while", Type.While, ref _newLexemName);
                    _bracketForLogic = true; // Требуется описание логики в скобках ( )
                    _state = 4;
                    break;
                #endregion

                #region Read
                case 60: // read
                    AddNewLexemInLexems("read", Type.Read, ref _newLexemName);
                    break;
                #endregion

                #region Write
                case 70: // write
                    AddNewLexemInLexems("write", Type.Write, ref _newLexemName);
                    break;
                #endregion

                #region And &&
                case 120: // &&
                    AddNewLexemInLexems("&&", Type.And, ref _newLexemName);
                    break;
                #endregion

                #region Or ||
                case 130: // ||
                    AddNewLexemInLexems("||", Type.Or, ref _newLexemName);
                    break;
                #endregion

                #region Not !
                case 140: // !
                    AddNewLexemInLexems("!", Type.Not, ref _newLexemName);
                    break;
                #endregion

                #region LeftFigurBracket {
                case 150: // {
                    AddNewLexemInLexems("{", Type.LeftFigurBracket, ref _newLexemName);
                    _state = 0;
                    GoToNextLine();

                    break;
                #endregion

                #region RightFigurBracket }
                case 160: // }
                    AddNewLexemInLexems("}", Type.RightFigurBracket, ref _newLexemName);

                    GoToNextLine();
                    break;
                #endregion

                #region LeftRoundBracket (
                case 170: // (
                    AddNewLexemInLexems("(", Type.LeftRoundBracket, ref _newLexemName);
                    _countOfOpenLogicakBrackets++;
                    break;
                #endregion

                #region RightRoundBracket )
                case 180: // ) 
                    AddNewLexemInLexems(")", Type.RightRoundBracket, ref _newLexemName);
                    if (_bracketForLogic && _countOfOpenLogicakBrackets - 1 == 0)
                    {
                        _countOfOpenLogicakBrackets--;
                        _bracketForLogic = false;
                        GoToNextLine();
                    }
                    else
                    {
                        _countOfOpenLogicakBrackets--;
                    }
                    break;
                #endregion

                #region LeftSquareBracket [
                case 190: // [
                    if (!_programmWork)
                    {
                        AddNewLexemInLexems("[", Type.LeftSquareBracket, ref _newLexemName);
                    }
                    else
                    {
                        if (ThisVariableAlreadyExist(_newLexemName, Type.IntM))
                        {
                            AddNewLexemInLexems("[", Type.LeftSquareBracket, ref _newLexemName);
                        }
                        else
                        {
                            MessageBox.Show("Заданного массива не существует");
                            _codeIsOver = true;
                        }
                    }      
                    break;

                case 191:
                    if (!_programmWork)
                    {
                        AddNewLexemInLexems("[", Type.LeftSquareBracket, ref _newLexemName);
                        _newNumber = "";
                    }
                    else
                    {
                        if (ThisVariableAlreadyExist(_newLexemName, Type.IntM))
                        {
                            AddNewLexemInLexems("[", Type.LeftSquareBracket, ref _newLexemName);
                            _newNumber = "";
                        }
                        else
                        {
                            MessageBox.Show("Заданного массива не существует");
                            _codeIsOver = true;
                        }
                    }
                    break;
                #endregion

                #region RightSquareBracket ]
                case 200: // ]
                    if (!_programmWork)
                    {
                        MessageBox.Show("Чет ты не то делаешь, объявление массива должно сопровождаться числом, а тут просто скобки");
                        _codeIsOver = true;
                        return;
                    }

                    AddNewLexemInLexems("]", Type.RightSquareBracket, ref _newLexemName);
                    break;

                case 201: // ]
                    if (!_programmWork)
                    {
                        _massives[FindMassive(_newVariableName)].Value = new int[Convert.ToInt32(_newNumber)];
                        AddNewLexemInLexems(_newNumber, Type.Num, ref _newLexemName);

                        _newNumber = "";
                    }

                    AddNewLexemInLexems("]", Type.RightSquareBracket, ref _newLexemName);
                    break;
                #endregion

                #region Less <
                case 210: // <
                    AddNewLexemInLexems("<", Type.Less, ref _newLexemName);
                    break;
                #endregion

                #region Greater >
                case 220: // >
                    AddNewLexemInLexems(">", Type.Greater, ref _newLexemName);
                    break;
                #endregion

                #region Equal ==
                case 230: // == 
                    AddNewLexemInLexems("==", Type.Equal, ref _newLexemName);
                    break;
                #endregion

                #region LessOrEqual <=
                case 240: // <=
                    AddNewLexemInLexems("<=", Type.LessOrEqual, ref _newLexemName);
                    break;
                #endregion

                #region GreaterOrEqual >=
                case 250: // >=
                    AddNewLexemInLexems(">=", Type.GreaterOrEqual, ref _newLexemName);
                    break;
                #endregion

                #region NotEqual !=
                case 260: // 
                    AddNewLexemInLexems("!=", Type.NotEqual, ref _newLexemName);
                    break;
                #endregion

                #region Gets =
                case 270: // =
                    AddNewLexemInLexems("=", Type.Gets, ref _newLexemName);

                    if (!_programmWork) _state = 3;
                    break;
                #endregion

                #region Plus +
                case 280: // +
                    AddNewLexemInLexems("+", Type.Plus, ref _newLexemName);
                    break;
                #endregion

                #region Minus -
                case 290: // -
                    AddNewLexemInLexems("-", Type.Minus, ref _newLexemName);
                    break;
                #endregion

                #region Divide /
                case 300: // /
                    AddNewLexemInLexems("/", Type.Divide, ref _newLexemName);
                    break;
                #endregion

                #region Multliply *
                case 310: // *
                    AddNewLexemInLexems("*", Type.Multiply, ref _newLexemName);
                    break;
                #endregion

                #region Begin
                case 100: // begin
                    AddNewLexemInLexems("begin", Type.Begin, ref _newLexemName);

                    GoToNextLine();
                    _programmWork = true;
                    break;
                #endregion

                #region End
                case 110: //end
                    AddNewLexemInLexems("end", Type.End, ref _newLexemName);

                    _numberSimbolNow += 1;
                    _numberSimbolOnLine = 1;

                    AddNewLexemInLexems("EOF", Type.Eof, ref _newLexemName);

                    _programmWork = false;
                    _codeIsOver = true;
                    break;
                #endregion

                #region ErrorInSyntax
                case 0:
                    _codeIsOver = true;
                    MessageBox.Show("Неправильное использование символа " + (char)simbolNow + " в строке " + _numberLineNow);
                    break;
                #endregion

                #region Other Simbols
                case -1:
                    _codeIsOver = true;
                    if (simbolNow == '\r')
                    {
                        if (_countOfOpenLogicakBrackets > 0)
                            MessageBox.Show("Логическая скобка не закрыта.");
                        else
                            if (_state == 4)
                                MessageBox.Show("Неправильно выполнена конструкция if/while.");
                            else
                                MessageBox.Show("Пропущена точка с запятой.");
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный символ " + (char)simbolNow);
                    }
                    return;
                #endregion
            }
        }
    }
}