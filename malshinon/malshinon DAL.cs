using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;


namespace malshinon
{
    class malshinon_DAL
    {


        private string connStr = "server=localhost;user=root;password=;database=malshononDB";
        private MySqlConnection _conn;

        //פותח חיבור
        public MySqlConnection openConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connStr);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                //Console.WriteLine("Connection successful.");
            }

            return _conn;
        }
        //סוגר חיבור
        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
                //Console.WriteLine("disconnected");
            }
        }

        //הוספת איש לטבלת אנשים 
        public void AddPeopleTable(Person name)
        {
            openConnection();

            MySqlCommand cmd = null;
            string query = "INSERT INTO people (first_name, last_name ,secret_code) VALUE(@firstName, @lastName, @secretCode)";
            cmd = new MySqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@firstName", name.firstName);
            cmd.Parameters.AddWithValue("@lastName", name.lastName);
            cmd.Parameters.AddWithValue("@secretCode", name.secretCode);
            ;

            try
            {

                cmd.ExecuteNonQuery();
                Console.WriteLine($"the name {name.firstName} is inserted in the table");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();

        }
        //הוספת רפורט חדש לטבלת רפורטים
        public void AddintelrepoortsTable(intelReports report)
        {
            openConnection();

            MySqlCommand cmd = null;
            string query = "INSERT INTO intelreports (reporter_id, target_id ,text) VALUE(@reporterId, @targetId, @text)";
            cmd = new MySqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@reporterId", report.reporterId);
            cmd.Parameters.AddWithValue("@targetId", report.targetId);
            cmd.Parameters.AddWithValue("@text", report.massage);
            ;

            try
            {

                cmd.ExecuteNonQuery();
                Console.WriteLine($"the report from {report.reporterId} ,about {report.targetId} is inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();

        }


        //בודק האם האיש קיים לפי שם פרטי, מחזיר TRUE OR FALSE   מקבל TYPE PERSON
        public bool SearchForPersonByFirstName(Person name)
        {
            openConnection();

            bool result = false;
            MySqlCommand cmd = null;
            string query = "SELECT first_name FROM `people` WHERE first_name = @firstname";
            MySqlDataReader reader;
            cmd = new MySqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@firstname", name.firstName);


            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }
            closeConnection();
            return result;

        }
        //בודק האם האיש קיים לפי שם פרטי, מחזיר TRUE OR FALSE     מקבל TYPE STRING

        public bool SearchForPersonByFirstName(string name)
        {
            openConnection();

            bool result = false;
            MySqlCommand cmd = null;
            string query = "SELECT first_name,id FROM `people` WHERE first_name = @firstname";
            MySqlDataReader reader;
            cmd = new MySqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@firstname", name);


            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();
            return result;

        }

        //מחזיר ID של אדם שנמצא בטבלה
        public int returnidbyname(string name)
        {
            openConnection();


            bool result = false;
            MySqlCommand cmd = null;
            string query = "SELECT id FROM `people` WHERE first_name = @firstname";
            MySqlDataReader reader;
            cmd = new MySqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@firstname", name);
            int id = -1;


            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("id");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();
            return id;

        }
        //מעדכן כמות רפורטים עבור REPORTER 
        public void updateReporterSumReports(int id)
        {
            openConnection();
            MySqlCommand cmd = null;

            string query = "UPDATE people SET num_reports =  1+(SELECT COUNT(*) FROM intelreports WHERE intelreports.reporter_id = (@id)) WHERE people.id = (@id)";
            cmd = new MySqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@id", id);
            ;

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();

        }
        //מעדכן כמות רפורטים עבור TARGET 

        public void updateTargetSumReports(int id)
        {
            openConnection();
            MySqlCommand cmd = null;

            string query = "UPDATE people SET num_mentions =  1+(SELECT COUNT(*) FROM intelreports WHERE intelreports.target_id = (@id)) WHERE people.id = (@id)";
            cmd = new MySqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@id", id);
            ;

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }

            closeConnection();

        }
        //מחזיר פרטי אדם לפי שם 
        public Person GetPersonByName(string name)
        {
            openConnection();

            string result = "";
            MySqlCommand cmd = null;
            string query = "SELECT * FROM people WHERE first_name = (@name)";
            MySqlDataReader reader;
            cmd = new MySqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@name", name);
            Person gwtterperson = new Person();


            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //gwtterperson.firstName = reader.GetString("first_name");
                    gwtterperson.firstName = reader["first_name"].ToString();
                    gwtterperson.lastName = reader["last_name"].ToString();
                    gwtterperson.secretCode = reader["secret_Code"].ToString();
                    gwtterperson.numreports = reader.GetInt32("num_reports");
                    gwtterperson.nummentions = reader.GetInt32("num_mentions");
                    gwtterperson.potentialagent = reader["potential_agent"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching: {ex.Message}");
            }
            closeConnection();
            return gwtterperson;


        }

    }

}
    //GetPersonBySecretCode()

    //        GetReporterStats()


    //GetTargetStats()


    //CreateAlert()


    //GetAlerts()







    //    public malshinon_DAL()
    //    {
    //        try
    //        {
    //            openConnection();
    //        }
    //        catch (MySqlException ex)
    //        {
    //            Console.WriteLine($"MySQL Error: {ex.Message}");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"General Error: {ex.Message}");
    //        }
    //    }

//}
//}
