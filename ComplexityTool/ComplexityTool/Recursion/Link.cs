using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexityTool.Recursion
{
    class Link
    {
        int increment;
        char val;
        public Link next;

        public Link(int increment, char val)
        {
            this.increment = increment;
            this.val = val;

            this.next = null;
        }

        public void displayLink()
        {
            Console.WriteLine("Increment : " + increment + ", Value : " + val);
        }
    }
}
