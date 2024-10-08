using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTGraphs
{
   public class BSTNode
   {
        public string Data { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public BSTNode(string data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
   }
}
