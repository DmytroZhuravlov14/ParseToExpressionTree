using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Manager
    {
        public static void Manage(string path)
        {
            string[] textLines = FileReader.Read(path);
            for (int i = 0; i < textLines.Length; i++)
            {
                if (StaticMethodsExecution.IsSuccess(textLines[i]))
                    StaticMethodsExecution.WriteLineExpression(textLines[i]);
                else
                {
                    List <Model> ObjectList = Tokenizer.Tokenize(textLines[i]);
                    Model model = LambdaTreeBuilder.Build(ObjectList);
                    Console.WriteLine(Expression.Lambda<Func<double>>(model.ToExpression()).Compile()());
                }
            }
        }
    }
}
