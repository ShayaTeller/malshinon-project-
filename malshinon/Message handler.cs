using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal class Message_handler
    {
        //מבקש להכניס הודעה ומחזיר סטרינג 
        public string textmassage()
        {
            Console.WriteLine("enter the massage:");
            string massage = Console.ReadLine();
            return massage;
        }
        //כדי לשלוף אח"כ שם המטרה מוחק רווחים מיותרים 
        public string spaceCuter(string str)
        {
            string Firstname = null;
            string lastname = null;

            string[] result = str.Split(' ');
            foreach (string s in result)
            {
                if (s != "")
                {
                    if (char.IsUpper(s[0]))
                    {
                        if (Firstname == null)
                        {

                            Firstname = s;
                        }
                        else if (lastname == null)
                        {
                            lastname = s;
                            break;
                        }
                    }

                }


            }
            return Firstname + " " + lastname;

        }
        //שולף את שם הTARGET מתוך הטקסט
        public string[] ExtractorNameOfPerson(string foolname)
        {
            string[] result = new string[(3)];
            string Foolname = foolname;
            result.Append(foolname.ToString());
            //result.Append( foolname[1].ToString());
            return result;
        }

        public string StartText(string str)
        {
            string D = spaceCuter(str);
            return D;



        }
    }
}
