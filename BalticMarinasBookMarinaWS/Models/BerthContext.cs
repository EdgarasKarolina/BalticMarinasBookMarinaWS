using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Models
{
    public class BerthContext
    {
        public string ConnectionString { get; set; }

        public BerthContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Berth> GetAllBerths()
        {
            List<Berth> list = new List<Berth>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from berth", conn);

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
                MySqlCommand cmd = new MySqlCommand("select * from berth WHERE MarinaId = @id", conn);
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

        public Berth GetBerthByIdAndMarinaId(int marinaId, int berthId )
        {
            var berthById = new Berth();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from berth WHERE MarinaId = @marinaId AND BerthId = @berthId", conn);
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
                MySqlCommand cmd = new MySqlCommand("Select berth.BerthId, berth.MarinaId, berth.Price\n" +
                    "from berth\n" +
                    "JOIN marina ON berth.MarinaId=marina.MarinaId\n" +
                    "JOIN cityzipcode ON marina.CityZipCodeId=cityzipcode.CityZipCodeId\n" +
                    "JOIN city ON city.CityId=cityzipcode.CityId\n" +
                    "JOIN zipcode ON zipcode.ZipCodeId=cityzipcode.ZipCodeId\n" +
                    "JOIN reservation ON berth.BerthId=reservation.BerthId\n" +
                    "WHERE (berth.MarinaId = @marinaId AND berth.BerthId = reservation.BerthId\n" +
                    "AND reservation.CheckIn BETWEEN @checkIn and @checkOut\n" +
                    "AND reservation.CheckOut BETWEEN @checkIn and @checkOut)" , conn);
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
