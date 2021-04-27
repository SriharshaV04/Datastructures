using System;

namespace Queues
{
    public class User
    {
        public string name;
        public string email;
        public string[] languages;
        public int age;
        public override string ToString()
        {
            return $"{email} {age} {name}";
        }

        public User(string mail="", string a="0")
        {
            email = mail;
            age = Convert.ToInt16(a);
        }
    }
}