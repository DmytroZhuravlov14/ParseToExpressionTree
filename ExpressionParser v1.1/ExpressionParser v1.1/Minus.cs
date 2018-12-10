using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Minus : Sign
    {
        public override string Name { get; } = "Minus";

        public override Expression ToExpression()
        {
            return Expression.Subtract(Left.ToExpression(), Right.ToExpression());
        }
    }
}
