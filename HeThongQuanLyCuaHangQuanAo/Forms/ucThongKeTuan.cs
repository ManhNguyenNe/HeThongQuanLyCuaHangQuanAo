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
    public partial class ucThongKeTuan: UserControl
    {
        public ucThongKeTuan()
        {
            InitializeComponent();
        }
        private readonly ThongKeBUS thongKeBUS = new ThongKeBUS();
        private void ucThongKeTuan_Load(object sender, EventArgs e)
        {
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
            VeBieuDoDoanhThuTuan();
        }
        private void VeBieuDoDoanhThuTuan()
        {
            DateTime tuNgay = dtpNgayBatDau.Value.Date;
            DateTime denNgay = dtpNgayKetThuc.Value.Date;

            chart1.Series.Clear();
            Series series = new Series("Doanh thu (VNĐ)");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột

            DateTime start = tuNgay;
            while (start <= denNgay)
            {
                DateTime end = start.AddDays(6);
                if (end > denNgay) end = denNgay;

                decimal tongDoanhThu = thongKeBUS.LayTongDoanhThuTheoTuan(start, end);

                // Thêm cả năm vào nhãn
                string label = $"{start:dd/MM/yyyy} - {end:dd/MM/yyyy}";
                series.Points.AddXY(label, tongDoanhThu);

                start = end.AddDays(1);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Tuần";
            chart1.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
        }

        private void mlblTaoBaoCao_Click(object sender, EventArgs e)
        {
            VeBieuDoDoanhThuTuan();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpNgayBatDau.Value;
            DateTime denNgay = dtpNgayKetThuc.Value;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo doanh thu theo tuần";
                sfd.FileName = "BaoCaoDoanhThuTuan.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatDoanhThuTheoTuanRaExcel_Interop(tuNgay, denNgay, sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
