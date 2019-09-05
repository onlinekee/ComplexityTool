using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexityTool.TotalComplexity
{
    class TotalComplexity
    {
        public int getTotalWeight(int ctc, int cnc, int ci)
        {
            int tw = 0;

            tw = ctc + cnc + ci;

            return tw;
        }

        public int statementTotalComplexity(int cs, int tw)
        {
            int cps = 0;

            cps = cs * tw;

            return cps;
        }
    }
}
