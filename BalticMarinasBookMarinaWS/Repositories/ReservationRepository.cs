﻿using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public string ConnectionString { get; set; }

        public ReservationRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int GetIfReservationExists(int reservationId)
        {
            var count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetIfReservationExists, conn);
                cmd.Parameters.Add("@reservationId", MySqlDbType.Int16).Value = reservationId;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            return count;
        }

        public void CreateReservation(Reservation reservation)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateReservation, conn);
                    cmd.Parameters.Add("@berthId", MySqlDbType.Int16).Value = reservation.BerthId;
                    cmd.Parameters.Add("@customerId", MySqlDbType.Int16).Value = reservation.CustomerId;
                    cmd.Parameters.Add("@checkIn", MySqlDbType.DateTime).Value = reservation.CheckIn;
                    cmd.Parameters.Add("@checkOut", MySqlDbType.DateTime).Value = reservation.CheckOut;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }

        public List<Reservation> GetAllReservationsByCustomerId(int id)
        {
            List<Reservation> list = new List<Reservation>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllReservationsByCustomerId, conn);
                cmd.Parameters.Add("@customerId", MySqlDbType.Int16).Value = id;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Reservation()
                        {
                            ReservationId = Convert.ToInt32(reader["ReservationId"]),
                            BerthId = Convert.ToInt32(reader["BerthId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            CheckIn = Convert.ToDateTime(reader["CheckIn"]),
                            CheckOut = Convert.ToDateTime(reader["CheckOut"]),
                            IsPaid = Convert.ToInt32(reader["IsPaid"])
                        });
                    }
                }
            }
            return list;
        }

        //public List<Reservation> GetAllReservationsByBerthId(int berthId, DateTime checkIn, DateTime checkOut)
        //{
        //    List<Reservation> list = new List<Reservation>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from reservation WHERE BerthId = @berthId AND ", conn);
        //        cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = berthId;

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Reservation()
        //                {
        //                    //BerthId = Convert.ToInt32(reader["BerthId"]),
        //                    //MarinaId = Convert.ToInt32(reader["MarinaId"]),
        //                    //Price = Convert.ToDouble(reader["Price"])
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}

        public int GetReservationId(int berthId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            int reservationId = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetReservationId, conn);
                cmd.Parameters.Add("@berthId", MySqlDbType.Int16).Value = berthId;
                cmd.Parameters.Add("@customerId", MySqlDbType.Int16).Value = customerId;
                cmd.Parameters.Add("@checkIn", MySqlDbType.DateTime).Value = checkIn;
                cmd.Parameters.Add("@checkOut", MySqlDbType.DateTime).Value = checkOut;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservationId = Convert.ToInt32(reader["ReservationId"]);
                    }
                }
            }
            return reservationId;
        }

        public void UpdateReservation(int reservationId)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.UpdateReservation, conn);
                    cmd.Parameters.Add("@reservationId", MySqlDbType.Int16).Value = reservationId;
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }

        public void DeleteNotPaidReservation(int reservationId)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.DeleteNotPaidReservation, conn);
                    cmd.Parameters.Add("@reservationId", MySqlDbType.Int16).Value = reservationId;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                //this.logger.Error($"Error in DeleteRolePerSystem - {e}");
            }
        }
    }
}
