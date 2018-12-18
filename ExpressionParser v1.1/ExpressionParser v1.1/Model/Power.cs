using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Power : Sign
    {
        public override string Name { get; } = "Power";

        public override Expression ToExpression()
        {
            return Expression.Power(Left.ToExpression(), Right.ToExpression());
        }
    }
}
