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
    public partial class ucThongKeKHTN: UserControl
    {
        public ucThongKeKHTN()
        {
            InitializeComponent();
        }
        private ThongKeBUS thongKeBUS = new ThongKeBUS();

        private void ucThongKeKHTN_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            VeBieuDoKhachHangTiemNang();
        }

        private void mlblTaoBaoCao_Click(object sender, EventArgs e)
        {
            VeBieuDoKhachHangTiemNang();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpNgayBatDau.Value.Date;
            DateTime denNgay = dtpNgayKetThuc.Value.Date;
            int top = 10;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo khách hàng tiềm năng";
                sfd.FileName = "BaoCaoKhachHangTiemNang.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatTopKhachHangMuaNhieuNhatRaExcel_Interop(tuNgay, denNgay, top, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void VeBieuDoKhachHangTiemNang()
        {
            DateTime tuNgay = dtpNgayBatDau.Value.Date;
            DateTime denNgay = dtpNgayKetThuc.Value.Date;
            int top = 10;

            var list = thongKeBUS.LayTopKhachHangMuaNhieuNhatTheoNgay(tuNgay, denNgay, top);

            chart1.Series.Clear();
            Series series = new Series("Khách hàng tiềm năng");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            if (list.Count == 0)
            {
                series.Points.AddXY("Không có khách hàng", 0);
            }
            else
            {
                foreach (var item in list)
                {
                    // Hiển thị tên khách hàng trên trục X, tổng tiền trên trục Y
                    series.Points.AddXY(item.TenKhach, item.TongTienMua);
                }
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Khách hàng";
            chart1.ChartAreas[0].AxisY.Title = "Tổng tiền mua (VNĐ)";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }
    }
}
