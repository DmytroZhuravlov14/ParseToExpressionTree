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
            string text = File.ReadAllText(@"C:/Users/user/Expression.txt");
            Tokenizer.Tokenize(ref text);
            VariableAssigner.AssignVariables(12.0, 145.123);
            PriorityAssigner.AssignPriorities();
            Aggregator.Aggregate();
            var expression = Tokenizer.objectList.FirstOrDefault();
            Console.WriteLine(Expression.Lambda<Func<double>>(expression.ToExpression()).Compile()());
        }
    }
}
