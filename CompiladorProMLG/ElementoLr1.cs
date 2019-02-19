using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorProMLG
{
    public class ElementoLr1
    {
        public string key;
        public string value;
        public char token;

        public ElementoLr1(string in_key, string in_value, char in_token)
        {
            key = in_key;
            value = in_value;
            token = in_token;
        }

        public int GetDotLocation()
        {
            int idx = value.ToList().FindIndex(query => query == '.');
            if (idx == value.ToList().Count - 1)
                idx = -1; //ultimo
            return idx;
        }

        public string SimpleToString() => key + "->" + value;

        public override string ToString() => key + "->" + value + "," + token;

    }
}