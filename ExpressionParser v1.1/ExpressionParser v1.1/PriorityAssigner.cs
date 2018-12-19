using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser_v1._1;

namespace ExpressionParser_v1._1
{
    class PriorityAssigner
    {
        private Dictionary<string, int> _priorities;

        public PriorityAssigner()
        {
            _priorities = new Dictionary<string, int>()
            {
                { "Parameter", -1 },
                { "Number", -1 },
                { "OpenBracket" , -1 },
                { "CloseBracket", -1 },
                { "Plus", 1 },
                { "Minus", 1 },
                { "Multiply", 2 },
                { "Divide", 2 },
                { "Power", 3 }
            };

        }

        public void AssignPriorities(List<Model> objectList)
        {
            AssignPrioritiesUnchecked(objectList);

            if (objectList.Any(e => e.Priority == 0))
            {
                Console.WriteLine("Undefined object was found");
            }
        }

        private void AssignPrioritiesUnchecked(List<Model> objectList)
        {
            foreach (var item in objectList)
            {
                item.Priority = _priorities[item.Name];
            }
        }
    }
}