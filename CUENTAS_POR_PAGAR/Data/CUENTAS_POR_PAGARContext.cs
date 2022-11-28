using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CUENTAS_POR_PAGAR.Models;

namespace CUENTAS_POR_PAGAR.Data
{
    public class CUENTAS_POR_PAGARContext : DbContext
    {
        public CUENTAS_POR_PAGARContext (DbContextOptions<CUENTAS_POR_PAGARContext> options)
            : base(options)
        {
        }

        public DbSet<CUENTAS_POR_PAGAR.Models.PROVEEDORES> PROVEEDORES { get; set; }

        public DbSet<CUENTAS_POR_PAGAR.Models.FACTURAS> FACTURAS { get; set; }

        public DbSet<CUENTAS_POR_PAGAR.Models.CHEQUES> CHEQUES { get; set; }

        public DbSet<CUENTAS_POR_PAGAR.Models.USUARIOS> USUARIOS { get; set; }

        public DbSet<CUENTAS_POR_PAGAR.Models.NOTACREDITO> NOTACREDITO { get; set; }

        public DbSet<CUENTAS_POR_PAGAR.Models.ESTADODECUENTAS> ESTADODECUENTAS { get; set; }

    }
}
