using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.IO;

namespace ExpressionParser_v1._1
{
    class Manager
    {
        private Tokenizer _tokenizer;
        private LambdaTreeBuilder _treeBuilder;

        public Manager()
        {
            _tokenizer = new Tokenizer();
            _treeBuilder = new LambdaTreeBuilder();
        }

        public void Manage(string path)
        {
            string[] textLines = File.ReadAllLines(path);
            for (int i = 0; i < textLines.Length; i++)
            {
                if (StaticMethodsExecution.IsSuccess(textLines[i]))
                {
                    StaticMethodsExecution.WriteLineExpression(textLines[i]);
                }
                else
                {
                    List <Model> objectList = _tokenizer.Tokenize(textLines[i]);
                    Model model = _treeBuilder.Build(objectList);
                    Console.WriteLine(Expression.Lambda<Func<double>>(model.ToExpression()).Compile()());
                }
            }
        }
    }
}
