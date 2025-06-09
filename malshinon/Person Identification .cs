using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using malshinon;


namespace malshinon
{
    internal class Person_Identification
    {
        private string connStr = "server=localhost;user=root;password=;database=malshonondb";
        private MySqlConnection _conn;
   
        public string firstName;
        public string lastName;
        public string secretCode;
        public string potential_agent;
        public int num_reports;
        public int num_mentions;
        public malshinon_DAL n;
        //= new malshinon_DAL();




        public void startPersonIdentification()
        {
            Console.WriteLine( "enter the first name");
            string name = Console.ReadLine();
            if (n.SearchForPersonByFirstName(name) == true)
              {
                Console.WriteLine( "this person is in the db!");
               }
            else
            {
                firstName = name;
                Console.WriteLine( "enter the last name!");
                lastName = Console.ReadLine();
                Person a = new Person(firstName, lastName);
                n.AddPeopleTable(a);
            }
                    


            
            



        }



    }
}

