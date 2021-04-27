using System;

namespace Queues
{
    public class Queue
    {
        public string[] q;
        public int rp = -1;
        public int fp = 0;
        public int count = 0; // number of items in the queue
        public int length; // max size of the queue

        public Queue(int length)
        {
            q = new string[length];
            this.length = length;
        }
        
        public virtual void enQueue(string obj)
        {
            Console.WriteLine(rp);
            if (count == length)
            {
                Console.WriteLine($"{obj} cannot be enqueued due to lack of space");
            }
            else
            {
                rp++;
                if (rp < length)
                {
                    q[rp] = obj;
                    count++;
                }
                else
                {
                    Console.WriteLine($"{obj} could not be enqueued due to a lack of space");
                    rp--;
                }
                
            }
        }
        

        public virtual void deQueue()
        {
            if (count == 0)
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                Console.WriteLine($"{q[fp]} has been dequeued");
                fp++;
                count--;
            }
        }

        public void displayQueue()
        {
            Console.WriteLine("----------------QUEUE------------------");
            string term;
            for (int i = 0; i < q.Length; i++)
            {
                term = $"{i+1}. {q[i]}";
                if (rp == i)
                {
                    term = $"{i+1}. {q[i]}    <R";
                }
                if (fp == i)
                {
                    term = $"{i+1}. {q[i]}    <f";
                }
                Console.WriteLine(term);
            }
            
        }
    }
}