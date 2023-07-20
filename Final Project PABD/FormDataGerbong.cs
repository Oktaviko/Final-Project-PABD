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
    public partial class FormDataGerbong : Form
    {
        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
        private SqlConnection koneksi;

        public FormDataGerbong()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();
        }
        private void refreshform()
        {
            txtID.Text = "";
            txtID.Enabled = true;
            txtNO.Text = "";
            txtNO.Enabled = true;
            cbxKls.Enabled = false;
            cbxKls.SelectedIndex = -1;
            cbxIDKreta.Enabled = false;
            cbxIDKreta.SelectedIndex = -1;
            txtKps.Text = "";
            txtKps.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void FormDataGerbong_Load(object sender, EventArgs e)
        {
            tbxSearch.GotFocus += tbxSearch_GotFocus;
            tbxSearch.LostFocus += tbxSearch_LostFocus;

            cbxKls.Items.Add("Eksekutif");
            cbxKls.Items.Add("Bisnis");
            cbxKls.Items.Add("Ekonomi");
            cbxKls.Items.Add("Premium");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            txtNO.Enabled = true;
            txtKps.Enabled = true;
            cbxKls.Enabled = true;
            cbxIDKreta.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            id_keretaa();
        }
        private void id_keretaa()
        {
            koneksi.Open();
            string str = "select id_kereta from dbo.Kereta";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxIDKreta.DisplayMember = "id_kereta";
            cbxIDKreta.ValueMember = "id_kereta";
            cbxIDKreta.DataSource = ds.Tables[0];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
            btnOpen.Enabled = false;
        }
        private void GetDataFromDatabase(string searchTerm="")
        {
            koneksi.Open();
            string str;

            if (string.IsNullOrEmpty(searchTerm))
            {
                str = "SELECT * FROM dbo.Gerbong";
            }
            else
            {
                str = "SELECT * FROM dbo.Gerbong WHERE id_gerbong LIKE @searchTerm OR no_gerbong LIKE @searchTerm OR kelas LIKE @searchTerm OR kapasitas LIKE @searchTerm OR id_kereta LIKE @searchTerm";
            }

            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void dataGridView1_CellContentClick()
        {
            koneksi.Open();
            string str = "select * From dbo.Gerbong";
            SqlDataAdapter da = new SqlDataAdapter( str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void cbxKls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id_gerbong = txtID.Text;
            string no_gerbong = txtNO.Text;
            string kelas = cbxKls.Text;
            string kapasitas = txtKps.Text;
            string id_kereta = cbxIDKreta.Text;

            if (id_gerbong == "" || no_gerbong == "" || kelas == "" || kapasitas == "" || id_kereta == "")
            {
                MessageBox.Show("Harap Semuannya", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Gerbong (id_gerbong, no_gerbong, kelas, kapasitas, id_kereta) VALUES (@id_gerbong, @no_gerbong, @kelas, @kapasitas, @id_kereta)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text; 
                cmd.Parameters.Add(new SqlParameter("@id_gerbong", id_gerbong));
                cmd.Parameters.Add(new SqlParameter("@no_gerbong", no_gerbong));
                cmd.Parameters.Add(new SqlParameter("@kelas", kelas));
                cmd.Parameters.Add(new SqlParameter("@kapasitas", kapasitas));
                cmd.Parameters.Add(new SqlParameter("@id_kereta", id_kereta));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView1_CellContentClick();
                refreshform();
            }
        }
        private void DeleteData()
        {
            string id_gerbong = txtID.Text;
            if (id_gerbong == "")
            {
                MessageBox.Show("Masukkan ID Gerbong yang ingin di hapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Gerbong WHERE id_gerbong = @id_gerbong";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id_gerbong", id_gerbong));
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
            DeleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["id_gerbong"].Value.ToString();
            string nogerbong = txtNO.Text;
            string kelas = cbxKls.Text;
            string kapasitas = txtKps.Text;
            string idkereta = cbxIDKreta.Text;

            if (id == "")
            {
                MessageBox.Show("Id Gerbong tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nogerbong == "")
            {
                MessageBox.Show("Masukkan No Gerbong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kelas == "")
            {
                MessageBox.Show("Masukkan Kelas ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kapasitas == "")
            {
                MessageBox.Show("Masukkan Kapasitas Gerbong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idkereta == "")
            {
                MessageBox.Show("Masukkan Id kereta", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE gerbong SET no_gerbong = @no_gerbong, kelas = @kelas, kapasitas = @kapasitas, id_kereta = @id_kereta WHERE id_gerbong = @id_gerbong";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_gerbong", id);
                command.Parameters.AddWithValue("@no_gerbong", nogerbong);
                command.Parameters.AddWithValue("@kelas", kelas);
                command.Parameters.AddWithValue("@kapasitas", kapasitas);
                command.Parameters.AddWithValue("@id_kereta", idkereta);

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

        private void txtNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKps_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxIDKreta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Panggil metode pencarian secara real-time ketika isi TextBox berubah
            string searchTerm = tbxSearch.Text;
            GetDataFromDatabase(searchTerm);
        }
        private void tbxSearch_GotFocus(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Search")
            {
                tbxSearch.Text = "";
            }
        }

        private void tbxSearch_LostFocus(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "")
            {
                tbxSearch.Text = "Search";
            }
        }
    }
}
