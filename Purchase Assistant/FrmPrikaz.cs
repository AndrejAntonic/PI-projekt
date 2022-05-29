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
        int prvoUcitavanje = -2;

        private void btnUnos_Click(object sender, EventArgs e)
        {
            FrmStvaranje frmStvaranje = new FrmStvaranje();
            frmStvaranje.ShowDialog();
            ShowNarudzbenica();
        }

        private void FrmPrikaz_Load(object sender, EventArgs e)
        {
            ShowNarudzbenica();
            ShowCBOPretrazivanje();
        }

        private void ShowCBOPretrazivanje()
        {
            cboPretrazivanje.DataSource = ZaposlenikRepository.GetZaposleniks();
            cboPretrazivanje.DisplayMember = "PunoIme";
            cboPretrazivanje.ValueMember = "Id";
            cboPretrazivanje.ResetText();
        }

        private void ShowNarudzbenica()
        {
            var narudzbenica = NarudzbenicaRepository.GetNarudzbenicas();
            dgvPrikaz.DataSource = narudzbenica;
            dgvPrikaz.CurrentCell = null;

            dgvPrikaz.Columns["Id"].DisplayIndex = 0;
            dgvPrikaz.Columns["Id"].HeaderText = "ID narudžbenice";
            dgvPrikaz.Columns["zaposlenik"].DisplayIndex = 1;
            dgvPrikaz.Columns["zaposlenik"].HeaderText = "Zaposlenik";
            dgvPrikaz.Columns["opis_predmeta_nabave"].DisplayIndex = 2;
            dgvPrikaz.Columns["opis_predmeta_nabave"].HeaderText = "Opis narudžbenice";
            dgvPrikaz.Columns["naziv_projekta"].DisplayIndex = 3;
            dgvPrikaz.Columns["naziv_projekta"].HeaderText = "Naziv projekta";
            dgvPrikaz.Columns["datum"].DisplayIndex = 4;
            dgvPrikaz.Columns["datum"].HeaderText = "Datum stvaranja narudžbenice";
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

        private void PretrazivanjeNarudzbenica(object idOdabranogZaposlenika)
        {
            var pretrazivanjeNarudzbenice = NarudzbenicaRepository.GetNarudzbenicaWithZaposlenik(Convert.ToInt32(idOdabranogZaposlenika));
            dgvPrikaz.DataSource = pretrazivanjeNarudzbenice;
            dgvPrikaz.CurrentCell = null;

            dgvPrikaz.Columns["Id"].DisplayIndex = 0;
            dgvPrikaz.Columns["Id"].HeaderText = "ID narudžbenice";
            dgvPrikaz.Columns["zaposlenik"].DisplayIndex = 1;
            dgvPrikaz.Columns["zaposlenik"].HeaderText = "Zaposlenik";
            dgvPrikaz.Columns["opis_predmeta_nabave"].DisplayIndex = 2;
            dgvPrikaz.Columns["opis_predmeta_nabave"].HeaderText = "Opis narudžbenice";
            dgvPrikaz.Columns["naziv_projekta"].DisplayIndex = 3;
            dgvPrikaz.Columns["naziv_projekta"].HeaderText = "Naziv projekta";
            dgvPrikaz.Columns["datum"].DisplayIndex = 4;
            dgvPrikaz.Columns["datum"].HeaderText = "Datum stvaranja narudžbenice";
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
            else if(dgvPrikaz.SelectedCells.Count > 1)
            {
                MessageBox.Show("Odabrali ste više od jedne narudžbenice!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idOdabrane = Convert.ToInt32(dgvPrikaz.Rows[dgvPrikaz.CurrentRow.Index].Cells[0].Value);
                FrmStvaranje frmStvaranje = new FrmStvaranje();
                frmStvaranje.ProvjeraZaPrikaz(idOdabrane);
                frmStvaranje.ShowDialog();
                ShowNarudzbenica();
            }
        }

        private void btnPregled_Click(object sender, EventArgs e)
        {
            if(dgvPrikaz.SelectedCells.Count == 0)
            {
                MessageBox.Show("Niste odabrali narudžbenicu koju želite pregledati!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(dgvPrikaz.SelectedCells.Count > 1)
            {
                MessageBox.Show("Odabrali ste više od jedne narudžbenice!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idOdabrane = Convert.ToInt32(dgvPrikaz.Rows[dgvPrikaz.CurrentRow.Index].Cells[0].Value);
                FrmStvaranje frmStvaranje = new FrmStvaranje();
                frmStvaranje.ProvjeraZaPrikaz(idOdabrane);
                frmStvaranje.ProvjeraZaPregled();
                frmStvaranje.ShowDialog();
                ShowNarudzbenica();
            }
        }

        private void cboPretrazivanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(prvoUcitavanje < 0)
            {
                prvoUcitavanje++;
            }
            else
            {
                PretrazivanjeNarudzbenica(cboPretrazivanje.SelectedValue);
            }
        }

        private void btnCiscenje_Click(object sender, EventArgs e)
        {
            cboPretrazivanje.ResetText();
            ShowNarudzbenica();
        }
    }
}
