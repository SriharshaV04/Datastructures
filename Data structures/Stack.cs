using System;

namespace Queues
{
    public class Stack<T>
    {
        private T[] s;
        private int rp=0; // removed from back

        public Stack(int length)
        {
            s = new T[length];
        }

        public void push(T obj)
        {
            if (rp < s.Length)
            {
                s[rp] = obj;
                rp++;
            }
            else
            {
                Console.WriteLine($"{obj} has not been pushed, Stack full");
            }
        }

        public T pop()
        {
            if (rp < s.Length + 1)
            {
                T lol = s[rp-1];
                s[rp-1] = default(T);
                rp--;
                return lol;
            }

            return default(T);
        }

        public T peek()
        {
            if (rp < s.Length + 1)
            {
                T lol = s[rp-1];
                return lol;
            }

            return default;
        }
        
        public void displayStack()
        {
            Console.WriteLine("----------------STACK------------------");
            string term;
            for (int i = 0; i < s.Length; i++)
            {
                term = $"{i+1}. {s[i]}";
                if (rp == i)
                {
                    term = $"{i+1}. {s[i]}    <R";
                }
                Console.WriteLine(term);
            }
            
        }
    }    
}