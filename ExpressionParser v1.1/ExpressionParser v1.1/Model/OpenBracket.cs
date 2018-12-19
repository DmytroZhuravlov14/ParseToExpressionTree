using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class OpenBracket : ValueObject
    {
        public override int Priority { get; set; }

        public override string Name { get; } = "OpenBracket";

        public override Expression ToExpression()
        {
            Console.WriteLine("Ошибка: Хочу привести скобку к   Expression");
            throw new NotImplementedException();
        }
    }
}
