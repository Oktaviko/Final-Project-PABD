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
    public partial class FormDataKereta : Form
    {
        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
        private SqlConnection koneksi;
        public FormDataKereta()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
            btnOpen.Enabled = false;
        }

        private void FormDataKereta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalPABDDataSet.Kereta' table. You can move, or remove it, as needed.
            this.keretaTableAdapter.Fill(this.finalPABDDataSet.Kereta);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void tbxNamaKereta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxIDKereta_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxJenisKereta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshform()
        {
            tbxIDKereta.Text = "";
            tbxIDKereta.Enabled = true;
            tbxNamaKereta.Text = "";
            tbxNamaKereta.Enabled = true;
            cbxJenisKereta.Enabled = false;
            cbxJenisKereta.SelectedIndex = -1;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbxNamaKereta.Enabled = true;
            tbxIDKereta.Enabled=true;
            cbxJenisKereta .Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void dataGridView1_CellContentClick()
        {
            koneksi.Open();
            string str = "select * From dbo.Kereta";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
    }
}
