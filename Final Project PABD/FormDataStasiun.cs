using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_PABD
{
    public partial class FormDataStasiun : Form
    {
        private string stringconnection = "";
        private SqlConnection koneksi;
        
        public FormDataStasiun()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            
        }
        private void refreshform()
        {
            txtNm.Text = "";
            txtNm.Enabled = true;
            txtKota.Text = "";
            txtKota.Enabled = true;
            txtIdS.Text = "";
            txtIdS.Enabled = true;
            txtIdK.Text = "";
            txtIdK.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void GetDataFromDatabase()
        {
            koneksi.Open();
            string str = "SELECT * FROM dbo.Stasiun";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void FormDataStasiun_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
           txtNm.Enabled = true;
           txtKota.Enabled = true;
            txtIdS.Enabled = true;
            txtIdK.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        
        }
    }
}
