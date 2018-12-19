using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExpressionParser_v1._1
{
    class FileReader
    {
        public static string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
