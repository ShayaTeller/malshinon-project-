using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal class Person
    {
        public int id;
        public string firstName;
        public string lastName;
        public string secretCode;
        public string potential_agent;
        public int num_reports;
        public int num_mentions;


        public Person()
        { }
        public Person(string firstname, string lastname)
        {
            firstName = firstname;
            lastName = lastname;

        }
    }
}


 //('reporter', 'target', 'bot')  