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
    public partial class ucThongKeSPBan: UserControl
    {
        public ucThongKeSPBan()
        {
            InitializeComponent();
        }
        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        private void ucThongKeSPBan_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            VeBieuDoSanPhamBanChay();
        }

        private void VeBieuDoSanPhamBanChay()
        {
            DateTime tuNgay = dtpNgayBatDau.Value.Date;
            DateTime denNgay = dtpNgayKetThuc.Value.Date;
            int top = 10; // Top 10 sản phẩm bán chạy trong khoảng ngày

            // Lấy danh sách sản phẩm bán chạy theo khoảng ngày
            var list = thongKeBUS.LayTopSanPhamBanChayTheoNgay(tuNgay, denNgay, top);

            chart1.Series.Clear();
            Series series = new Series("Sản phẩm bán chạy");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            if (list.Count == 0)
            {
                // Nếu không có sản phẩm nào bán, hiển thị cột 0
                series.Points.AddXY("Không có sản phẩm", 0);
            }
            else
            {
                foreach (var item in list)
                {
                    series.Points.AddXY(item.TenQuanAo, item.SoLuongBan);
                }
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Sản phẩm";
            chart1.ChartAreas[0].AxisY.Title = "Số lượng bán";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Xoay tên sản phẩm cho dễ nhìn
        }

        private void mlblTaoBaoCao_Click(object sender, EventArgs e)
        {
            VeBieuDoSanPhamBanChay();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpNgayBatDau.Value.Date;
            DateTime denNgay = dtpNgayKetThuc.Value.Date;
            int top = 10; // Top 10 sản phẩm bán chạy

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo sản phẩm bán chạy";
                sfd.FileName = "BaoCaoSanPhamBanChay.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatSanPhamBanChayRaExcel_Interop(tuNgay, denNgay, top, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
