using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Doanhthu : Form
    {
        public Doanhthu()
        {
            InitializeComponent();
        }

        private void Doanhthu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Size = new System.Drawing.Size(1920, 1080);
        }
    }
}
