using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using BalticMarinasBookMarinaWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        public string ConnectionString { get; set; }

        public CommentRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Comment> GetAllCommentsByMarinaId(int marinaId)
        {
            List<Comment> list = new List<Comment>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetAllCommentsByMarinaId, conn);
                cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = marinaId;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Comment()
                        {
                            CommentId = Convert.ToInt32(reader["CommentId"]),
                            UserName = reader["UserName"].ToString(),
                            TimePlaced = Convert.ToDateTime(reader["TimePlaced"]),
                            Body = reader["Body"].ToString(),
                            MarinaId = Convert.ToInt32(reader["MarinaId"])
                        });
                    }
                }
            }
            return list;
        }

        public void CreateComment(Comment comment)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateComment, conn);
                    cmd.Parameters.Add("@timePlaced", MySqlDbType.DateTime).Value = comment.TimePlaced;
                    cmd.Parameters.Add("@body", MySqlDbType.VarChar).Value = comment.Body;
                    cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = comment.UserName;
                    cmd.Parameters.Add("@marinaId", MySqlDbType.Int16).Value = comment.MarinaId;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
