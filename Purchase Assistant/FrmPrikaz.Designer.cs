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
            this.btnUnos = new System.Windows.Forms.Button();
            this.dgvPrikaz = new System.Windows.Forms.DataGridView();
            this.btnAzuriranje = new System.Windows.Forms.Button();
            this.btnBrisanje = new System.Windows.Forms.Button();
            this.cboPretrazivanje = new System.Windows.Forms.ComboBox();
            this.lblImePrezimeZaposlenika = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(386, 405);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(113, 23);
            this.btnUnos.TabIndex = 0;
            this.btnUnos.Text = "Nova narudžbenica";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // dgvPrikaz
            // 
            this.dgvPrikaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrikaz.Location = new System.Drawing.Point(12, 53);
            this.dgvPrikaz.Name = "dgvPrikaz";
            this.dgvPrikaz.Size = new System.Drawing.Size(776, 323);
            this.dgvPrikaz.TabIndex = 1;
            // 
            // btnAzuriranje
            // 
            this.btnAzuriranje.Location = new System.Drawing.Point(505, 405);
            this.btnAzuriranje.Name = "btnAzuriranje";
            this.btnAzuriranje.Size = new System.Drawing.Size(135, 23);
            this.btnAzuriranje.TabIndex = 2;
            this.btnAzuriranje.Text = "Ažuriranje narudžbenice";
            this.btnAzuriranje.UseVisualStyleBackColor = true;
            // 
            // btnBrisanje
            // 
            this.btnBrisanje.Location = new System.Drawing.Point(646, 405);
            this.btnBrisanje.Name = "btnBrisanje";
            this.btnBrisanje.Size = new System.Drawing.Size(120, 23);
            this.btnBrisanje.TabIndex = 3;
            this.btnBrisanje.Text = "Brisanje narudžbenice";
            this.btnBrisanje.UseVisualStyleBackColor = true;
            // 
            // cboPretrazivanje
            // 
            this.cboPretrazivanje.FormattingEnabled = true;
            this.cboPretrazivanje.Location = new System.Drawing.Point(12, 26);
            this.cboPretrazivanje.Name = "cboPretrazivanje";
            this.cboPretrazivanje.Size = new System.Drawing.Size(179, 21);
            this.cboPretrazivanje.TabIndex = 4;
            // 
            // lblImePrezimeZaposlenika
            // 
            this.lblImePrezimeZaposlenika.AutoSize = true;
            this.lblImePrezimeZaposlenika.Location = new System.Drawing.Point(12, 10);
            this.lblImePrezimeZaposlenika.Name = "lblImePrezimeZaposlenika";
            this.lblImePrezimeZaposlenika.Size = new System.Drawing.Size(127, 13);
            this.lblImePrezimeZaposlenika.TabIndex = 5;
            this.lblImePrezimeZaposlenika.Text = "Ime i prezime zaposlenika";
            // 
            // FrmPrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblImePrezimeZaposlenika);
            this.Controls.Add(this.cboPretrazivanje);
            this.Controls.Add(this.btnBrisanje);
            this.Controls.Add(this.btnAzuriranje);
            this.Controls.Add(this.dgvPrikaz);
            this.Controls.Add(this.btnUnos);
            this.Name = "FrmPrikaz";
            this.Text = "Prikaz narudžbenica";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.DataGridView dgvPrikaz;
        private System.Windows.Forms.Button btnAzuriranje;
        private System.Windows.Forms.Button btnBrisanje;
        private System.Windows.Forms.ComboBox cboPretrazivanje;
        private System.Windows.Forms.Label lblImePrezimeZaposlenika;
    }
}

