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
    public partial class HalamanUtama : Form
    {
        public HalamanUtama()
        {
            InitializeComponent();
        }

        private void dataStasiunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataStasiun fm = new FormDataStasiun();
            fm.Show();
            this.Hide();
        }

        private void dataKeretaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataKereta fm = new FormDataKereta();
            fm.Show();
            this.Hide();
        }

        private void dataPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataPelanggan fm = new FormDataPelanggan();
            fm.Show();
            this.Hide();
        }

        private void dataGerbongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataGerbong fm = new FormDataGerbong();
            fm.Show();
            this.Hide();
        }

        private void dataTiketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataTiket fm = new FormDataTiket();
            fm.Show();
            this.Hide();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HalamanUtama_Load(object sender, EventArgs e)
        {

        }

        private void dataPemesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPemesanan fm = new FormPemesanan();
            fm.Show();
            this.Hide();
        }
    }
}
