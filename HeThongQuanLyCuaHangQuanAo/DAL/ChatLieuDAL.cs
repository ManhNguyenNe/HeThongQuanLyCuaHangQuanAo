using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class ChatLieuDAL
    {
        public List<ChatLieu> GetAllChatLieu()
        {
            List<ChatLieu> list = new List<ChatLieu>();
            string query = "SELECT MaChatLieu, TenChatLieu FROM ChatLieu";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChatLieu
                        {
                            MaChatLieu = reader["MaChatLieu"].ToString(),
                            TenChatLieu = reader["TenChatLieu"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(ChatLieu chatLieu)
        {
            string query = "INSERT INTO ChatLieu (MaChatLieu, TenChatLieu) VALUES (@MaChatLieu, @TenChatLieu)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaChatLieu", chatLieu.MaChatLieu);
                cmd.Parameters.AddWithValue("@TenChatLieu", chatLieu.TenChatLieu);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm chất liệu: " + ex.Message);
                }
            }
        }

    }
}
