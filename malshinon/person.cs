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
        public string potentialagent;
        public int numreports;
        public int nummentions;


        public Person()
        { }
        //יוצר שם רנדומלי 
        private string  randomSecretCodeMaker(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();



        }
        //מקצה שם  רנדומלי
        private string setsrndName(Person per)
        {
            string randomname = per.randomSecretCodeMaker(10);
            return randomname;

        }
        //מדפיס את כל פרטי הPERSON 
        public void PrintPersonDetiales()
        {
            Console.WriteLine($"THE FIRST NAME IS: { this.firstName} \n" +
                $"THE LAST NAME IS: { this.lastName} \n " +
                $" THE SECRET CODE IS: {this.secretCode} \n" +
                $"THE NUM OF REPORTS IS: { this.numreports}" +
                $"THE NUM OF MENTIONS IS: { this.nummentions}");
        }
        //מדפיס רק שם קוד 
        public void PrintCodName()
        {
            Console.WriteLine($" THE SECRET CODE IS: {this.secretCode}");

        }

        //קונסטרטורים
        public Person(string firstname, string lastname)
        {
            firstName = firstname;
            lastName = lastname;
            secretCode = setsrndName(this);

        }
        public Person(string firstname)
        {
            firstName = firstname;
            secretCode = setsrndName(this);

        }
    }
}


 //('reporter', 'target', 'bot')  