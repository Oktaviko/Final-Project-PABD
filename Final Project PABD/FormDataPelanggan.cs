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
        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
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
        private void HapusData()
        {
            string NIK = txtNIK.Text;
            if (NIK == "" )
            {
                MessageBox.Show("Masukkan NIK yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Pelanggan WHERE nik = @nik";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@nik", NIK));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    koneksi.Close();
                    dataGridView1_CellContentClick();
                    refreshform();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["NIK"].Value.ToString();
            string nama = txtNama.Text;
            string no_hp = txtNohp.Text;
            string alamat = txtAlamat.Text;

            if (id == "")
            {
                MessageBox.Show("NIK  tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nama == "")
            {
                MessageBox.Show("Masukkan Nama Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (no_hp == "")
            {
                MessageBox.Show("Masukkan Alamat Suplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (alamat == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string sql = "UPDATE pelanggan SET nama = @nama, no_hp = @no_hp, alamat = @alamat where NIK = @NIK";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@NIK", id);
                command.Parameters.AddWithValue("@nama", nama);
                command.Parameters.AddWithValue("@no_hp", no_hp);
                command.Parameters.AddWithValue("@alamat", alamat);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                        GetDataFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
