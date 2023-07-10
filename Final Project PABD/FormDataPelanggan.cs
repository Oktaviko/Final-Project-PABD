using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_PABD
{
    public partial class FormDataPelanggan : Form
    {
        private string connectionstring = "data source = OKTAVIKO\\YEELZY;database=FinalPABD;MultipleActiveResultSets=True;User ID = sa; password = 123";
        private SqlConnection connection;
        public FormDataPelanggan()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionstring);

        }
        private void refreshform()
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
            btnOpen.Enabled = false;
        }

        private void dataGridView1_CellContentClick()
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void FormDataPelanggan_Load(object sender, EventArgs e)
        {

        }
    }
}
