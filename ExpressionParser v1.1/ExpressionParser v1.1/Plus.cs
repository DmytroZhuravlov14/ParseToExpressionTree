using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class Plus : Sign
    {
        public override string Name { get; } = "Plus";

        public override Expression ToExpression()
        {
            return Expression.Add(Left.ToExpression(), Right.ToExpression());
        }
    }
}
