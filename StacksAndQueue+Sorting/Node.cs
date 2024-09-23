using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queues_Sorting
{
    internal class Node
    {
       public char value;
       public Node next;

        public Node(char value)
        {
            this.value = value;
            this.next = null;
        }
    }
}
