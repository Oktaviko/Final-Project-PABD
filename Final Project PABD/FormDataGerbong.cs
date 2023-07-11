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
        private string stringconnection = "data source = OKTAVIKO\\YEELZY;database=FinalPABDActiveResultSets=True;User ID = sa; password = 123";
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
            txtKps.Text = "";
            txtKps.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void FormDataGerbong_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNO.Text = "";
            cbxKls.Text = "";
            txtKps.Text = "";
            txtID.Enabled =true;
            txtKps.Enabled =true;
            cbxKls.Enabled =true;
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
