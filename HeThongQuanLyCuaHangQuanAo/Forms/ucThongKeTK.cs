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
    public partial class ucThongKeTK: UserControl
    {
        public ucThongKeTK()
        {
            InitializeComponent();
        }
        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        private void ucThongKeTK_Load(object sender, EventArgs e)
        {   
            VeBieuDoTonKho();
        }

        private void mlblXuatBaoCao_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Chọn nơi lưu báo cáo tồn kho";
                sfd.FileName = "BaoCaoTonKho.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thongKeBUS.XuatTonKhoHienTaiRaExcel_Interop(sfd.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void VeBieuDoTonKho()
        {
            var list = thongKeBUS.BaoCaoTonKhoHienTai();

            chart1.Series.Clear();
            Series series = new Series("Tồn kho");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            if (list.Count == 0)
            {
                series.Points.AddXY("Không có sản phẩm", 0);
            }
            else
            {
                foreach (var item in list)
                {
                    series.Points.AddXY(item.TenQuanAo, item.TonKho);
                }
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Sản phẩm";
            chart1.ChartAreas[0].AxisY.Title = "Tồn kho";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }
    }
}
