using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    static class VariableAssigner
    {
        public static void AssignVariables(double a, double b)
        {
            List<double> inputParameters = new List<double> { a, b };
            int counter = 0;
            foreach (var item in Tokenizer.objectList)
            {
                if (item.Name == "Parameter")
                {
                    ((Parameter)item).Value = inputParameters[counter];
                    counter++;
                }
            }
        }
    }
}
