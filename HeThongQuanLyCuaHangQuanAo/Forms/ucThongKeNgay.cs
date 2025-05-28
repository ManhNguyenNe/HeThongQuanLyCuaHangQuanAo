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
    public partial class ucThongKeNgay: UserControl
    {   private ThongKeBUS thongKeBUS = new ThongKeBUS();
        public ucThongKeNgay()
        {
            InitializeComponent();
        }

        private void ucThongKeNgay_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            VeBieuDoDoanhThuNgay();
        }

        private void mlblTaoBaoCao_Click(object sender, EventArgs e)
        {
            VeBieuDoDoanhThuNgay();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpNgayBatDau.Value;
            DateTime denNgay = dtpNgayKetThuc.Value;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo doanh thu theo ngày";
                sfd.FileName = "BaoCaoDoanhThuNgay.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatDoanhThuTheoNgayRaExcel_Interop(tuNgay, denNgay, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void VeBieuDoDoanhThuNgay()
        {
            DateTime tuNgay = dtpNgayBatDau.Value;
            DateTime denNgay = dtpNgayKetThuc.Value;

            chart1.Series.Clear();
            Series series = new Series("Doanh thu (VNĐ)");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            for (DateTime date = tuNgay.Date; date <= denNgay.Date; date = date.AddDays(1))
            {
                decimal doanhThu = thongKeBUS.LayTongDoanhThuTheoNgay(date);
                series.Points.AddXY(date.ToString("dd/MM/yyyy"), doanhThu);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
        }

    }
}
