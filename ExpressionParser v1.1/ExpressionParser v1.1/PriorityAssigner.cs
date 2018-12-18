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
        //private Dictionary<int, IEnumerable<string>> _prorities;

        private Dictionary<string, int> _priorities;

        public PriorityAssigner()
        {
            //_prorities = new Dictionary<int, IEnumerable<string>>()
            //{
            //    { -1, new string[] { "Parameter", "Number", "OpenBracket", "CloseBracket" }},
            //    { 1, new string[] { "Plus", "Minus" } },
            //    { 2, new string[] { "Multiply", "Divide" }},
            //    { 3, new string[] { "Power" } },
            //};

            _priorities = new Dictionary<string, int>()
            {
                { "Parameter", -1 },
                { "Number", -1 },
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
            //List<string> no = new List<string> { "Parameter", "Number", "OpenBracket", "CloseBracket" };
            //List<string> low = new List<string> {  };
            //List<string> mid = new List<string> { "Multiply", "Divide" };
            //List<string> high = new List<string> { "Power" };
            //Dictionary<List<string>, int> dic = new Dictionary<List<string>, int> { };
            //dic.Add(no, -1);
            //dic.Add(low, 1);
            //dic.Add(mid, 2);
            //dic.Add(high, 3);

            foreach(var item in objectList)
            {
                item.Priority = _priorities[item.Name];
            }

            //foreach(var priorityEntry in _prorities)
            //{
            //    foreach(var item in 
            //            objectList.Where(e => priorityEntry.Value.Contains(e.Name)))
            //    {
            //        item.Priority = priorityEntry.Key;
            //    }
            //}

            //foreach (var objectListItem in objectList)
            //{

            //    objectListItem.Priority = _prorities.

            //    foreach (var dicItem in .Keys)
            //    {
            //        if (dicItem.Contains(objectListItem.Name))
            //        {
            //            objectListItem.Priority = dic[dicItem];
            //        }
            //    }
            //}
        }
    }
}