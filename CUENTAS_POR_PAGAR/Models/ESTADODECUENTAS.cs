using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUENTAS_POR_PAGAR.Models
{
    public class ESTADODECUENTAS
    {
        public int ID { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string FECHA { get; set; }
        public int DEBITO { get; set; }
        public int CREDITO { get; set; }
        public string ESTADO { get; set; }
    }
}
