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
    public partial class FormDataTiket : Form
    {

        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
        private SqlConnection koneksi;


        public FormDataTiket()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
        }

        private void GetDataFromDatabase()
        {
            koneksi.Open();
            string str = "SELECT * FROM dbo.Tiket";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void refreshform()
        {
            tbxIDTiket.Text = "";
            tbxIDTiket.Enabled = true;
            tbxNoKursi.Text = "";
            tbxNoKursi.Enabled = true;
            cbxKeberangkatan.Text = "";
            cbxKeberangkatan.Enabled = true;
            cbxNamaKereta.Text = "";
            cbxNamaKereta.Enabled = true;
            cbxTujuan.Text = "";
            cbxTujuan.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void FormDataTiket_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
            btnOpen.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
