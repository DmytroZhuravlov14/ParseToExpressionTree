using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Multiply : Sign
    {
        public override string Name { get; } = "Multiply";

        public override Expression ToExpression()
        {
            return Expression.Multiply(Left.ToExpression(), Right.ToExpression());
        }
    }
}
