﻿using System;
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
    public partial class FormDataTiket : Form
    {
        public FormDataTiket()
        {
            InitializeComponent();
        }

        private void FormDataTiket_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick()
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
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
    }
}
