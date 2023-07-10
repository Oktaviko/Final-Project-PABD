using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_PABD
{
    public partial class FormDataKereta : Form
    {
        public FormDataKereta()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick()
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
            btnOpen.Enabled = false;
        }

        private void FormDataKereta_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HalamanUtama HU = new HalamanUtama();
            HU.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
    }
}
