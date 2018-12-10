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

            foreach (var item in Tokenizer.objectList)
            {
                if (item.Name == "Parameter" || item.Name == "Number")
                    item.Priority = -1;
                if (item.Name == "Plus" || item.Name == "Minus")
                    item.Priority = 1;
                if (item.Name == "Multiply" || item.Name == "Divide")
                    item.Priority = 2;
                if (item.Name == "Power")
                    item.Priority = 3;
            }
        }

        static void CheckAssign()
        {
            foreach (var item in Tokenizer.objectList)
            {
                if(item.Priority == 0)
                    Console.WriteLine("Undefined object was found");
            }
        }
    }
}
