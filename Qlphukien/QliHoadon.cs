using Qlphukien.DAO;
using Qlphukien.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlphukien
{
    public partial class QliHoadon : Form
    {
        HoaDonDao hdDao = new HoaDonDao();
        ChiTietHoaDonDAO ChiTietHoaDonDAO = new ChiTietHoaDonDAO();
        public QliHoadon()
        {
            InitializeComponent();
        }

        private void QliHoadon_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            displayHD(dgvHoaDon, hdDao.getAllHD());
        }

        private void btnRefreshHD_Click(object sender, EventArgs e)
        {
            displayHD(dgvHoaDon, hdDao.getAllHD());
        }

        private void displayHD(DataGridView dgv, List<HoaDon> list)
        {
            dgv.Rows.Clear();

            dgv.ColumnCount = 4;

            int i = 0;
            foreach (HoaDon item in list)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = item.MaHD;
                dgv.Rows[i].Cells[1].Value = item.MaNV;
                dgv.Rows[i].Cells[2].Value = item.NgayLap;
                dgv.Rows[i].Cells[2].Value = item.TongTienHD;
                i++;
            }
        }
    }
}
