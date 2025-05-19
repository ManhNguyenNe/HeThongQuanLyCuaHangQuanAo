using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class ChatLieuBUS
    {
        private ChatLieuDAL dal = new ChatLieuDAL();

        public List<ChatLieu> GetAll()
        {
            return dal.GetAllChatLieu();
        }

        public bool Add(string tenChatLieu)
        {
            if (string.IsNullOrEmpty(tenChatLieu))
                return false;

            // Kiểm tra xem tên chất liệu đã tồn tại chưa
            var danhSachChatLieu = GetAll();
            if (danhSachChatLieu.Any(cl => cl.TenChatLieu.Equals(tenChatLieu, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên chất liệu đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã chất liệu mới
            string maChatLieu = GenerateNewID();

            // Thêm chất liệu mới
            return dal.Add(new Models.ChatLieu { MaChatLieu = maChatLieu, TenChatLieu = tenChatLieu });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách chất liệu hiện có
            var danhSachChatLieu = GetAll();

            if (danhSachChatLieu.Count == 0)
                return "CL001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var chatLieu in danhSachChatLieu)
            {
                if (chatLieu.MaChatLieu.StartsWith("CL"))
                {
                    if (int.TryParse(chatLieu.MaChatLieu.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"CL{(maxID + 1):D3}";
        }
    }
}
