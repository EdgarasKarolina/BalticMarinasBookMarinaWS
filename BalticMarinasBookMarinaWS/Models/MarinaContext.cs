using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Models
{
    public class MarinaContext
    {
        public string ConnectionString { get; set; }

        public MarinaContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Marina> GetAllMarinas()
        {
            List<Marina> list = new List<Marina>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllMarinas, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Marina()
                        {
                            MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            MarinaName = reader["MarinaName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Depth = Convert.ToDouble(reader["Depth"]),
                            CityName = reader["CityName"].ToString(),
                            Country = reader["Country"].ToString(),
                            ZipCodeNumber = reader["ZipCodeNumber"].ToString(),
                            TotalBerths = Convert.ToInt32(reader["TotalBerths"]),
                            IsToilet = Convert.ToInt32(reader["IsToilet"]),
                            IsShower = Convert.ToInt32(reader["IsShower"]),
                            IsInternet = Convert.ToInt32(reader["IsInternet"])
                        });
                    }
                }
            }
            return list;
        }

        public Marina GetMarinaById(int id)
        {
            var marinaById = new Marina();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetMarinaById, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marinaById.MarinaId = Convert.ToInt32(reader["MarinaId"]);
                        marinaById.MarinaName = reader["MarinaName"].ToString();
                        marinaById.Phone = reader["Phone"].ToString();
                        marinaById.Email = reader["Email"].ToString();
                        marinaById.Depth = Convert.ToDouble(reader["Depth"]);
                        marinaById.CityName = reader["CityName"].ToString();
                        marinaById.Country = reader["Country"].ToString();
                        marinaById.ZipCodeNumber = reader["ZipCodeNumber"].ToString();
                        marinaById.TotalBerths = Convert.ToInt32(reader["TotalBerths"]);
                        marinaById.IsToilet = Convert.ToInt32(reader["IsToilet"]);
                        marinaById.IsShower = Convert.ToInt32(reader["IsShower"]);
                        marinaById.IsInternet = Convert.ToInt32(reader["IsInternet"]);
                    }
                }
            }
            return marinaById;
        }

        public List<Marina> GetAllMarinasByCountry(string country)
        {
            List<Marina> list = new List<Marina>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllMarinasByCountry, conn);
                cmd.Parameters.Add("@country", MySqlDbType.String).Value = country;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Marina()
                        {
                            MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            MarinaName = reader["MarinaName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Depth = Convert.ToDouble(reader["Depth"]),
                            CityName = reader["CityName"].ToString(),
                            Country = reader["Country"].ToString(),
                            ZipCodeNumber = reader["ZipCodeNumber"].ToString(),
                            TotalBerths = Convert.ToInt32(reader["TotalBerths"]),
                            IsToilet = Convert.ToInt32(reader["IsToilet"]),
                            IsShower = Convert.ToInt32(reader["IsShower"]),
                            IsInternet = Convert.ToInt32(reader["IsInternet"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
