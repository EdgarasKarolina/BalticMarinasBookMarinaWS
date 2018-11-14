using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
