namespace Final_Project_PABD
{
    partial class FormDataKereta
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbxIDKereta = new System.Windows.Forms.TextBox();
            this.cbxJenisKereta = new System.Windows.Forms.ComboBox();
            this.tbxNamaKereta = new System.Windows.Forms.TextBox();
            this.finalPABDDataSet = new Final_Project_PABD.FinalPABDDataSet();
            this.keretaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.keretaTableAdapter = new Final_Project_PABD.FinalPABDDataSetTableAdapters.KeretaTableAdapter();
            this.nmkeretaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idkeretaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jnskeretaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idstasiunDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalPABDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keretaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmkeretaDataGridViewTextBoxColumn,
            this.idkeretaDataGridViewTextBoxColumn,
            this.jnskeretaDataGridViewTextBoxColumn,
            this.idstasiunDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.keretaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(39, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(438, 182);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Kereta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jenis Kereta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "ID Kereta";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(313, 339);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 34);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(515, 48);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 45);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(313, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 408);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbxIDKereta
            // 
            this.tbxIDKereta.Location = new System.Drawing.Point(171, 355);
            this.tbxIDKereta.Name = "tbxIDKereta";
            this.tbxIDKereta.Size = new System.Drawing.Size(121, 22);
            this.tbxIDKereta.TabIndex = 9;
            this.tbxIDKereta.TextChanged += new System.EventHandler(this.tbxIDKereta_TextChanged);
            // 
            // cbxJenisKereta
            // 
            this.cbxJenisKereta.FormattingEnabled = true;
            this.cbxJenisKereta.Location = new System.Drawing.Point(171, 306);
            this.cbxJenisKereta.Name = "cbxJenisKereta";
            this.cbxJenisKereta.Size = new System.Drawing.Size(121, 24);
            this.cbxJenisKereta.TabIndex = 11;
            this.cbxJenisKereta.SelectedIndexChanged += new System.EventHandler(this.cbxJenisKereta_SelectedIndexChanged);
            // 
            // tbxNamaKereta
            // 
            this.tbxNamaKereta.Location = new System.Drawing.Point(171, 254);
            this.tbxNamaKereta.Name = "tbxNamaKereta";
            this.tbxNamaKereta.Size = new System.Drawing.Size(121, 22);
            this.tbxNamaKereta.TabIndex = 12;
            this.tbxNamaKereta.TextChanged += new System.EventHandler(this.tbxNamaKereta_TextChanged);
            // 
            // finalPABDDataSet
            // 
            this.finalPABDDataSet.DataSetName = "FinalPABDDataSet";
            this.finalPABDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // keretaBindingSource
            // 
            this.keretaBindingSource.DataMember = "Kereta";
            this.keretaBindingSource.DataSource = this.finalPABDDataSet;
            // 
            // keretaTableAdapter
            // 
            this.keretaTableAdapter.ClearBeforeFill = true;
            // 
            // nmkeretaDataGridViewTextBoxColumn
            // 
            this.nmkeretaDataGridViewTextBoxColumn.DataPropertyName = "nm_kereta";
            this.nmkeretaDataGridViewTextBoxColumn.HeaderText = "nm_kereta";
            this.nmkeretaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nmkeretaDataGridViewTextBoxColumn.Name = "nmkeretaDataGridViewTextBoxColumn";
            this.nmkeretaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idkeretaDataGridViewTextBoxColumn
            // 
            this.idkeretaDataGridViewTextBoxColumn.DataPropertyName = "id_kereta";
            this.idkeretaDataGridViewTextBoxColumn.HeaderText = "id_kereta";
            this.idkeretaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idkeretaDataGridViewTextBoxColumn.Name = "idkeretaDataGridViewTextBoxColumn";
            this.idkeretaDataGridViewTextBoxColumn.Width = 125;
            // 
            // jnskeretaDataGridViewTextBoxColumn
            // 
            this.jnskeretaDataGridViewTextBoxColumn.DataPropertyName = "jns_kereta";
            this.jnskeretaDataGridViewTextBoxColumn.HeaderText = "jns_kereta";
            this.jnskeretaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.jnskeretaDataGridViewTextBoxColumn.Name = "jnskeretaDataGridViewTextBoxColumn";
            this.jnskeretaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idstasiunDataGridViewTextBoxColumn
            // 
            this.idstasiunDataGridViewTextBoxColumn.DataPropertyName = "id_stasiun";
            this.idstasiunDataGridViewTextBoxColumn.HeaderText = "id_stasiun";
            this.idstasiunDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idstasiunDataGridViewTextBoxColumn.Name = "idstasiunDataGridViewTextBoxColumn";
            this.idstasiunDataGridViewTextBoxColumn.Width = 125;
            // 
            // FormDataKereta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxNamaKereta);
            this.Controls.Add(this.cbxJenisKereta);
            this.Controls.Add(this.tbxIDKereta);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDataKereta";
            this.Text = "FormDataKereta";
            this.Load += new System.EventHandler(this.FormDataKereta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalPABDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keretaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbxIDKereta;
        private System.Windows.Forms.ComboBox cbxJenisKereta;
        private System.Windows.Forms.TextBox tbxNamaKereta;
        private FinalPABDDataSet finalPABDDataSet;
        private System.Windows.Forms.BindingSource keretaBindingSource;
        private FinalPABDDataSetTableAdapters.KeretaTableAdapter keretaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmkeretaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idkeretaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jnskeretaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idstasiunDataGridViewTextBoxColumn;
    }
}