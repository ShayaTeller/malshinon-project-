using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace malshinon
{
    class malshinon_DAL
    {
		
		private string connStr = "server=localhost;user=root;password=;database=malshononDB";
		private MySqlConnection _conn;

		public MySqlConnection openConnection()
		{
            if (_conn == null)
            {
				_conn = new MySqlConnection(connStr);
			}

			if (_conn.State != System.Data.ConnectionState.Open)
			{
				_conn.Open();
				Console.WriteLine("Connection successful.");
			}

			return _conn;
		}

		public void closeConnection()
		{
			if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
			{
				_conn.Close();
				_conn = null;
			}
		}

		//הוספת אנשים לטבלת אנשים 
		public void AddPeopleTable(Person name)
		{
			MySqlCommand cmd = null;
			string query = "INSERT INTO people (first_name, last_name ,secret_code) VALUE(@firstName, @lastName, @secretCode)";
			cmd = new MySqlCommand(query, _conn);
			cmd.Parameters.AddWithValue("@firstName", name.firstName);
			cmd.Parameters.AddWithValue("@lastName", name.lastName);
			cmd.Parameters.AddWithValue("@secretCode", name.secretCode);
			;
			

				try
				{
					openConnection();
					cmd.ExecuteNonQuery();
					Console.WriteLine($"the name {name.firstName} is inserted in the table");

				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error while fetching: {ex.Message}");
				}

				closeConnection();
		
		}


		//בודק האם האיש קיים לפי שם פרטי, מחזיר TRUE OR FALSE
		public bool  SearchForPersonByFirstName(Person name)
		{

			bool result = false;			
			MySqlCommand cmd = null;
			string query = "SELECT first_name FROM `people` WHERE first_name = @firstname";
			MySqlDataReader reader;
            cmd = new MySqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@firstname", name.firstName);


				openConnection();
            try
            {
				reader =  cmd.ExecuteReader();
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





		public malshinon_DAL()
		{
			try
			{
				openConnection();
			}
			catch (MySqlException ex)
			{
				Console.WriteLine($"MySQL Error: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"General Error: {ex.Message}");
			}
		}

	}
}
