using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_Assistant.Models
{
    public class Osoba : object
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public string PunoIme => $"{Ime} {Prezime}";

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
