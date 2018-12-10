using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    static class Tokenizer
    {
        const string numberRegex = "^[0-9]{1,}[/.][0-9]{1,}";
        const string plusRegex = "^[/+]{1}";
        const string minusRegex = "^[/-]{1}";
        const string multiplyRegex = "^[/*]{1}";
        const string divisionRegex = "^:{1}";
        const string powerRegex = "^[/^]{1}";
        const string parameterRegex = "^[a-zA-Z]";

        public static List<Model> objectList = new List<Model> { };
        static Match match;

        static void DeleteWhiteSpace(ref string text)
        {
            if (text.Length > 1 && text[0] == ' ')
                text = text.Remove(0, 1);
        }

        static bool RecognizeType(string text, string regex, out Match match)
        {
            Regex regExpression = new Regex(regex);
            MatchCollection matches = regExpression.Matches(text);
            match = matches.Count > 0 ? matches[0] : null;
            return matches.Count > 0;
        }

        public static bool Tokenize(ref string text)
        {
            while (text.Length != 1)
            {
                if (RecognizeType(text, numberRegex, out match))
                {
                    objectList.Add(new Number { Value = Convert.ToDouble(match.Value) });
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, plusRegex, out match))
                {
                    objectList.Add(new Plus());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, minusRegex, out match))
                {
                    objectList.Add(new Minus());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, multiplyRegex, out match))
                {
                    objectList.Add(new Multiply());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, divisionRegex, out match))
                {
                    objectList.Add(new Divide());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, powerRegex, out match))
                {
                    objectList.Add(new Power());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                if (RecognizeType(text, parameterRegex, out match))
                {
                    objectList.Add(new Parameter());
                    if (text.Length != 0)
                        text = text.Remove(0, match.Length);
                    DeleteWhiteSpace(ref text);
                    Tokenize(ref text);
                }
                else
                {
                    if (text.Length == 0)
                        return true;
                }
            }
            return false;
        }
    }
}
