using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.BUS;
using System.Windows.Forms.DataVisualization.Charting;
namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ucThongKe: UserControl
    {
        public ucThongKe()
        {
            InitializeComponent();
            // Thêm item vào materialComboBox1
            materialComboBox1.Items.Add("Thống kê doanh thu theo ngày");
            materialComboBox1.Items.Add("Thống kê doanh thu theo tuần");
            materialComboBox1.Items.Add("Thống kê doanh thu theo tháng");
            materialComboBox1.Items.Add("Thống kê sản phẩm bán chạy");
            materialComboBox1.Items.Add("Thống kê sản phẩm tồn kho");
            materialComboBox1.Items.Add("Thống kê khách hàng tiềm năng");
            materialComboBox1.SelectedIndexChanged += materialComboBox1_SelectedIndexChanged;

            // Hiển thị mặc định là "Thống kê doanh thu theo ngày"
            materialComboBox1.SelectedIndex = 0;
        
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = materialComboBox1.SelectedItem.ToString();
            if (selected == "Thống kê doanh thu theo ngày")
            {
                LoadUserControl(new ucThongKeNgay());
            }
            else if (selected == "Thống kê doanh thu theo tuần")
            {
                LoadUserControl(new ucThongKeTuan());
            }
            else if (selected == "Thống kê doanh thu theo tháng")
            {
                LoadUserControl(new ucThongKeThang());
            }
            else if (selected == "Thống kê sản phẩm bán chạy")
            {
                LoadUserControl(new ucThongKeSPBan());
            }
            else if (selected == "Thống kê sản phẩm tồn kho")
            {
                LoadUserControl(new ucThongKeTK());
            }
            else if (selected == "Thống kê khách hàng tiềm năng")
            {
                LoadUserControl(new ucThongKeKHTN());
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
