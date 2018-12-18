using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class LambdaTreeBuilder
    {
        public static Model Build(List<Model> ObjectList)
        {
            VariableAssigner.AssignVariables(ObjectList, 12.0);
            PriorityAssigner.AssignPriorities(ObjectList);
            BracketPriorityAssigner.AssignBracketPriorities(ObjectList);
            Model model = Aggregator.AggregateBig(ObjectList);
            return model;
        }
    }
}
