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
        private void GetDataFromDatabase()
        {
            koneksi.Open();
            string str = "SELECT * FROM dbo.Pelanggan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Nama = txtNama.Text;
            string NIK = txtNIK.Text;
            string NoHP = txtNohp.Text;
            string Alamat = txtAlamat.Text;

            if (Nama == "" || NIK == "" || Alamat == "" || NoHP == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Pelanggan (nama, nik, alamat, no_hp) VALUES (@nama, @nik, @alamat, @no_hp)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nama", Nama));
                cmd.Parameters.Add(new SqlParameter("@nik", NIK));
                cmd.Parameters.Add(new SqlParameter("@no_hp", NoHP));
                cmd.Parameters.Add(new SqlParameter("@alamat", Alamat));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView1_CellContentClick();
                refreshform();
            }
        }
    }
}
