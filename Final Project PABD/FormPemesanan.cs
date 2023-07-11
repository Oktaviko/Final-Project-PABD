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
    public partial class FormPemesanan : Form
    {
        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
        private SqlConnection koneksi;
        public FormPemesanan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();
        }
        private void refreshform()
        {
            tbxIDpesan.Text = "";
            tbxIDpesan.Enabled = true;
            cbxIDTiket.SelectedIndex = -1;
            cbxIDTiket.Enabled = false;
            cbxNIK.Enabled = false;
            cbxNIK.SelectedIndex = -1;
            cbxNohp.Enabled = false;
            cbxNohp.SelectedIndex = -1;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void FormPemesanan_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase(); // Memanggil method untuk mengambil data dari database dan mengisi DataGridView
            btnOpen.Enabled = false;
        }
        private void GetDataFromDatabase()
        {
            koneksi.Open();
            string str = "SELECT * FROM dbo.Pemesanan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id_pemesanan = tbxIDpesan.Text;
            string id_tiket = cbxIDTiket.Text;
            string nik = cbxNIK.Text;
            string no_hp = cbxNohp.Text;

            if (id_pemesanan == "" || id_tiket == "" || nik == "" || no_hp == "")
            {
                MessageBox.Show("Harap Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Pemesanan (id_pemesanan, id_tiket, nik, no_hp) VALUES (@id_pemesanan, @id_tiket, @nik, @no_hp)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_pemesanan", id_pemesanan));
                cmd.Parameters.Add(new SqlParameter("@id_tiket", id_tiket));
                cmd.Parameters.Add(new SqlParameter("@nik", nik));
                cmd.Parameters.Add(new SqlParameter("@no_hp", no_hp));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView1_CellContentClick();
                refreshform();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbxIDpesan.Enabled = true;
            cbxIDTiket.Enabled = true;
            cbxNIK.Enabled = true;
            cbxNohp.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            no_hape();
            id_tikett();
            nikk();
            
        }
        private void dataGridView1_CellContentClick()
        {
            koneksi.Open();
            string str = "select * From dbo.Pemesanan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
        private void HapusData()
        {
            string id_pemesanan = tbxIDpesan.Text;

            if (id_pemesanan == "")
            {
                MessageBox.Show("Masukkan ID pemesanan yang ingin dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Pemesanan WHERE id_pemesanan = @id_pemesanan";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id_pemesanan", id_pemesanan));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    koneksi.Close();
                    dataGridView1_CellContentClick();
                    refreshform();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HapusData();
        }
        private void id_tikett()
        {
            koneksi.Open();
            string str = "select id_tiket from dbo.Tiket";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxIDTiket.DisplayMember = "id_tiket";
            cbxIDTiket.ValueMember = "id_tiket";
            cbxIDTiket.DataSource = ds.Tables[0];
        }
        private void nikk()
        {
            koneksi.Open();
            string str = "select nik from dbo.Pelanggan";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxNIK.DisplayMember = "nik";
            cbxNIK.ValueMember = "nik";
            cbxNIK.DataSource = ds.Tables[0];
        }
        private void no_hape()
        {
            koneksi.Open();
            string str = "select no_hp from dbo.Pelanggan";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxNohp.DisplayMember = "no_hp";
            cbxNohp.ValueMember = "no_hp";
            cbxNohp.DataSource = ds.Tables[0];
        }
    }
}
