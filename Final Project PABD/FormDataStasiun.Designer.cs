namespace Final_Project_PABD
{
    partial class FormDataStasiun
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNm = new System.Windows.Forms.TextBox();
            this.txtIdS = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.tbxTujuan = new System.Windows.Forms.TextBox();
            this.tbxKbr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(678, 152);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(721, 23);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 38);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(354, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 41);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(505, 234);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 39);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(505, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nama Stasiun";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID Stasiun";
            // 
            // txtNm
            // 
            this.txtNm.Location = new System.Drawing.Point(350, 227);
            this.txtNm.Name = "txtNm";
            this.txtNm.Size = new System.Drawing.Size(127, 22);
            this.txtNm.TabIndex = 10;
            this.txtNm.TextChanged += new System.EventHandler(this.txtNm_TextChanged);
            // 
            // txtIdS
            // 
            this.txtIdS.Location = new System.Drawing.Point(350, 261);
            this.txtIdS.Name = "txtIdS";
            this.txtIdS.Size = new System.Drawing.Size(127, 22);
            this.txtIdS.TabIndex = 12;
            this.txtIdS.TextChanged += new System.EventHandler(this.txtIdS_TextChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 404);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 34);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(236, 397);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(79, 41);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // tbxTujuan
            // 
            this.tbxTujuan.Location = new System.Drawing.Point(351, 303);
            this.tbxTujuan.Name = "tbxTujuan";
            this.tbxTujuan.Size = new System.Drawing.Size(127, 22);
            this.tbxTujuan.TabIndex = 18;
            this.tbxTujuan.TextChanged += new System.EventHandler(this.tbxTujuan_TextChanged);
            // 
            // tbxKbr
            // 
            this.tbxKbr.Location = new System.Drawing.Point(351, 343);
            this.tbxKbr.Name = "tbxKbr";
            this.tbxKbr.Size = new System.Drawing.Size(127, 22);
            this.tbxKbr.TabIndex = 19;
            this.tbxKbr.TextChanged += new System.EventHandler(this.tbxKbr_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tujuan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Keberangkatan";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(460, 397);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 41);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(41, 181);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(100, 22);
            this.tbxSearch.TabIndex = 24;
            this.tbxSearch.Text = "Search";
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // FormDataStasiun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxKbr);
            this.Controls.Add(this.tbxTujuan);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtIdS);
            this.Controls.Add(this.txtNm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDataStasiun";
            this.Text = "FormDataStasiun";
            this.Load += new System.EventHandler(this.FormDataStasiun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNm;
        private System.Windows.Forms.TextBox txtIdS;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox tbxTujuan;
        private System.Windows.Forms.TextBox tbxKbr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbxSearch;
    }
}