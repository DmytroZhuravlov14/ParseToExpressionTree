using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string path = @"C:/Users/user/Expression.txt";
            string text = File.ReadAllText(path);

            string[] textLines = File.ReadAllLines(path);
            for (int i = 0; i < textLines.Length; i++)
            {
                if(StaticMethodsExecution.IsSuccess(textLines[i]))
                    StaticMethodsExecution.WriteLineExpression(textLines[i]);
                else
                {
                    Tokenizer.objectList = Tokenizer.Tokenize(textLines[i]);
                    VariableAssigner.AssignVariables(12.0, 145.123);
                    PriorityAssigner.AssignPriorities();
                    Aggregator.Aggregate();
                    var expression = Tokenizer.objectList.FirstOrDefault();
                    Console.WriteLine(Expression.Lambda<Func<double>>(expression.ToExpression()).Compile()());
                }
            }
        }
    }
}
