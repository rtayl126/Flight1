using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
    public class FlightDAO : IflightDAO
    {
        private string connString = "Data Source=.;Initial Catalog = Flights; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Flight> GetFlights()
        {
            List<Flight> flightList = new List<Flight>();
            string query = "SELECT * FROM dbo.Flight;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight temp = new Flight(DateTime.Parse(reader["Departure"].ToString()),
                           DateTime.Parse(reader["Arrival"].ToString()), reader["DepLocation"].ToString(),
                           reader["Destination"].ToString(), int.Parse(reader["Capacity"].ToString())
                           );
                        temp.FlightId = Convert.ToInt32(reader["FlightId"]);
                        flightList.Add(temp);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the flights! \n {0}", ex.Message);
                }
            }

            return flightList;
        }

        public Flight GetFlight(int id)
        {
            Flight result = new Flight();
            string query = "[dbo].[GetFlight]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlightId", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Flight()
                        {
                            FlightId = id,
                            TakeOff = DateTime.Parse(reader["Departure"].ToString()),
                            Arrival = DateTime.Parse(reader["Arrival"].ToString()),
                            Departure = reader["DepLocation"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            Capacity = Convert.ToInt32(reader["Capacity"])
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get the flight! \n {0}, ex.Message", ex.Message);
                }
            }
            return result;
        }

        public void AddFlight(Flight flight)
        {
            string query = "[dbo].[AddFlight]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Departure", flight.TakeOff);
                    cmd.Parameters.AddWithValue("@Arrival", flight.Arrival);
                    cmd.Parameters.AddWithValue("@DepLocation", flight.Departure);
                    cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                    cmd.Parameters.AddWithValue("@capacity", flight.Capacity);
                    cmd.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Add Flight \n {0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateFlight(Flight flight)
        {
            string query = "[dbo].[UpdateFlight]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@FlightId", flight.FlightId);
                    cmd.Parameters.AddWithValue("@Departure", flight.TakeOff);
                    cmd.Parameters.AddWithValue("@Arrival", flight.Arrival);
                    cmd.Parameters.AddWithValue("@DepLocation", flight.Departure);
                    cmd.Parameters.AddWithValue("@Destination", flight.Destination);
                    cmd.Parameters.AddWithValue("@capacity", flight.Capacity);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Add Flight \n {0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeleteFlight(int id)
        {
            string query = "[dbo].[DeleteFlight]";

            using (SqlConnection conn = new SqlConnection(connString))
            {


                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FlightId", id);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not Remover the flight! \n {0}, ex.Message", ex.Message);
                }
            }

        }




        public IEnumerable<Person> GetFlightPeople(int id)
        {
            List<Person> personList = new List<Person>();
            string query = "dbo.GetFlightPeople";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flightId", id);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Person temp = new Person(reader["FName"].ToString(), reader["LName"].ToString(),
                            int.Parse(reader["Age"].ToString()), reader["Email"].ToString(),
                            reader["Job"].ToString());
                        temp.BookingId = Convert.ToInt32(reader["BookingId"]);
                        personList.Add(temp);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not get all the People!\n{0}", ex.Message);
                }
            }
            return personList;
        }
        public void FlightAddPerson(Person person)
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

        public int CountPassangers(int id)
        {
            int count = 0;
            string query = "[dbo].[CountPassangers]";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlightId", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       count = Convert.ToInt32(reader["Passangers"]);
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("could not ge passenger count",ex.Message);
                }
            }
            return count;

        }
    }
}
