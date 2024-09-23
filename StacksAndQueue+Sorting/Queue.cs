using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queues_Sorting
{
    internal class Queue
    {
        Node front;
        Node tail;

        public Queue() {

            front = null;
            tail = null;
        }

        //Creates linked list Node 
        public Node GetNode(char data)
        {
            Node node = new Node(data);
            return node;
        }

        public void Enqueue(char data) { 

            Node newNode = new Node(data);

            if (front == null)
            {
                front = tail = newNode;
                return;
            }

            tail.next = newNode;
            tail = newNode;  
        }

        public char Dequeue() {

            char peek = '\u0000';

            if (front != null)
            {
                peek = front.value;
                front = front.next;
            }

            return peek;

        }

        public bool isEmpty()
        {
            if (front == null)
            {
                return true;

            } else {
                
                return false;
            } 
        }
         
    }
}
