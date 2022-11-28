using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUENTAS_POR_PAGAR.Models
{
    public class PROVEEDORES
    {
        public int ID { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION { get; set; }
        public string CIUDAD { get; set; }
        public string TELEFONO { get; set; }
        public string EMPRESA { get; set; }

        //public FACTURAS FACTURAs { get; set; }
        public ICollection<NOTACREDITO> NOTACREDITOs { get; set; }
    }
}
