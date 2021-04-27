using System;
using System.Collections.Generic;
using System.IO;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User("sriharsha.vitta@gmail.com","16");
            User l = new User("sriharsah.vitta@gmail.com","17");
            User f = new User("07svitta@brihgtoncollege.net","14");
            
            
            Hashtable hashtable = new Hashtable(5);
            
            //check this commit -sv
            
            // hashtable.add(l);
            // hashtable.add(u);
            hashtable.add(f);
            hashtable.print();
            
            // User r = hashtable.retrieve("sriharsha.vitta@gmail.com");
            // Console.WriteLine($"age: {r.age}");
            Console.WriteLine($"{hashtable.retrieve("sriharsah.vitta@gmail.com").age}");
            // Console.WriteLine(hashtable.hashtable[515]);
            // Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public static void stacks()
        {
            Stack<int> s = new Stack<int>(10);
            s.pop();
            s.push(1);
            s.push(2);
            s.push(3);
            s.push(4);
            s.push(5);
            s.push(6);
            s.push(9);
            s.push(8);
            s.push(9);
            s.push(10);
            s.push(11);
            s.displayStack();

            Console.WriteLine($"{s.pop()} has been popped");
            s.displayStack();
        }

        public static void queues()
        {
            CircularQueue q = new CircularQueue(10);

            q.enQueue("a");
            q.enQueue("b");
            q.enQueue("c");
            q.enQueue("d");
            q.displayQueue();

            q.deQueue();
            q.deQueue();
            q.displayQueue();

            q.enQueue("e");
            q.enQueue("f");
            q.enQueue("g");
            q.enQueue("h");
            q.enQueue("i");
            q.enQueue("j");
            q.enQueue("k");
            q.enQueue("l");
            q.enQueue("m");


            q.displayQueue();
        }

        public static string reverse(string sentence)
        {
            string[] words = sentence.Split(" ");
            Stack<string> s = new Stack<string>(words.Length);
            foreach (string word in words)
            {
                s.push(word);
            }

            string output = null;
            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                    output = s.pop();
                else
                    output = output + " " + s.pop();
            }

            return output;
        }

        public static void linkedList()
        {
            LinkedList list = new LinkedList();
            list.print("values");
            Console.WriteLine("new linked list");
            // list.AddData(0);
            list.AddData(10);
            list.AddData(6);
            list.print("values");
            Console.WriteLine($"length of list: {list.linkedList.Count}");
            list.removeData(5);
            Console.WriteLine($"length of list: {list.linkedList.Count}");
            list.print("values");
            list.print("non-contiguous");
        }
    }
}