using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class Aggregator
    {
        public static Model Aggregate(List<Model> objectList)
        {
            List<Model> tempList = new List<Model> { };
            int maxObjectIndex;
            while (objectList.Count != 1)
            {
                maxObjectIndex = 0; // objectList.Max(x => x.Priority);
                for (int i = 0; i < objectList.Count - 1; i++)
                {
                    if (objectList[i + 1].Priority > objectList[maxObjectIndex].Priority)
                    {
                        maxObjectIndex = i + 1;
                    }
                }
                if (maxObjectIndex != 0)
                    tempList.Add(objectList[maxObjectIndex - 1]); 

                if (maxObjectIndex != objectList.Count - 1)
                    tempList.Add(objectList[maxObjectIndex + 1]);

                objectList.RemoveRange(maxObjectIndex - 1, 1);
                objectList.RemoveRange(maxObjectIndex, 1);
                Sign aggregator = (Sign)objectList[maxObjectIndex - 1];
                aggregator.Left = tempList[0];
                aggregator.Right = tempList[1];
                aggregator.Priority = -1;
                tempList.Clear();
            }
            return objectList.First();
        }

        public static Model AggregateBig(List<Model> objectList)
        {
            List<Model> tempList = new List<Model>();
            while(objectList.Count != 1)
            {
                int maxBracketPriority = objectList.Max(x => x.BracketPriority);
                int startIndex = 0;
                for (int i = 0; i < objectList.Count; i++)
                {
                    if (objectList[i].BracketPriority == maxBracketPriority)
                    {
                        startIndex = i;
                        break;
                    }
                }
                for (int i = startIndex + 1; i < objectList.Count; i++)
                {
                    if (objectList[startIndex].Name == "OpenBracket")
                    {
                        while (objectList[i].Name != "CloseBracket")
                        {
                            tempList.Add(objectList[i]);
                            i++;
                        }
                        break;
                    }
                }
                int lenght = tempList.Count;
                Model tempModel = null;
                if (tempList.Count == 0)
                {
                    tempModel = Aggregate(objectList);
                    break;
                }
                else
                {
                    tempModel = Aggregate(tempList);
                }
                tempModel.BracketPriority--;
                objectList[startIndex] = tempModel;
                objectList.RemoveRange(startIndex + 1, lenght + 1);
                tempList.Clear();
            }
            return objectList.FirstOrDefault();
        }
    }
}
