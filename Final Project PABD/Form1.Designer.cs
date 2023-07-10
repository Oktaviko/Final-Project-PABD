namespace Final_Project_PABD
{
    partial class HalamanUtama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalamanUtama));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dataStasiunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataKeretaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPelangganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGerbongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTiketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.toolStripDropDownButton1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(911, 27);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataStasiunToolStripMenuItem,
            this.dataKeretaToolStripMenuItem,
            this.dataPelangganToolStripMenuItem,
            this.dataGerbongToolStripMenuItem,
            this.dataTiketToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(60, 24);
            this.toolStripDropDownButton1.Text = "DATA";
            // 
            // dataStasiunToolStripMenuItem
            // 
            this.dataStasiunToolStripMenuItem.Name = "dataStasiunToolStripMenuItem";
            this.dataStasiunToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataStasiunToolStripMenuItem.Text = "Data Stasiun";
            this.dataStasiunToolStripMenuItem.Click += new System.EventHandler(this.dataStasiunToolStripMenuItem_Click);
            // 
            // dataKeretaToolStripMenuItem
            // 
            this.dataKeretaToolStripMenuItem.Name = "dataKeretaToolStripMenuItem";
            this.dataKeretaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataKeretaToolStripMenuItem.Text = "Data  Kereta";
            this.dataKeretaToolStripMenuItem.Click += new System.EventHandler(this.dataKeretaToolStripMenuItem_Click);
            // 
            // dataPelangganToolStripMenuItem
            // 
            this.dataPelangganToolStripMenuItem.Name = "dataPelangganToolStripMenuItem";
            this.dataPelangganToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataPelangganToolStripMenuItem.Text = "Data Pelanggan";
            this.dataPelangganToolStripMenuItem.Click += new System.EventHandler(this.dataPelangganToolStripMenuItem_Click);
            // 
            // dataGerbongToolStripMenuItem
            // 
            this.dataGerbongToolStripMenuItem.Name = "dataGerbongToolStripMenuItem";
            this.dataGerbongToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataGerbongToolStripMenuItem.Text = "Data Gerbong";
            this.dataGerbongToolStripMenuItem.Click += new System.EventHandler(this.dataGerbongToolStripMenuItem_Click);
            // 
            // dataTiketToolStripMenuItem
            // 
            this.dataTiketToolStripMenuItem.Name = "dataTiketToolStripMenuItem";
            this.dataTiketToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataTiketToolStripMenuItem.Text = "Data Tiket";
            this.dataTiketToolStripMenuItem.Click += new System.EventHandler(this.dataTiketToolStripMenuItem_Click);
            // 
            // HalamanUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 510);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "HalamanUtama";
            this.Text = "MENU";
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem dataStasiunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataKeretaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPelangganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataGerbongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataTiketToolStripMenuItem;
    }
}

