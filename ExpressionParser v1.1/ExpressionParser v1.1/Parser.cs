using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExpressionParser_v1._1
{
    class Parser
    {
        public Regex _regex { get; set; }
        public Func<String, Model> _creator { get; set; }

        public Parser(string regex, Func<String, Model> creator)
        {
            _regex = new Regex(regex);
            _creator = creator;
        }

        public Model Parse(string input)
        {
            if(_regex.Match(input).Success)
            {
                return _creator(_regex.Match(input).Value);
            }
            return null;
        }
    }
}
