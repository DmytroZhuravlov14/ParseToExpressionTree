using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    abstract class ValueObject : Model
    {
        public object Value { get; set; }

        public override string Name { get; }

        public override int Priority { get; set; }

        public abstract override Expression ToExpression();
    }
}
