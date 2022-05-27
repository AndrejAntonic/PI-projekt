namespace Purchase_Assistant
{
    partial class FrmPrikaz
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
            this.btnUnos = new System.Windows.Forms.Button();
            this.dgvPrikaz = new System.Windows.Forms.DataGridView();
            this.fKidzaposlenikaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zaposlenikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imeIPrezime = new Purchase_Assistant.DataSets.ImeIPrezime();
            this.btnAzuriranje = new System.Windows.Forms.Button();
            this.btnBrisanje = new System.Windows.Forms.Button();
            this.cboPretrazivanje = new System.Windows.Forms.ComboBox();
            this.lblMailZaposlenika = new System.Windows.Forms.Label();
            this.zaposlenikTableAdapter = new Purchase_Assistant.DataSets.ImeIPrezimeTableAdapters.ZaposlenikTableAdapter();
            this.narudzbenicaTableAdapter = new Purchase_Assistant.DataSets.ImeIPrezimeTableAdapters.NarudzbenicaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKidzaposlenikaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaposlenikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imeIPrezime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(579, 623);
            this.btnUnos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(170, 35);
            this.btnUnos.TabIndex = 0;
            this.btnUnos.Text = "Nova narudžbenica";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // dgvPrikaz
            // 
            this.dgvPrikaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrikaz.Location = new System.Drawing.Point(18, 82);
            this.dgvPrikaz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPrikaz.Name = "dgvPrikaz";
            this.dgvPrikaz.RowHeadersWidth = 62;
            this.dgvPrikaz.Size = new System.Drawing.Size(1164, 497);
            this.dgvPrikaz.TabIndex = 1;
            // 
            // fKidzaposlenikaBindingSource
            // 
            this.fKidzaposlenikaBindingSource.DataMember = "FK_id_zaposlenika";
            this.fKidzaposlenikaBindingSource.DataSource = this.zaposlenikBindingSource;
            // 
            // zaposlenikBindingSource
            // 
            this.zaposlenikBindingSource.DataMember = "Zaposlenik";
            this.zaposlenikBindingSource.DataSource = this.imeIPrezime;
            // 
            // imeIPrezime
            // 
            this.imeIPrezime.DataSetName = "ImeIPrezime";
            this.imeIPrezime.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAzuriranje
            // 
            this.btnAzuriranje.Location = new System.Drawing.Point(758, 623);
            this.btnAzuriranje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAzuriranje.Name = "btnAzuriranje";
            this.btnAzuriranje.Size = new System.Drawing.Size(202, 35);
            this.btnAzuriranje.TabIndex = 2;
            this.btnAzuriranje.Text = "Ažuriranje narudžbenice";
            this.btnAzuriranje.UseVisualStyleBackColor = true;
            // 
            // btnBrisanje
            // 
            this.btnBrisanje.Location = new System.Drawing.Point(969, 623);
            this.btnBrisanje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrisanje.Name = "btnBrisanje";
            this.btnBrisanje.Size = new System.Drawing.Size(180, 35);
            this.btnBrisanje.TabIndex = 3;
            this.btnBrisanje.Text = "Brisanje narudžbenice";
            this.btnBrisanje.UseVisualStyleBackColor = true;
            this.btnBrisanje.Click += new System.EventHandler(this.btnBrisanje_Click);
            // 
            // cboPretrazivanje
            // 
            this.cboPretrazivanje.DataSource = this.zaposlenikBindingSource;
            this.cboPretrazivanje.DisplayMember = "mail";
            this.cboPretrazivanje.FormattingEnabled = true;
            this.cboPretrazivanje.Location = new System.Drawing.Point(18, 40);
            this.cboPretrazivanje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPretrazivanje.Name = "cboPretrazivanje";
            this.cboPretrazivanje.Size = new System.Drawing.Size(266, 28);
            this.cboPretrazivanje.TabIndex = 4;
            this.cboPretrazivanje.ValueMember = "Id";
            // 
            // lblMailZaposlenika
            // 
            this.lblMailZaposlenika.AutoSize = true;
            this.lblMailZaposlenika.Location = new System.Drawing.Point(18, 15);
            this.lblMailZaposlenika.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailZaposlenika.Name = "lblMailZaposlenika";
            this.lblMailZaposlenika.Size = new System.Drawing.Size(129, 20);
            this.lblMailZaposlenika.TabIndex = 5;
            this.lblMailZaposlenika.Text = "Mail zaposlenika:";
            // 
            // zaposlenikTableAdapter
            // 
            this.zaposlenikTableAdapter.ClearBeforeFill = true;
            // 
            // narudzbenicaTableAdapter
            // 
            this.narudzbenicaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblMailZaposlenika);
            this.Controls.Add(this.cboPretrazivanje);
            this.Controls.Add(this.btnBrisanje);
            this.Controls.Add(this.btnAzuriranje);
            this.Controls.Add(this.dgvPrikaz);
            this.Controls.Add(this.btnUnos);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrikaz";
            this.Text = "Prikaz narudžbenica";
            this.Load += new System.EventHandler(this.FrmPrikaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKidzaposlenikaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zaposlenikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imeIPrezime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.DataGridView dgvPrikaz;
        private System.Windows.Forms.Button btnAzuriranje;
        private System.Windows.Forms.Button btnBrisanje;
        private System.Windows.Forms.ComboBox cboPretrazivanje;
        private System.Windows.Forms.Label lblMailZaposlenika;
        private DataSets.ImeIPrezime imeIPrezime;
        private System.Windows.Forms.BindingSource zaposlenikBindingSource;
        private DataSets.ImeIPrezimeTableAdapters.ZaposlenikTableAdapter zaposlenikTableAdapter;
        private System.Windows.Forms.BindingSource fKidzaposlenikaBindingSource;
        private DataSets.ImeIPrezimeTableAdapters.NarudzbenicaTableAdapter narudzbenicaTableAdapter;
    }
}

