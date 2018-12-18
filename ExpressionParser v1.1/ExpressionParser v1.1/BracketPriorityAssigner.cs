using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class BracketPriorityAssigner
    {
        public static void AssignBracketPriorities(List<Model> objectList)
        {
            int openBracketCounter = 0;
            //for (int i = 0; i < objectList.Count; i++)
            //{
            //    if (objectList[i].Name == "OpenBracket")
            //    {
            //        for (int j = i; j < objectList.Count; j++)
            //        {
            //            while (objectList[j].Name != "CloseBracket")
            //            {

            //                objectList[j].BracketPriority++;
            //            }
            //        }
            //    }
            //}
            for (int i = 0; i < objectList.Count; i++)
            {
                if (objectList[i].Name == "OpenBracket")
                {
                    openBracketCounter++;
                    for (int j = i; j < objectList.Count; j++)
                    {
                        objectList[j].BracketPriority = openBracketCounter;
                    }
                    continue;
                }
                if (objectList[i].Name == "CloseBracket")
                {
                    for (int j = i; j < objectList.Count; j++)
                    {
                        objectList[j].BracketPriority = openBracketCounter;
                    }
                    openBracketCounter--;
                    continue;
                }
                objectList[i].BracketPriority = openBracketCounter;
            }
        }
    }
}
