using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
    public class PersonDAO : IPersonDAO
    {
        private string connString = "Data Source=.;Initial Catalog=Flights; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Person> GetPeople()
        {
            List<Person> personList = new List<Person>();
            string query = "SELECT * FROM dbo.Person;";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Person temp = new Person(reader["FName"].ToString(), reader["LName"].ToString(),
                            int.Parse(reader["Age"].ToString()), reader["Email"].ToString(),
                            reader["Job"].ToString());
                        temp.PersonId = Convert.ToInt32(reader["PersonId"]);
                        personList.Add(temp);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the home!\n{0}", ex.Message);
                }
            }
            return personList;
        }

        public Person GetPerson(int id)
        {
            Person result = new Person();
            string query = "[dbo].[GetPerson]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonId", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        result = new Person()
                        {
                            PersonId = id,
                            FName = reader["FName"].ToString(),
                            LName = reader["LName"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Email = reader["Email"].ToString(),
                            Job = reader["Job"].ToString()
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get the Person! \n {0}, ex.Message", ex.Message);
                }
            }
            return result;
        }

        public void AddPerson(Person person)
        {
            string query = "[dbo].[AddPerson]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@FName", person.FName);
                    cmd.Parameters.AddWithValue("LName", person.LName);
                    cmd.Parameters.AddWithValue("@Age", person.Age);
                    cmd.Parameters.AddWithValue("@Email", person.Email);
                    cmd.Parameters.AddWithValue("@Job", person.Job);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Add Person \n {0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdatePerson(Person person)
        {
            string query = @"[dbo].[UpdatePerson]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                    cmd.Parameters.AddWithValue("@FName", person.FName);
                    cmd.Parameters.AddWithValue("LName", person.LName);
                    cmd.Parameters.AddWithValue("@age", person.Age);
                    cmd.Parameters.AddWithValue("@Email", person.Email);
                    cmd.Parameters.AddWithValue("@Job", person.Job);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Add Person \n {0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeletePerson(int id)
        {
            //string query = "dbo.DeletePerson";
            string query = @"[dbo].[DeletePerson]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@PersonId", id);
                try
                {
                    conn.Open();
                    
                    
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Remove the Person! \n {0}, ex.Message", ex.Message);
                }
            }
        }
    }
}
