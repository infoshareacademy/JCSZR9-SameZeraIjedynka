using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;
using static System.IO.Directory;

namespace BusinessCase.Helpers
{
    public static class DirectoryHelper
    {
        private static int _maxDepth = 4;
        public static string StepThroughDirectories(string dir)
        {
            for (int i = 0; i < _maxDepth; i++)
            {
                dir = GetParent(dir).ToString();
            }
            return dir + @"\BusinessCase\Storage\";
        }
    }
}
