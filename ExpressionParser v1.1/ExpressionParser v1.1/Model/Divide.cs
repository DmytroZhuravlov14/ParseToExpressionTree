using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Divide : Sign
    {
        public override string Name { get; } = "Divide";
        
        public override Expression ToExpression()
        {
            return Expression.Divide(Left.ToExpression(), Right.ToExpression());
        }
    }
}
