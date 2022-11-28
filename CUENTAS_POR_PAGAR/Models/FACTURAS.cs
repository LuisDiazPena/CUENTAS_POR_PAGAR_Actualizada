using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CUENTAS_POR_PAGAR.Models
{
    public class FACTURAS
    {
        public int FACTURASID { get; set; }

        [ForeignKey("CODPROVEDORES")]
        public int CODPROVEDORES { get; set; }

        public string FORMADEPAGO { get; set; }
        public string FECHA { get; set; }
        public string FECHAVENCIMIENTO { get; set; }
        public int DEBITO { get; set; }
        public int CREDITO { get; set; }
        public string RAZONSOCIAL { get; set; }
        public string ESTADO { get; set; }

        public PROVEEDORES PROVEEDORES { get; set; }
        public ICollection<CHEQUES> CHEQUEs { get; set; }

    }
}
