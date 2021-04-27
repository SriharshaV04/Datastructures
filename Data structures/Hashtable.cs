using System;
using System.IO;
using System.Threading.Tasks;


namespace Queues
{
    public class Hashtable
    {
        public int length = 1000;
        public User[] hashtable;
        public string fileName = "/Users/sriharshavitta/RiderProjects/Queues/Data structures/HashTable.txt";
        

        public Hashtable(int len = 1000)
        {
            length = len;
            hashtable = new User[length];
            readTxt();
        }
        public void add(User user)
        {
            string email = user.email;
            int hashvalue = hash(email);
            int addition = 0;
            while (hashtable[hashvalue] != null)
            {
                addition += 1;
                hashvalue += 1;
                if (hashvalue >= length-1)
                {
                    addition = -hashvalue;
                    Console.WriteLine("hash is higher than maximum val");
                    Console.WriteLine("hash is being reverted to 0");
                    hashvalue = 0;
                }
            }

            if (addition != 0)
            {
                Console.WriteLine("A collision has occured");
                Console.WriteLine($"Storing item in location: {hashvalue}");
            }
            else
            {
                Console.WriteLine($"Storing item in location: {hashvalue}");
            }
            // user.addition = addition;
            hashtable[hashvalue] = user;
            writeTotxt(hashvalue, user);
        }
        
        public int hash(string str)
        {
            int total = 0;
            foreach (char c in str)
            {
                int ascii = c;
                total += ascii;
            }

            int hashvalue = total % length;
            return hashvalue;

        }
        
        public User retrieve(string email)
        {
            int pos = hash(email);
            if (hashtable[pos] == null)
            {
                return null;
            }
            while (hashtable[pos] != null && hashtable[pos].email != email)
            {
                pos += 1;
                if (pos >= length-1)
                {
                    pos = 0;
                }
            }

            if (hashtable[pos] == null)
            {
                return null;
            }
            else
            {
                return hashtable[pos];
            }
        }

        public async Task writeTotxt(int hash, User user)
        {
            using StreamWriter file = new StreamWriter("/Users/sriharshavitta/RiderProjects/Queues/Data structures/HashTable.txt",append:true);
            string text = $"{hash},{user.ToString()}";
            await file.WriteLineAsync(text);
            Console.WriteLine("Successfully written to txt");
        }

        public void readTxt()
        {
            string[] data = File.ReadAllLines(fileName);
            foreach (string line in data)
            {
                string[] stuff = line.Split(",");
                if (stuff.Length != 1)
                {
                    string[] details = stuff[1].Split(" ");
                    hashtable[Convert.ToInt16(stuff[0])] = new User(details[0],details[1]);
                    // Console.WriteLine($"writing phase: {stuff[0]}, {details[0]}");
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    Console.WriteLine($"{i}. {hashtable[i].email}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("empty space");
                }
                    
            }
        }

    }
}