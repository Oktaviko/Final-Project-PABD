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
            txtIdS.Text = "";
            txtIdS.Enabled = true;
            txtIdT.Text = "";
            txtIdT.Enabled = true;
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
            txtIdS.Enabled = true;
            txtIdT.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            koneksi.Open();
            string str = "SELECT * From dbo.Stasiun";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nm_stasiun = txtNm.Text;
            string id_stasiun = txtIdS.Text;
            string id_tiket = txtIdT.Text;

            if (nm_stasiun == "" || id_stasiun == "" || id_tiket == "")
            {
                MessageBox.Show("Masukkan semua data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Stasiun (nm_stasiun, id_stasiun, id_tiket) VALUES (@nm_stasiun, @id_stasiun, @id_tiket)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nm_stasiun", nm_stasiun));
                cmd.Parameters.Add(new SqlParameter("@id_stasiun", id_stasiun));
                cmd.Parameters.Add(new SqlParameter("@id_tiket", id_tiket));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView1_CellContentClick();
                refreshform();
            }
        }
    }
}
