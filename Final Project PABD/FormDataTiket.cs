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
            refreshform();
        }

        private void GetDataFromDatabase(string searchTerm = "")
        {
            koneksi.Open();
            string str;

            if (string.IsNullOrEmpty(searchTerm))
            {
                str = "SELECT * FROM dbo.Tiket";
            }
            else
            {
                str = "SELECT * FROM dbo.Tiket WHERE id_tiket LIKE @searchTerm OR nm_kereta LIKE @searchTerm OR no_kursi LIKE @searchTerm OR keberangkatan LIKE @searchTerm OR tujuan LIKE @searchTerm";
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
            cbxIDStasiun.Text = "";
            cbxIDStasiun.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void FormDataTiket_Load(object sender, EventArgs e)
        {
            
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
            tbxIDTiket.Enabled = true;
            tbxNoKursi.Enabled = true;
            cbxKeberangkatan.Enabled = true;
            cbxTujuan.Enabled = true;
            cbxNamaKereta.Enabled = true;
            cbxIDStasiun.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            namakereta();
            tjn();
            kbrangktn();
            idstas();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id_tiket = tbxIDTiket.Text;
            string nm_kereta = cbxNamaKereta.Text;
            string no_kursi = tbxNoKursi.Text;
            string tujuan = cbxTujuan.Text;
            string keberangkatan = cbxKeberangkatan.Text;
            string id_stasiun = cbxIDStasiun.Text;

            if (id_tiket == "" || nm_kereta == "" || no_kursi == "" || tujuan == "" || id_stasiun == ""|| keberangkatan == "")
            {
                MessageBox.Show("Harap masukkan semua data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Tiket (id_tiket, nm_kereta, no_kursi, tujuan, keberangkatan) VALUES (@id_tiket, @nm_kereta, @no_kursi, @tujuan, @keberangkatan)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_tiket", id_tiket));
                cmd.Parameters.Add(new SqlParameter("@nm_kereta", nm_kereta));
                cmd.Parameters.Add(new SqlParameter("@no_kursi", no_kursi));
                cmd.Parameters.Add(new SqlParameter("@tujuan", tujuan));
                cmd.Parameters.Add(new SqlParameter("@keberangkatan", keberangkatan));
                cmd.Parameters.Add(new SqlParameter("@id_stasiun", id_stasiun));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                dataGridView_CellContent();
                refreshform();
            }
        }
        private void dataGridView_CellContent()
        {
            koneksi.Open();
            string str = "select * From dbo.Tiket";
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
        private void namakereta()
        {
            koneksi.Open();
            string str = "select nm_kereta from dbo.Kereta";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxNamaKereta.DisplayMember = "nm_kereta";
            cbxNamaKereta.ValueMember = "nm_kereta";
            cbxNamaKereta.DataSource = ds.Tables[0];
        }
        private void tjn()
        {
            koneksi.Open();
            string str = "select tujuan from dbo.Stasiun";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxTujuan.DisplayMember = "tujuan";
            cbxTujuan.ValueMember = "tujuan";
            cbxTujuan.DataSource = ds.Tables[0];
        }
        private void kbrangktn()
        {
            koneksi.Open();
            string str = "select keberangkatan from dbo.Stasiun";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxKeberangkatan.DisplayMember = "keberangkatan";
            cbxKeberangkatan.ValueMember = "keberangkatan";
            cbxKeberangkatan.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HapusData();
        }
        private void HapusData()
        {
            string id_tiket = tbxIDTiket.Text;
            if (id_tiket == "")
            {
                MessageBox.Show("Masukkan ID tiket yang ingin dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    koneksi.Open();
                    string str = "DELETE FROM dbo.Tiket WHERE id_tiket = @id_tiket";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id_tiket", id_tiket));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    koneksi.Close();
                    dataGridView_CellContent();
                    refreshform();
                }
            }
        }

        private void cbxNamaKereta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxTujuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxKeberangkatan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxNoKursi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["id_tiket"].Value.ToString();
            string nmkereta = cbxNamaKereta.Text;
            string nokursi = tbxNoKursi.Text;
            string keberangkatan = cbxKeberangkatan.Text;
            string tujuan = cbxTujuan.Text;
            string id_stasiun=cbxIDStasiun.Text;

            if (id == "")
            {
                MessageBox.Show("ID Suplier tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nmkereta == "")
            {
                MessageBox.Show("Masukkan Nama kereta", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nokursi == "")
            {
                MessageBox.Show("Masukkan No Kursi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (keberangkatan == "")
            {
                MessageBox.Show("Masukkan Kota Keberangkatan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tujuan == "")
            {
                MessageBox.Show("Masukkan kota tujuan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (id_stasiun == "")
            {
                MessageBox.Show("Masukkan ID Stasiun", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE tiket SET nm_kereta = @nm_kereta, id_stasiun = @id_stasiun ,no_kursi = @no_kursi, keberangkatan = @keberangkatan, tujuan = @tujuan WHERE id_tiket = @id_tiket";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_tiket", id);
                command.Parameters.AddWithValue("@nm_kereta", nmkereta);
                command.Parameters.AddWithValue("@no_kursi", nokursi);
                command.Parameters.AddWithValue("@keberangkatan", keberangkatan);
                command.Parameters.AddWithValue("@tujuan", tujuan);
                command.Parameters.AddWithValue("@id_stasiun", id_stasiun);

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

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Panggil metode pencarian secara real-time ketika isi TextBox berubah
            string searchTerm = tbxSearch.Text;
            GetDataFromDatabase(searchTerm);
        }

        private void cbxIDStasiun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void idstas()
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
    }
}
