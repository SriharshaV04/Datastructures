using System;

namespace Queues
{
    public class CircularQueue : Queue
    {

        public CircularQueue(int length) : base(length){}

        public override void enQueue(string obj)
        {
            if (count == length)
            {
                Console.WriteLine($"{obj} cannot be enqueued due to lack of space");
            }
            else
            {
                rp = (rp + 1) % length;
                q[rp] = obj;
                count++;
            }
        }

        public override void deQueue()
        {
            if (count == 0)
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                string term = q[fp];
                fp = (fp + 1) % length;
                Console.WriteLine(term + " has been dequeued");
                count--;
            }
        }

    }
}