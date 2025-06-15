using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal class intelReports:malshinon_DAL
    {
        public int id;
        public int reporterId;
        public int targetId;
        public string text;
        public DateTime timetemp;
        Person_Identification pid = new Person_Identification();
        Message_handler mh = new Message_handler();
        string name;
        public string massage;



        //התחברות למערכת ע"י מדווח 
        public void Reporterlogin()
        {
           reporterId = returnidbyname(pid.StartIdentification());
           updateReporterSumReports(reporterId);

        }
        //פונקציה המבקשת הודעה לדיווח ומכניסה לשדה המתאים
        public void massanger()
        {
            massage = mh.textmassage();
            string firstname = mh.StartText(massage);


            if (SearchForPersonByFirstName(firstname).Equals(true)) {
                this.targetId = pid.returnidbyname(firstname);
                updateTargetSumReports(targetId);
                        }
            else
            {
                Person a = new Person(firstname);
                AddPeopleTable(a);
                this.targetId = pid.returnidbyname(a.firstName);
                updateTargetSumReports(this.targetId);

            }
        }
        //קונסטרקטור ראשי של המחלקה שמפעיל תהליך של דיווח ושמירה לDB
        public intelReports()
        {
            Reporterlogin();
            massanger();
            AddintelrepoortsTable(this);



        }
  

        //public string Logger()
        //{
        //    openConnection();
        //    Console.WriteLine("enter your name or codenae");
        //    string userinput = Console.ReadLine();
        //    int id = -1;

        //    if (SearchForPersonByFirstName(userinput))
        //    {
        //        Console.WriteLine("loging succsessful");
        //        id = returnidbyname(userinput);

        //    }
        //    else
        //    {
        //        openConnection();
        //        Console.WriteLine("enter your last name");
        //        AddPeopleTable(new Person($"{userinput}", $"{Console.ReadLine()}"));

        //    }
        //    return "hi";


        }
    }

