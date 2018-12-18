using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    static class StaticMethodsExecution
    {
        public static Regex WriteRegex { get; set; } = new Regex("write:");

        public static int ReturnIndex(string path)
        {
            int result = 0;
            string[] textLines = File.ReadAllLines(path);
            for (int i = 0; i < textLines.Length; i++)
            {
                if (WriteRegex.Match(textLines[i]).Success)
                    result = i;
            }
            return result;
        }

        public static bool IsSuccess(string line)
        {
            return WriteRegex.Match(line).Success;
        }

        static string FindInput(string line)
        {
            Regex endRegex = new Regex("$");
            int endIndex = endRegex.Match(line).Index;
            string s = "";
            for (int i = WriteRegex.Match(line).Index + WriteRegex.Match(line).Length + 1; i < endIndex; i++)
            {
                s += line[i];
            }
            return s;
        }

        public static void WriteLineExpression(string path)
        {
            string input = FindInput(path);
            Expression callExpr = Expression.Call(null,
                            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                            Expression.Constant(input)
                        );
            Expression.Lambda<Action>(callExpr).Compile()();
        }
    }
}
