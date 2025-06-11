using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using malshinon;
using static System.Net.Mime.MediaTypeNames;
using Google.Protobuf.Compiler;
using System.Xml.Linq;


namespace malshinon
{
    internal class Person_Identification:malshinon_DAL
    {
        private string connStr = "server=localhost;user=root;password=;database=malshonondb";
        private MySqlConnection _conn;
   
        public string firstName;
        public string lastName;
        public string secretCode;
        public string potential_agent;
        public int num_reports;
        public int num_mentions;
        public int idL = -1;

        //מבקש שם אדם ומחזיר אותו כסטרינג 
        public string startPersonIdentification()
        {
            Console.WriteLine( "enter your first name");
            string name = Console.ReadLine();
            return name;
        }

        //בודק האם קיים בדאטה בייס אם לא ת מבקש שם משפחה  ואז הוא מוסיף אותו (reporter)
        public string CHecker(string name)
        {
            if (SearchForPersonByFirstName(name).Equals(true))
            {

                Console.WriteLine("Login successful");

            }
            else
            {
                firstName = name;
                Console.WriteLine("enter the last name!");
                lastName = Console.ReadLine();
                Person a = new Person(firstName, lastName);
                AddPeopleTable(a);
            }
            return name;
        }

        public string  StartIdentification()
        {
            return (CHecker(startPersonIdentification()));
        }

         






    }
}

