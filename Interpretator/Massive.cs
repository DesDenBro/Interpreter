using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretator
{
    public class Massive
    {
        private string _name;
        private int[] _value;

        public string Name { get { return _name; } set { _name = value; } }
        public int[] Value { get { return _value; } set { _value = value; } }
    }
}
