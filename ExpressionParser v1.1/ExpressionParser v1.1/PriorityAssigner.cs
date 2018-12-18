using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionParser_v1._1;

namespace ExpressionParser_v1._1
{
    static class PriorityAssigner
    {
        public static void AssignPriorities()
        {
            AssignPrioritiesUnchecked();
            CheckAssign();
        }

        static void AssignPrioritiesUnchecked()
        {
            List<string> no = new List<string> { "Parameter", "Number" };
            List<string> low = new List<string> { "Plus", "Minus" };
            List<string> mid = new List<string> { "Multiply", "Divide" };
            List<string> high = new List<string> { "Power" };
            Dictionary<List<string>, int> dic = new Dictionary<List<string>, int> { };
            dic.Add(no, -1);
            dic.Add(low, 1);
            dic.Add(mid, 2);
            dic.Add(high, 3);
            foreach (var objectListItem in Tokenizer.objectList)
            {
                foreach (var dicItem in dic.Keys)
                {
                    if (dicItem.Contains(objectListItem.Name))
                    {
                        objectListItem.Priority = dic[dicItem];
                    }
                }
            }
        }

        static void CheckAssign()
        {
            foreach (var item in Tokenizer.objectList)
            {
                if (item.Priority == 0)
                    Console.WriteLine("Undefined object was found");
            }
        }
    }
}