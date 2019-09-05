using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexityTool.Recursion
{
    class Reclaimer
    {
        private Link linkFirst;

        public Reclaimer()
        {
            linkFirst = null;
        }

        public void insertFirst(int increment, char val)
        {
            Link nLink = new Link(increment, val);
            nLink.next = linkFirst;
            linkFirst = nLink;
        }

        public Link deleteFirst()
        {
            Link temp = linkFirst;
            linkFirst = temp.next;
            return temp;
        }

        public Boolean isEmpty()
        {
            return (linkFirst == null);
        }

        public Link getFirst()
        {
            return linkFirst;
        }
    }
}
