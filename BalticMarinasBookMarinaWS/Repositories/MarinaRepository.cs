using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories
{
    public class MarinaRepository : IMarinaRepository
    {
        public string ConnectionString { get; set; }

        public MarinaRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public void CreateMarina(Marina marina)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateMarina, conn);
                    cmd.Parameters.Add("@marinaName", MySqlDbType.VarChar).Value = marina.MarinaName;
                    cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = marina.Phone;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = marina.Email;
                    cmd.Parameters.Add("@depth", MySqlDbType.Double).Value = marina.Depth;
                    cmd.Parameters.Add("@cityName", MySqlDbType.VarChar).Value = marina.CityName;
                    cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = marina.Country;
                    cmd.Parameters.Add("@zipCodeNumber", MySqlDbType.VarChar).Value = marina.ZipCodeNumber;
                    cmd.Parameters.Add("@totalBerths", MySqlDbType.Int32).Value = marina.TotalBerths;
                    cmd.Parameters.Add("@isToilet", MySqlDbType.Int32).Value = marina.IsToilet;
                    cmd.Parameters.Add("@isShower", MySqlDbType.Int32).Value = marina.IsShower;
                    cmd.Parameters.Add("@isInternet", MySqlDbType.Int32).Value = marina.IsInternet;
                    cmd.Parameters.Add("@isElectricity", MySqlDbType.Int32).Value = marina.IsElectricity;
                    cmd.Parameters.Add("@isRepairing", MySqlDbType.Int32).Value = marina.IsRepairing;
                    cmd.Parameters.Add("@isStore", MySqlDbType.Int32).Value = marina.IsStore;
                    cmd.Parameters.Add("@isTelephone", MySqlDbType.Int32).Value = marina.IsTelephone;
                    cmd.Parameters.Add("@isHotel", MySqlDbType.Int32).Value = marina.IsHotel;
                    cmd.Parameters.Add("@isCafeteria", MySqlDbType.Int32).Value = marina.IsCafeteria;
                    cmd.Parameters.Add("@description", MySqlDbType.Text).Value = marina.Description;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
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
                            IsInternet = Convert.ToInt32(reader["IsInternet"]),
                            IsPharmacy = Convert.ToInt32(reader["IsPharmacy"]),
                            IsElectricity = Convert.ToInt32(reader["IsElectricity"]),
                            IsRepairing = Convert.ToInt32(reader["IsRepairing"]),
                            IsStore = Convert.ToInt32(reader["IsStore"]),
                            IsTelephone = Convert.ToInt32(reader["IsTelephone"]),
                            IsHotel = Convert.ToInt32(reader["IsHotel"]),
                            IsCafeteria = Convert.ToInt32(reader["IsCafeteria"]),
                            Description = reader["Description"].ToString()
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
                        marinaById.IsPharmacy = Convert.ToInt32(reader["IsPharmacy"]);
                        marinaById.IsElectricity = Convert.ToInt32(reader["IsElectricity"]);
                        marinaById.IsRepairing = Convert.ToInt32(reader["IsRepairing"]);
                        marinaById.IsStore = Convert.ToInt32(reader["IsStore"]);
                        marinaById.IsTelephone = Convert.ToInt32(reader["IsTelephone"]);
                        marinaById.IsHotel = Convert.ToInt32(reader["IsHotel"]);
                        marinaById.IsCafeteria = Convert.ToInt32(reader["IsCafeteria"]);
                        marinaById.Description = reader["Description"].ToString();
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
                            IsInternet = Convert.ToInt32(reader["IsInternet"]),
                            IsPharmacy = Convert.ToInt32(reader["IsPharmacy"]),
                            IsElectricity = Convert.ToInt32(reader["IsElectricity"]),
                            IsRepairing = Convert.ToInt32(reader["IsRepairing"]),
                            IsStore = Convert.ToInt32(reader["IsStore"]),
                            IsTelephone = Convert.ToInt32(reader["IsTelephone"]),
                            IsHotel = Convert.ToInt32(reader["IsHotel"]),
                            IsCafeteria = Convert.ToInt32(reader["IsCafeteria"]),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<string> GetAllMarinasNames()
        {
            List<string> list = new List<string>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllMarinasNames, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["MarinaName"].ToString());
                    }
                }
            }
            return list;
        }

        public int GetMarinaIdByMarinaName(string marinaName)
        {
            int marinaId = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetMarinaIdByMarinaName, conn);
                cmd.Parameters.Add("@marinaName", MySqlDbType.VarChar).Value = marinaName;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marinaId = Convert.ToInt32(reader["MarinaId"]);
                    }
                }
            }
            return marinaId;
        }

        public void DeleteMarina(int marinaId)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.DeleteMarina, conn);
                    cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = marinaId;

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
