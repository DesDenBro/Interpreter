using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretator
{
    public class Lexem
    {
        private string _name;
        private LexemAnalizator.Type _type;
        private int _linePos;
        private int _simbolPos;
        private int _index = -1;

        public string Name { get { return _name; } set { _name = value; } }
        public LexemAnalizator.Type Type { get { return _type; } set { _type = value; } }
        public int LinePos { get { return _linePos; } set { _linePos = value; } }
        public int SimbolPos { get { return _simbolPos; } set { _simbolPos = value; } }
        public int Index { get { return _index; } set { _index = value; } }
    }
}
