using BSTGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queues_Sorting
{
    internal class Node
    {
       public BSTNode value;
       public Node next;

        public Node(BSTNode value)
        {
            this.value = value;
            this.next = null;
        }

    }
}
