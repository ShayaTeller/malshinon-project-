using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            malshinon_DAL dal = new malshinon_DAL();
            Person mm = new Person("jony", "mendelowitz");
            Person kk = new Person("jonddy", "mendelowddddcitz");


            dal.AddPeopleTable(kk);

            Console.WriteLine(dal.SearchForPersonByFirstName("msdcm"));



        }
    }
}
