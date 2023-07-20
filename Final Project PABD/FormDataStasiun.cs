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
        private string stringconnection = "data source=LAPTOP-NAUFALAS\\NAUFALAS;" + "database=FinalPABD;user ID=sa;password=bahtera1234";
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
            tbxKbr.Text = "";
            tbxKbr.Enabled = true;
            tbxTujuan.Text = "";
            tbxTujuan.Enabled = true;
            txtIdS.Text = "";
            txtIdS.Enabled = true;
            cbxTikt.Text = "";
            cbxTikt.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void GetDataFromDatabase(string searchTerm="")
        {
            koneksi.Open();
            string str;

            if (string.IsNullOrEmpty(searchTerm))
            {
                str = "SELECT * FROM dbo.Stasiun";
            }
            else
            {
                str = "SELECT * FROM dbo.Stasiun WHERE nm_stasiun LIKE @searchTerm OR keberangkatan LIKE @searchTerm OR tujuan LIKE @searchTerm";
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
            tbxTujuan.Enabled = true;
            tbxKbr.Enabled = true;
            txtIdS.Enabled = true;
            cbxTikt.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            foreignkey();

        
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
            string id_tiket = cbxTikt.Text;
            string tujuan = tbxTujuan.Text;
            string keberangkatan = tbxKbr.Text;

            if (nm_stasiun == "" || id_stasiun == "" || id_tiket == "" || tujuan == "" || keberangkatan == "")
            {
                MessageBox.Show("Masukkan semua data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Stasiun (nm_stasiun, id_stasiun, id_tiket, tujuan, keberangkatan) VALUES (@nm_stasiun, @id_stasiun, @id_tiket, @tujuan, @keberangkatan)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nm_stasiun", nm_stasiun));
                cmd.Parameters.Add(new SqlParameter("@id_stasiun", id_stasiun));
                cmd.Parameters.Add(new SqlParameter("@id_tiket", id_tiket));
                cmd.Parameters.Add(new SqlParameter("@tujuan", tujuan));
                cmd.Parameters.Add(new SqlParameter("@keberangkatan", keberangkatan));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView1_CellContentClick();
                refreshform();
            }
        }
        private void HapusData()
        {
            string id_stasiun = txtIdS.Text;

            if (id_stasiun == "")
            {
                MessageBox.Show("Masukkan ID stasiun yang ingin dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Stasiun WHERE id_stasiun = @id_stasiun";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id_stasiun", id_stasiun));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    koneksi.Close();
                    dataGridView1_CellContentClick();
                    refreshform();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            HapusData();
        }
        private void foreignkey()
        {
            koneksi.Open();
            string str = "select id_tiket from dbo.Tiket";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxTikt.DisplayMember = "id_tiket";
            cbxTikt.ValueMember = "id_tiket";
            cbxTikt.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["id_stasiun"].Value.ToString();
            string namastasiun = txtNm.Text;
            string keberangkatan = tbxKbr.Text;
            string tujuan = tbxTujuan.Text;

            if (id == "")
            {
                MessageBox.Show("ID Stasiun tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (namastasiun == "")
            {
                MessageBox.Show("Masukkan Nama Stasiun", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (keberangkatan == "")
            {
                MessageBox.Show("Masukkan Kota Keberangkatan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tujuan == "")
            {
                MessageBox.Show("Masukkan Kota Tujuan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string sql = "UPDATE stasiun SET nm_stasiun = @nm_stasiun, keberangkatan = @keberangkatan, tujuan = @tujuan WHERE id_stasiun = @id_stasiun";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_stasiun", id);
                command.Parameters.AddWithValue("@nm_stasiun", namastasiun);
                command.Parameters.AddWithValue("@keberangkatan", keberangkatan);
                command.Parameters.AddWithValue("@tujuan", tujuan);

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

        private void tbxTujuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxKbr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxTikt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIdS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNm_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbxSearch.Text;
            GetDataFromDatabase(searchTerm);
        }
    }
}
