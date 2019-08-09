using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComplexityTool.Size
{
    class SizeComplexity
    {
        public int sizeScore { get; set; }

        public int operatorsScore(String code)
        {
            int score = 0;
            String str = code;

            char[] charArray = new char[str.Length];

            charArray = str.ToCharArray();

            foreach ( char ch in charArray)
            {
                if (ch == '+' || ch == '-' || ch == '/' || ch == '*' || ch == '%')
                {
                    score = score + 1;
                }
            }

            return score;
        }
    }
}
