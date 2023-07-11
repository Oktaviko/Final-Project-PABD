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

        private void GetDataFromDatabase()
        {
            koneksi.Open();
            string str = "SELECT * FROM dbo.Tiket";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
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
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void FormDataTiket_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringconnection);
            refreshform();
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
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id_tiket = tbxIDTiket.Text;
            string nm_kereta = cbxNamaKereta.Text;
            string no_kursi = tbxNoKursi.Text;
            string tujuan = cbxTujuan.Text;
            string keberangkatan = cbxKeberangkatan.Text;

            if (id_tiket == "" || nm_kereta == "" || no_kursi == "" || tujuan == "" || keberangkatan == "")
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
