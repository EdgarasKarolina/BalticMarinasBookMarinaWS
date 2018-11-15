using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BalticMarinasBookMarinaWS.Models
{
    public class ReservationContext
    {
        public string ConnectionString { get; set; }

        public ReservationContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void CreateReservation(int? berthId, int? customerId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateReservation, conn);
                    cmd.Parameters.Add("@berthId", MySqlDbType.Int16).Value = berthId;
                    cmd.Parameters.Add("@customerId", MySqlDbType.Int16).Value = customerId;
                    cmd.Parameters.Add("@checkIn", MySqlDbType.DateTime).Value = checkIn;
                    cmd.Parameters.Add("@checkOut", MySqlDbType.DateTime).Value = checkOut;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }

        public List<Reservation> GetAllReservationsByBerthId(int berthId, DateTime checkIn, DateTime checkOut)
        {
            List<Reservation> list = new List<Reservation>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from reservation WHERE BerthId = @berthId AND ", conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = berthId;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Reservation()
                        {
                            //BerthId = Convert.ToInt32(reader["BerthId"]),
                            //MarinaId = Convert.ToInt32(reader["MarinaId"]),
                            //Price = Convert.ToDouble(reader["Price"])
                        });
                    }
                }
            }
            return list;
        }
    }
}
