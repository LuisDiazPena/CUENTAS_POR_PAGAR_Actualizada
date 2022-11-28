using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CUENTAS_POR_PAGAR.Models
{
    public class NOTACREDITO
    {
        public int NOTACREDITOID { get; set; }

        [ForeignKey("CODPROVEDOR")]
        public int CODPROVEEDOR { get; set; }

        public int CANTIDAD { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
