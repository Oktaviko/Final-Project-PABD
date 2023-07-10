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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
