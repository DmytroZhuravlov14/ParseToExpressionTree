using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ExpressionParser_v1._1
{
    abstract class Model
    {
        public int BracketPriority { get; set; }

        public abstract int Priority { get; set; }

        public abstract string Name { get; }

        public abstract Expression ToExpression();
    }
}
