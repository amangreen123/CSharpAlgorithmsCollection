using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Stack_Queues_Sorting
{
    internal class Stack
    {
        public Node top;

        public Stack()
        {

            top = null;

        }

        public Node GetNode(char data)
        {
            Node node = new Node(data);

            return node;
        }

        public void Push(char data)
        {
            Node newNode = GetNode(data);
            
            if (top == null)
            {
                top = newNode;
                return;
            }
            else
            {
                newNode.next = top; //links newNode to the current top
                top = newNode; // Sets newNode as the new top
            }
        }

        public string Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is Empty");
                return null; // Added return statement for empty stack
            }

            return top.value.ToString(); // Corrected to return string
        }

        public char Pop()
        {
            char popW = '\u0000';

            if (top != null)
            {
                popW = top.value;
                top = top.next;
            }

            return popW;
        }

        public bool isEmpty()
        {
            return top == null;

        }

    }
}
