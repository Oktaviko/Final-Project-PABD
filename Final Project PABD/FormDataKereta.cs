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
            GetDataFromDatabase(); // Memanggil method untuk mengambil data dari database dan mengisi DataGridView
            btnOpen.Enabled = false;
        }

        private void GetDataFromDatabase(string pencarian ="")
        {
            koneksi.Open();
            string str;

            if (string.IsNullOrEmpty(pencarian))
            {
                str = "SELECT * FROM dbo.Kereta";
            }
            else
            {
                str = "SELECT * FROM dbo.Kereta WHERE nm_kereta LIKE @pencarian OR jns_kereta LIKE @pencarian OR id_kereta LIKE @pencarian OR id_stasiun LIKE @pencarian";
            }

            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            if (!string.IsNullOrEmpty(pencarian))
            {
                da.SelectCommand.Parameters.AddWithValue("@pencarian", "%" + pencarian + "%");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void FormDataKereta_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalPABDDataSet.Kereta' table. You can move, or remove it, as needed.
            this.keretaTableAdapter.Fill(this.finalPABDDataSet.Kereta);

            cbxJenisKereta.Items.Add("KRL");
            cbxJenisKereta.Items.Add("KAJJ");
            cbxJenisKereta.Items.Add("KL");

        }
        private void id_staisunn()
        {
            koneksi.Open();
            string str = "select id_stasiun from dbo.Stasiun";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxIDStasiun.DisplayMember = "id_stasiun";
            cbxIDStasiun.ValueMember = "id_stasiun";
            cbxIDStasiun.DataSource = ds.Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string NamaKereta = tbxNamaKereta.Text;
            string JenisKereta = cbxJenisKereta.Text;
            string IDKereta = tbxIDKereta.Text;
            string IDStasiun = cbxIDStasiun.Text;

            if (NamaKereta  == "" || JenisKereta == "" || IDKereta == "" || IDStasiun=="")
            {
                MessageBox.Show("Masukkan Semuannya", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Kereta (nm_kereta, jns_Kereta, id_Kereta, id_stasiun) VALUES (@nm_kereta, @jns_Kereta, @id_Kereta, @id_stasiun)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nm_kereta", NamaKereta));
                cmd.Parameters.Add(new SqlParameter("@jns_Kereta", JenisKereta));
                cmd.Parameters.Add(new SqlParameter("@id_Kereta", IDKereta));
                cmd.Parameters.Add(new SqlParameter("@id_stasiun", IDStasiun));
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();
                // Memanggil metode GetDataFromDatabase() untuk mengambil data terbaru dari database
                GetDataFromDatabase();

            }

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
            cbxIDStasiun.Enabled = false;
            cbxIDStasiun.SelectedIndex = -1;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbxNamaKereta.Enabled = true;
            tbxIDKereta.Enabled=true;
            cbxJenisKereta .Enabled = true;
            cbxIDStasiun .Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            id_staisunn();
            // Memanggil metode GetDataFromDatabase() untuk mengambil data terbaru dari database
            GetDataFromDatabase();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
         

        private void DeleteData()
        {
            string IDKereta = tbxIDKereta.Text;

            if (IDKereta == "")
            {
                MessageBox.Show("Masukkan ID Kereta yang ingin dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Kereta WHERE id_kereta = @id_kereta";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id_kereta", IDKereta));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    koneksi.Close();
                    dataGridView1_CellContentClick();
                    refreshform();
                    // Memanggil metode GetDataFromDatabase() untuk mengambil data terbaru dari database
                    GetDataFromDatabase();
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void keretaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cbxIDStasiun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["Id_kereta"].Value.ToString();
            string NamaKereta = tbxNamaKereta.Text;
            string JenisKereta = cbxJenisKereta.Text;
            string IDStasiun = cbxIDStasiun.Text;

            if (id == "")
            {
                MessageBox.Show("ID Kereta tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NamaKereta == "")
            {
                MessageBox.Show("Masukkan Nama Kereta", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (JenisKereta == "")
            {
                MessageBox.Show("Masukkan Jenis Kereta", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IDStasiun == "")
            {
                MessageBox.Show("Masukkan ID Stasiun", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string sql = "UPDATE kereta SET nm_kereta = @nm_kereta, jns_kereta = @jns_kereta, id_stasiun = @id_stasiun WHERE Id_kereta = @id_kereta";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_kereta", id);
                command.Parameters.AddWithValue("@nm_kereta", NamaKereta);
                command.Parameters.AddWithValue("@jns_kereta", JenisKereta);
                command.Parameters.AddWithValue("@id_stasiun", IDStasiun);

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
                // Memanggil metode GetDataFromDatabase() untuk mengambil data terbaru dari database
                GetDataFromDatabase();
            }
        }


        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Panggil metode pencarian secara real-time ketika isi TextBox berubah
            string searchTerm = tbxSearch.Text;
            GetDataFromDatabase(searchTerm);
        }
    }
}
