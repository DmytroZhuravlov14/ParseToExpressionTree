using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    static class VariableAssigner
    {
        public static void AssignVariables(List<Model> objectList, double a)
        {
            List<double> inputParameters = new List<double> { a };
            int counter = 0;
            foreach (var item in objectList)
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
