using Stack_Queues_Sorting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSTGraphs
{
    public class BinarySearchTree
    {

        private BSTNode root;
        private int comparison;
        
        //Constructor
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(string value)
        {
            root = new BSTNode(value);
        }


        /// <summary>
        /// Private recursive function to search for a particular node in a tree  
        /// </summary>
        public bool SearchNode(BSTNode root, string target)
        {
            comparison = 0;
           
            // Base Case: root is null
            // or data stored at root is equal to string which is to be searched 
            if (root == null || string.Compare(root.Data, target) == 0)
            {
                return false;
            }

            //Data stored at root is smaller than the string which is to be searched
            if (String.Compare(target,root.Data) < 0)
            {
                return SearchNode(root.Right, target);
            }
            //Data stored at root is greater than the string which is to be searched 
            else
            {
                return SearchNode(root.Left, target);
            }

        }


        public void insert (string data)
        {
            root = AddValue(root, data);
        }

        /// <summary>
        /// Private recursive function which is called to insert data into the tree
        /// </summary>
        private BSTNode AddValue(BSTNode root, string value) { 
             comparison++;

            if (root == null)
            {
                root = new BSTNode(value);

                return root;
            }

            if(string.Compare(root.Data,value) > 0)
            {
                root.Left = AddValue(root.Left, value);

                //Console.WriteLine("L");
            }
            
            else if (string.Compare(root.Data,value) < 0) {
               
                root.Right = AddValue(root.Right, value);
               // Console.WriteLine("R");
            }

            return root;
          
        }


        int treeComparisons()
        {
            return comparison;
        }

        /// <summary>
        /// Function to call private inOrder() function 
        /// </summary>
        public void inOrder()
        {
            inOrder(root);
        }

       

        /// <summary>
        /// -- In-Order traversal --
        /// Traverse left subtree recursively
        /// Visite root node
        /// traverse right subtree resursively
        /// </summary>
        private void inOrder(BSTNode root) {

            if (root != null){ 

                inOrder(root.Left);
                Console.WriteLine(root.Data);
                
                inOrder(root.Right);

            }

        }

        public void printTree()
        {
            if (root == null)
            {
                Console.WriteLine("The tree is empty.");
                return;
            }

            AaronQueue queue = new AaronQueue();
            queue.Enqueue(root);

            while (true)
            {
                int nodeCount = queue.Size();
                //Console.WriteLine(nodeCount);
                //Console.Write(root.Data + " ");

                if (nodeCount == 0)
                {
                    break;
                }

                while (nodeCount > 0)
                {
                    Node queueNode = queue.Dequeue();

                    BSTNode node = queueNode.value;
                    
                    //Console.Write(node.Data + " ");

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {

                        queue.Enqueue(node.Right);
                    }
                    nodeCount--;
                }
                Console.WriteLine();
            }
        }


    }

}
