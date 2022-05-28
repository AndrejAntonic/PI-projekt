using DBLayer;
using Purchase_Assistant.Models;
using Purchase_Assistant.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Assistant
{
    public partial class FrmPrikaz : Form
    {
        public FrmPrikaz()
        {
            InitializeComponent();
        }

        int idOdabrane;

        private void btnUnos_Click(object sender, EventArgs e)
        {
            FrmStvaranje frmStvaranje = new FrmStvaranje();
            frmStvaranje.ShowDialog();
            ShowNarudzbenica();
        }

        private void FrmPrikaz_Load(object sender, EventArgs e)
        {
            ShowNarudzbenica();
        }

        private void ShowZaposlenik()
        {
            var zaposlenik = ZaposlenikRepository.GetZaposleniks();
            dgvPrikaz.DataSource = zaposlenik;

            dgvPrikaz.Columns["Id"].DisplayIndex = 0;
            dgvPrikaz.Columns["Ime"].DisplayIndex = 1;
            dgvPrikaz.Columns["Prezime"].DisplayIndex = 2;
            dgvPrikaz.Columns["Mail"].DisplayIndex = 3;
        }

        private void ShowFinanciranja()
        {
            var financiranja = FinanciranjaRepository.GetFinanciranjas();
            dgvPrikaz.DataSource = financiranja;

            dgvPrikaz.Columns["Id"].DisplayIndex = 0;
            dgvPrikaz.Columns["naziv"].DisplayIndex = 1;
        }

        private void ShowNarudzbenica()
        {
            var narudzbenica = NarudzbenicaRepository.GetNarudzbenicas();
            dgvPrikaz.DataSource = narudzbenica;
            dgvPrikaz.CurrentCell = null;

            dgvPrikaz.Columns["Id"].DisplayIndex = 0;
            dgvPrikaz.Columns[0].HeaderText = "ID narudžbenice";
            dgvPrikaz.Columns["zaposlenik"].DisplayIndex = 1;
            dgvPrikaz.Columns[1].HeaderText = "Zaposlenik";
            dgvPrikaz.Columns["opis_predmeta_nabave"].DisplayIndex = 2;
            dgvPrikaz.Columns[2].HeaderText = "Opis narudžbenice";
            dgvPrikaz.Columns["naziv_projekta"].DisplayIndex = 3;
            dgvPrikaz.Columns[3].HeaderText = "Naziv projekta";
            dgvPrikaz.Columns["datum"].DisplayIndex = 4;
            dgvPrikaz.Columns[4].HeaderText = "Datum otvaranja narudžbenice";
            dgvPrikaz.Columns["ponuditelj_1"].Visible = false;
            dgvPrikaz.Columns["cijena_bez_pdv_1"].Visible = false;
            dgvPrikaz.Columns["cijena_sa_pdv_1"].Visible = false;
            dgvPrikaz.Columns["odabrana_1"].Visible = false;
            dgvPrikaz.Columns["ponuditelj_2"].Visible = false;
            dgvPrikaz.Columns["cijena_bez_pdv_2"].Visible = false;
            dgvPrikaz.Columns["cijena_sa_pdv_2"].Visible = false;
            dgvPrikaz.Columns["odabrana_2"].Visible = false;
            dgvPrikaz.Columns["financiranje"].Visible = false;
            dgvPrikaz.Columns["broj_projekta"].Visible = false;
            dgvPrikaz.Columns["voditelj_projekta"].Visible = false;
            dgvPrikaz.Columns["dodatno"].Visible = false;

        }

        private void btnBrisanje_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPrikaz.Rows[dgvPrikaz.CurrentRow.Index].Cells[0].Value);
            var rezultat = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu narudžbenicu?", "Brisanje", MessageBoxButtons.YesNo);
            if(rezultat == DialogResult.Yes)
            {
                NarudzbenicaRepository.DeleteNarudzbenica(id);
                ShowNarudzbenica();
            }
        }

        private void btnAzuriranje_Click(object sender, EventArgs e)
        {
            if (dgvPrikaz.SelectedCells.Count == 0)
            {
                MessageBox.Show("Niste odabrali narudžbenicu koju želite ažurirati!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idOdabrane = Convert.ToInt32(dgvPrikaz.Rows[dgvPrikaz.CurrentRow.Index].Cells[0].Value);
                FrmStvaranje frmStvaranje = new FrmStvaranje();
                frmStvaranje.ProvjeraZaPrikaz(idOdabrane);
                frmStvaranje.ShowDialog();
                /*
                Narudzbenica selectedNarudzbenica = dgvPrikaz.CurrentRow.DataBoundItem as Narudzbenica;
                int nez = 1;
                if (selectedNarudzbenica != null)
                {
                    FrmStvaranje frmStvaranje = new FrmStvaranje(selectedNarudzbenica);
                    frmStvaranje.ShowDialog();
                }
                */
            }
        }
    }
}
