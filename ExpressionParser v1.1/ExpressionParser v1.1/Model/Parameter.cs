using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    class Parameter : ValueObject
    {
        public override string Name { get; } = "Parameter";

        public override Expression ToExpression()
        {
            return Expression.Constant(Convert.ToDouble(Value.ToString()));
        }
    }
}
