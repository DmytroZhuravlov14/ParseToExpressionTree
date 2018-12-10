using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    abstract class Sign : Model
    {
        public Model Left { get; set; }

        public Model Right { get; set; }

        public override string Name { get; }

        public override int Priority { get; set; }

        public abstract override Expression ToExpression();
    }
}
