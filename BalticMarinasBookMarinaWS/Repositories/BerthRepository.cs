using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories
{
    public class BerthRepository : IBerthRepository
    {
        public string ConnectionString { get; set; }

        public BerthRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void CreateBerth(Berth berth)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateBerth, conn);
                    cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = berth.MarinaId;
                    cmd.Parameters.Add("@price", MySqlDbType.Double).Value = berth.Price;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }

        public List<Berth> GetAllBerths()
        {
            List<Berth> list = new List<Berth>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllBerths, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Berth()
                        {
                            BerthId = Convert.ToInt32(reader["BerthId"]),
                            MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            Price = Convert.ToDouble(reader["Price"])
                        });
                    }
                }
            }
            return list;
        }

        public List<Berth> GetAllBerthsByMarinaId(int id)
        {
            List<Berth> list = new List<Berth>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllBerthsByMarinaId, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Berth()
                        {
                            BerthId = Convert.ToInt32(reader["BerthId"]),
                            MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            Price = Convert.ToDouble(reader["Price"])
                        });
                    }
                }
            }
            return list;
        }

        public Berth GetBerthByIdAndMarinaId(int marinaId, int berthId)
        {
            var berthById = new Berth();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetBerthByIdAndMarinaId, conn);
                cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = marinaId;
                cmd.Parameters.Add("@berthId", MySqlDbType.Int16).Value = berthId;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        berthById.BerthId = Convert.ToInt32(reader["BerthId"]);
                        berthById.MarinaId = Convert.ToInt32(reader["MarinaId"]);
                        berthById.Price = Convert.ToDouble(reader["Price"]);
                    }
                }
            }
            return berthById;
        }

        public List<Berth> GetReservedBerthsByMarinaIdAndDates(int marinaId, DateTime checkIn, DateTime checkOut)
        {
            List<Berth> list = new List<Berth>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetReservedBerthsByMarinaIdAndDates , conn);
                    cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = marinaId;
                    cmd.Parameters.Add("@checkIn", MySqlDbType.DateTime).Value = checkIn;
                    cmd.Parameters.Add("@checkOut", MySqlDbType.DateTime).Value = checkOut;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Berth()
                        {
                            BerthId = Convert.ToInt32(reader["BerthId"]),
                            MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            Price = Convert.ToDouble(reader["Price"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
