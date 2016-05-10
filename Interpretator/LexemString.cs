using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretator
{
    public class LexemString
    {
        private List<Lexem> _string;
        public List<Lexem> String { get { return _string; } set { _string = value; } }
    }
}
