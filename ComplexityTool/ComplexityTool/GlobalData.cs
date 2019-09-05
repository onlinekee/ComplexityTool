using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexityTool
{
    class GlobalData
    {
        public static int ExtendCount = 0;
        public static int ExtendValueinsideBra = 0;
        public static bool isExtendedRow = false;
        public static bool isInsideOfBrackets = false;
        public static string className = string.Empty;
        public static List<ExtendedProperties> list = new List<ExtendedProperties>();
        public static Stack<string> bracketsList = new Stack<string>();
    }
}
