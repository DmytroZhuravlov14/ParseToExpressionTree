using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq.Expressions;
using System.IO;

namespace ExpressionParser_v1._1
{
    static class Tokenizer
    {
        public static List<Model> objectList;

        static List<Parser> parsers = new List<Parser>
        {
            new Parser("^[0-9]{1,}[/.][0-9]{1,}", (value) => new Number{ Value = value }),
            new Parser("^[a-zA-Z]{1,}", (_) => new Parameter()),
            new Parser("^[/+]{1}", (_) => new Plus()),
            new Parser("^[/-]{1}", (_) => new Minus()),
            new Parser("^[/*]{1}", (_) => new Multiply()),
            new Parser("^:{1}", (_) => new Divide()),
            new Parser("^[/^]{1}", (_) => new Power()),
        };

        public static List<Model> Tokenize(string input)
        {
            string stringBuilder = new StringBuilder(input).ToString();
            List<Model> bagList = new List<Model>();
            while (stringBuilder != string.Empty)
            {
                Parser parser = parsers.Where(p => p._regex.Match(stringBuilder).Success).First();       
                Model dataBag = parser.Parse(stringBuilder);
                bagList.Add(dataBag);
                stringBuilder = stringBuilder.Remove(0, parser._regex.Match(stringBuilder).Value.Length);
                stringBuilder = Parser.DeleteWhiteSpace(stringBuilder);
            }
            return bagList;
        }
    }
}
