using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretator
{
    public class While
    {
        List<LexemString> _strings;
        bool _active = false;
        bool _bracetsIsClosed = false;
        int _index;

        public List<LexemString> Strings { get { return _strings; } set { _strings = value; } }
        public bool Active { get { return _active; } set { _active = value; } }
        public bool BracketsIsClosed { get { return _bracetsIsClosed; } set { _bracetsIsClosed = value; } }
        public int Index { get { return _index; } set { _index = value; } }
    }
}
