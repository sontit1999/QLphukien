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
    public partial class QLnhanvien : Form
    {
        public QLnhanvien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QLnhanvien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            // custom display date
            dateTimePickerNgaysinh.CustomFormat = "dd/MM/yyyy";
            // set default time
            dateTimePickerNgaysinh.Value = new DateTime(1997, 10, 10);

        }
    }
}
