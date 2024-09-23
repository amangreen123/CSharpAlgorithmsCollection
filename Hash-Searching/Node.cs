using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queues_Sorting
{
    internal class Node
    {
       public string value;
       public Node next;

        public Node(string value)
        {
            this.value = value;
            this.next = null;
        }
    }
}
