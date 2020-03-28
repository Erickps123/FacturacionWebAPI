using FacturacionWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Data
{
    public class APIContext: DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
        public DbSet<usuarios> Usuarios { get; set; }
        public DbSet<almacenes> Almacenes { get; set; }
        public DbSet<sucursales> Sucursales { get; set; }
        public DbSet<empleados> Empleados { get; set; }
        public DbSet<productos> Productos { get; set; }

    }
}
