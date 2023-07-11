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
        private string stringconnection = "data source = OKTAVIKO\\YEELZY;database=FinalPABD;MultipleActiveResultSets=True;User ID = sa; password = 123";
        private SqlConnection koneksi;
        public FormDataPelanggan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();

        }
        private void refreshform()
        {
            txtNama.Text = "";
            txtNama.Enabled = true;
            txtNIK.Text = "";
            txtNIK.Enabled = true;
            txtAlamat.Text = "";
            txtAlamat.Enabled = true;
            txtNohp.Text = "";
            txtNohp.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
            btnOpen.Enabled = false;
        }

        private void dataGridView1_CellContentClick()
        {
            koneksi.Open();
            string str = "select * From dbo.Pelanggan";
            SqlDataAdapter da = new SqlDataAdapter(str , koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtNama.Enabled = true;
            txtNIK.Enabled = true;
            txtAlamat.Enabled = true;
            txtNohp.Enabled = true;
            btnAdd .Enabled = false;
            btnSave .Enabled = true;
            btnClear .Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
    }
}
