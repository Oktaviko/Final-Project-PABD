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
    public partial class FormDataGerbong : Form
    {
        private string connectionstring = "data source = OKTAVIKO\\YEELZY;database=FinalPABDActiveResultSets=True;User ID = sa; password = 123";
        private SqlConnection koneksi;
        private string id_gerbong, no_gerbong, kelas, kapasitas;

        public FormDataGerbong()
        {
            InitializeComponent();
        }
        private void refreshform()
        {
            txtID.Enabled = false;
            txtNO.Enabled = false;
            txtKps.Enabled = false;
            txtKls.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
        }

        private void FormDataGerbong_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNO.Text = "";
            txtKls.Text = "";
            txtKps.Text = "";
            txtID.Enabled =true;
            txtKps.Enabled =true;
            txtKls.Enabled =true;
            txtNO.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
            btnOpen.Enabled = false;
        }

        private void dataGridView1_CellContentClick()
        {

        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }
    }
}
