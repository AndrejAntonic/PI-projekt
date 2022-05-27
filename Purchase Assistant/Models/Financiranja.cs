using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase_Assistant.Models
{
    public class Financiranja
    {
        public int Id { get; set; }
        public string naziv { get; set; }

        public override string ToString()
        {
            return naziv;
        }
    }
}
