using DBLayer;
using Purchase_Assistant.Models;
using Purchase_Assistant.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Assistant
{
    public partial class FrmStvaranje : Form
    {
        private Narudzbenica narudzbenica;

        public Narudzbenica SelectedNarudzbenica { get => narudzbenica; set => narudzbenica = value;}

        int idOdabrane;
        bool azuriranjeProvjera = false;
        bool pregled = false;

        public FrmStvaranje(Narudzbenica selectedNarudzbenica)
        {
            InitializeComponent();
            SelectedNarudzbenica = selectedNarudzbenica;
        }

        public FrmStvaranje()
        {
            InitializeComponent();
        }

        private void btnGotovo_Click(object sender, EventArgs e)
        {
            bool provjera = ProvjeraUnosa();
            if(provjera)
            {
                object idZaposlenika = cboZaposlenik.SelectedValue;
                int IdZaposlenika = (int) idZaposlenika;
                string opis = txtOpis.Text;
                string ponuditelj_1 = txtPonuditelj1.Text;
                float cijena_bez_pdv_1 = float.Parse(txtCijenaBezPDV1.Text, new CultureInfo("en-US"));
                float cijena_sa_pdv_1 = float.Parse(txtCijenaSaPDV1.Text, new CultureInfo("en-US"));
                string odabrano_1 = txtOdabrano1.Text;
                string ponuditelj_2 = txtPonuditelj2.Text;
                float cijena_bez_pdv_2 = float.Parse(txtCijenaBezPDV2.Text, new CultureInfo("en-US"));
                float cijena_sa_pdv_2 = float.Parse(txtCijenaSaPDV2.Text, new CultureInfo("en-US"));
                string odabrano_2 = txtOdabrano2.Text;
                object idFinanciranja = cboFinanciranje.SelectedValue;
                int IdFinanciranja = (int)idFinanciranja;
                int broj_projekta = int.Parse(txtBrojProjekta.Text);
                string naziv_projekta = txtNazivProjekta.Text;
                string voditelj_projekta = txtVoditeljProjekta.Text;
                string dodatno = txtDodatno.Text;
                //DateTime datum = DateTime.Now;
                if (azuriranjeProvjera == false)
                {
                    NarudzbenicaRepository.InsertNarudzbenica(IdZaposlenika, opis, ponuditelj_1, cijena_bez_pdv_1, cijena_sa_pdv_1, odabrano_1, ponuditelj_2, cijena_bez_pdv_2, cijena_sa_pdv_2, odabrano_2, IdFinanciranja, broj_projekta, naziv_projekta, voditelj_projekta, dodatno);
                    Close();
                }
                else
                {
                    NarudzbenicaRepository.UpdateNarudzbenica(idOdabrane, IdZaposlenika, opis, ponuditelj_1, cijena_bez_pdv_1, cijena_sa_pdv_1, odabrano_1, ponuditelj_2, cijena_bez_pdv_2, cijena_sa_pdv_2, odabrano_2, IdFinanciranja, broj_projekta, naziv_projekta, voditelj_projekta, dodatno);
                    azuriranjeProvjera = false;
                    Close();
                }
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmStvaranje_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'imeIPrezime.Financiranja' table. You can move, or remove it, as needed.
            //this.financiranjaTableAdapter.Fill(this.imeIPrezime.Financiranja);
            Zaposlenik imePrezime = new Zaposlenik();
            cboZaposlenik.DataSource = ZaposlenikRepository.GetZaposleniks();
            cboZaposlenik.DisplayMember = "PunoIme";
            cboZaposlenik.ValueMember = "Id";
            cboZaposlenik.SelectedIndex = -1;

            cboFinanciranje.DataSource = FinanciranjaRepository.GetFinanciranjas();
            cboFinanciranje.DisplayMember = "naziv";
            cboFinanciranje.ValueMember = "Id";
            cboFinanciranje.SelectedIndex = -1;
            if(idOdabrane != 0 && pregled == false)
            {
                this.Text = "Ažuriranje narudžbenice";
                Narudzbenica azuriranje = NarudzbenicaRepository.GetNarudzbenica(idOdabrane);

                cboZaposlenik.Text = azuriranje.zaposlenik.ToString();
                txtOpis.Text = azuriranje.opis_predmeta_nabave;
                txtPonuditelj1.Text = azuriranje.ponuditelj_1;
                txtCijenaBezPDV1.Text = azuriranje.cijena_bez_pdv_1.ToString();
                txtCijenaSaPDV1.Text = azuriranje.cijena_sa_pdv_1.ToString();
                txtOdabrano1.Text = azuriranje.odabrana_1;
                txtPonuditelj2.Text = azuriranje.ponuditelj_2;
                txtCijenaBezPDV2.Text = azuriranje.cijena_bez_pdv_2.ToString();
                txtCijenaSaPDV2.Text = azuriranje.cijena_sa_pdv_2.ToString();
                txtOdabrano2.Text = azuriranje.odabrana_2;
                cboFinanciranje.Text = azuriranje.financiranje.ToString();
                txtBrojProjekta.Text = azuriranje.broj_projekta.ToString();
                txtNazivProjekta.Text = azuriranje.naziv_projekta;
                txtVoditeljProjekta.Text = azuriranje.voditelj_projekta;
                txtDodatno.Text = azuriranje.dodatno;
                azuriranjeProvjera = true;
            }
            else if(idOdabrane != 0 && pregled == true)
            {
                this.Text = "Pregled narudžbenice";
                Narudzbenica pregledNarudzbenice = NarudzbenicaRepository.GetNarudzbenica(idOdabrane);

                cboZaposlenik.Text = pregledNarudzbenice.zaposlenik.ToString();
                cboZaposlenik.Enabled = false;
                txtOpis.Text = pregledNarudzbenice.opis_predmeta_nabave;
                txtOpis.ReadOnly = true;
                txtPonuditelj1.Text = pregledNarudzbenice.ponuditelj_1;
                txtPonuditelj1.ReadOnly = true;
                txtCijenaBezPDV1.Text = pregledNarudzbenice.cijena_bez_pdv_1.ToString();
                txtCijenaBezPDV1.ReadOnly = true;
                txtCijenaSaPDV1.Text = pregledNarudzbenice.cijena_sa_pdv_1.ToString();
                txtCijenaSaPDV1.ReadOnly = true;
                txtOdabrano1.Text = pregledNarudzbenice.odabrana_1;
                txtOdabrano1.ReadOnly = true;
                txtPonuditelj2.Text = pregledNarudzbenice.ponuditelj_2;
                txtPonuditelj2.ReadOnly = true;
                txtCijenaBezPDV2.Text = pregledNarudzbenice.cijena_bez_pdv_2.ToString();
                txtCijenaBezPDV2.ReadOnly = true;
                txtCijenaSaPDV2.Text = pregledNarudzbenice.cijena_sa_pdv_2.ToString();
                txtCijenaSaPDV2.ReadOnly = true;
                txtOdabrano2.Text = pregledNarudzbenice.odabrana_2;
                txtOdabrano2.ReadOnly = true;
                cboFinanciranje.Text = pregledNarudzbenice.financiranje.ToString();
                cboFinanciranje.Enabled = false;
                txtBrojProjekta.Text = pregledNarudzbenice.broj_projekta.ToString();
                txtBrojProjekta.ReadOnly = true;
                txtNazivProjekta.Text = pregledNarudzbenice.naziv_projekta;
                txtNazivProjekta.ReadOnly = true;
                txtVoditeljProjekta.Text = pregledNarudzbenice.voditelj_projekta;
                txtVoditeljProjekta.ReadOnly = true;
                txtDodatno.Text = pregledNarudzbenice.dodatno;
                txtDodatno.ReadOnly = true;
                pregled = false;
            }
        }

        private void cboZaposlenik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ProvjeraZaPrikaz(int id)
        {
            idOdabrane = id;
        }

        public void ProvjeraZaPregled()
        {
            pregled = true;
        }

        private bool ProvjeraUnosa()
        {
            if(cboZaposlenik.SelectedValue == null)
            {
                MessageBox.Show("Zaposlenik koji pravi narudžbenicu nije odabran!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOpis.Text == "")
            {
                MessageBox.Show("Opis predmeta nabave nije unesen!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtPonuditelj1.Text == "")
            {
                MessageBox.Show("Ime prvog ponuditelja nije uneseno!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtCijenaBezPDV1.Text == "")
            {
                MessageBox.Show("Cijena bez PDV-a za prvu ponudu nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtCijenaSaPDV1.Text == "")
            {
                MessageBox.Show("Cijena sa PDV-om za prvu ponudu nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOdabrano1.Text == "")
            {
                MessageBox.Show("Niste naveli da li je prva ponuda odabrana!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtPonuditelj2.Text == "")
            {
                MessageBox.Show("Ime drugog ponuditelja nije uneseno!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtCijenaBezPDV2.Text == "")
            {
                MessageBox.Show("Cijena bez PDV-a za drugu ponudu nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtCijenaSaPDV2.Text == "")
            {
                MessageBox.Show("Cijena sa PDV-om za drugu ponudu nije unesena!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOdabrano2.Text == "")
            {
                MessageBox.Show("Niste naveli da li je druga ponuda odabrana!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(cboFinanciranje.SelectedValue == null)
            {
                MessageBox.Show("Niste odabrali izvor financiranja!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtBrojProjekta.Text == "")
            {
                MessageBox.Show("Niste naveli broj projekta!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtNazivProjekta.Text == "")
            {
                MessageBox.Show("Niste naveli naziv projekta!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtVoditeljProjekta.Text == "")
            {
                MessageBox.Show("Niste naveli voditelja projekta!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtDodatno.Text == "")
            {
                MessageBox.Show("Niste naveli dodatna pojašnjenja projekta!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOpis.TextLength > 255)
            {
                MessageBox.Show("Opis je veći od 255 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtPonuditelj1.TextLength > 20)
            {
                MessageBox.Show("Naziv prvog ponuditelja je veći od 20 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(System.Text.RegularExpressions.Regex.IsMatch(txtCijenaBezPDV1.Text, "^[-+]?[0-9]*\\.?[0-9]+$")))
            {
                MessageBox.Show("Niste unijeli decimalni broj sa točkom u polje cijena bez PDV-a za prvu ponudu!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(System.Text.RegularExpressions.Regex.IsMatch(txtCijenaSaPDV1.Text, "^[-+]?[0-9]*\\.?[0-9]+$")))
            {
                MessageBox.Show("Niste unijeli decimalni broj sa točkom u polje cijena sa PDV-om za prvu ponudu!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOdabrano1.TextLength > 255)
            {
                MessageBox.Show("Polje 'Navedite da li je ponuda odabrana' za prvu ponudu sadrži više od 255 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtPonuditelj2.TextLength > 20)
            {
                MessageBox.Show("Naziv drugog ponuditelja je veći od 20 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(System.Text.RegularExpressions.Regex.IsMatch(txtCijenaBezPDV2.Text, "^[-+]?[0-9]*\\.?[0-9]+$")))
            {
                MessageBox.Show("Niste unijeli decimalni broj sa točkom u polje cijena bez PDV-a za drugu ponudu!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(System.Text.RegularExpressions.Regex.IsMatch(txtCijenaSaPDV2.Text, "^[-+]?[0-9]*\\.?[0-9]+$")))
            {
                MessageBox.Show("Niste unijeli decimalni broj sa točkom u polje cijena sa PDV-om za drugu ponudu!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtOdabrano2.TextLength > 255)
            {
                MessageBox.Show("Polje 'Navedite da li je ponuda odabrana' za drugu ponudu sadrži više od 255 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(System.Text.RegularExpressions.Regex.IsMatch(txtBrojProjekta.Text, "^[0-9]*$")))
            {
                MessageBox.Show("Niste unijeli prirodni broj u polje broj projekta!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtNazivProjekta.TextLength > 20)
            {
                MessageBox.Show("Naziv projekta je veći od 20 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtVoditeljProjekta.TextLength > 50)
            {
                MessageBox.Show("Ime voditelja/voditeljice projekta je veće od 50 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtDodatno.TextLength > 255)
            {
                MessageBox.Show("Polje 'Dodatna pojašnjenja' sadrži više od 255 znakova!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
