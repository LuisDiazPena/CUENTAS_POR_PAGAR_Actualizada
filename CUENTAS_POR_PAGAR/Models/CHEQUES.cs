using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CUENTAS_POR_PAGAR.Models
{
    public class CHEQUES
    {
        public int CHEQUESID { get; set; }

        [ForeignKey("CODFACTURA")]
        public int CODFACTURA { get; set; }

        public string VALORCHEQUE { get; set; }
        public string FECHACHEQUE { get; set; }
        public string BANCO { get; set; }
    }
}
