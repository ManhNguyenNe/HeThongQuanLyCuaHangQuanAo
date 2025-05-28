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
    public partial class ucThongKeThang: UserControl
    {
        public ucThongKeThang()
        {
            InitializeComponent();
        }

        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        private void ucThongKeThang_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            VeBieuDoDoanhThu();
        }

        private void VeBieuDoDoanhThu()
        {
            DateTime tuNgay = dtpNgayBatDau.Value;
            DateTime denNgay = dtpNgayKetThuc.Value;

            chart1.Series.Clear();
            Series series = new Series("Doanh thu (VNĐ)");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột

            DateTime start = new DateTime(tuNgay.Year, tuNgay.Month, 1);
            DateTime end = new DateTime(denNgay.Year, denNgay.Month, 1);

            for (DateTime date = start; date <= end; date = date.AddMonths(1))
            {
                int thang = date.Month;
                int nam = date.Year;
                decimal doanhThu = thongKeBUS.LayTongDoanhThuTheoThang(thang, nam);

                series.Points.AddXY($"{thang}/{nam}", doanhThu);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Tháng/Năm";
            chart1.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
        }

        private void mlblTaoBaoCao_Click(object sender, EventArgs e)
        {

            VeBieuDoDoanhThu();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpNgayBatDau.Value;
            DateTime denNgay = dtpNgayKetThuc.Value;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo doanh thu theo tháng";
                sfd.FileName = "BaoCaoDoanhThuThang.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatDoanhThuTheoThangRaExcel_Interop(tuNgay, denNgay, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
