using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_Assistant.Models
{
    public class Narudzbenica
    {
        public int Id { get; set; }
        public Zaposlenik zaposlenik { get; set; }
        public string opis_predmeta_nabave { get; set; }
        public string ponuditelj_1 { get; set; }
        public string cijena_bez_pdv_1 { get; set; }
        public string cijena_sa_pdv_1 { get; set; }
        public string odabrana_1 { get; set; }
        public string ponuditelj_2 { get; set; }
        public string cijena_bez_pdv_2 { get; set; }
        public string cijena_sa_pdv_2 { get; set; }
        public string odabrana_2 { get; set; }
        public Financiranja financiranje { get; set; }
        public int broj_projekta { get; set; }
        public string naziv_projekta { get; set; }
        public string voditelj_projekta { get; set; }
        public string dodatno { get; set; }
        public DateTime datum { get; set; }

    }
}
