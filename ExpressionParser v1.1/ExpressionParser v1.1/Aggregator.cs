using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser_v1._1
{
    class Aggregator
    {
        public static void Aggregate()
        {
            // Side - object temp-list
            List<Model> tempList = new List<Model> { };
            int maxObjectIndex;
            while (Tokenizer.objectList.Count != 1)
            {
                maxObjectIndex = 0;
                for (int i = 0; i < Tokenizer.objectList.Count - 1; i++)
                {
                    if (Tokenizer.objectList[i + 1].Priority > Tokenizer.objectList[maxObjectIndex].Priority)
                    {
                        maxObjectIndex = i + 1;
                    }
                }
                if (maxObjectIndex != 0)
                    tempList.Add(Tokenizer.objectList[maxObjectIndex - 1]);

                if (maxObjectIndex != Tokenizer.objectList.Count - 1)
                    tempList.Add(Tokenizer.objectList[maxObjectIndex + 1]);
                // Side elements consumed
                Tokenizer.objectList.RemoveRange(maxObjectIndex - 1, 1);
                Tokenizer.objectList.RemoveRange(maxObjectIndex, 1);
                // Element with the highest priority starts to point on side elements
                // Its priority becomes -1 to remove it from the list of searchable objects
                Sign aggregator = (Sign)Tokenizer.objectList[maxObjectIndex - 1];
                aggregator.Left = tempList[0];
                aggregator.Right = tempList[1];
                aggregator.Priority = -1;
                tempList.Clear();
            }
        }
    }
}
