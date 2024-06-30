using MySql.Data.MySqlClient;
using BucketListMODEL;
using System.Collections.Generic;

namespace BucketListDL
{
    public class DestinationDataService
    {
        private string connectionString;

        public DestinationDataService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Owner GetUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM Users WHERE Username=@username AND Password=@password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Owner
                    {
                        UserId = reader.GetInt32("User ID"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password")
                    };
                }
            }
            return null;
        }

        public List<Destination> GetAllDestinations()
        {
            var destinations = new List<Destination>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Destinations", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    destinations.Add(new Destination
                    {
                        DestinationId = reader.GetInt32("ID"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Country = reader.GetString("Country"),
                        City = reader.GetString("City")

                    });
                }
            }
            return destinations;
        }

        public void AddDestination(Destination destination)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Destinations (Name, Description, Country, City, ImportantInfo) VALUES (@name, @description, @country, @city)", conn);
                cmd.Parameters.AddWithValue("@name", destination.Name);
                cmd.Parameters.AddWithValue("@description", destination.Description);
                cmd.Parameters.AddWithValue("@country", destination.Country);
                cmd.Parameters.AddWithValue("@city", destination.City);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDestination(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Destinations WHERE DestinationId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Destination GetDestination(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Destinations WHERE DestinationId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Destination
                    {
                        DestinationId = reader.GetInt32("Destination ID"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Country = reader.GetString("Country"),
                        City = reader.GetString("City")

                    };
                }
            }
            return null;
        }
    }
}
