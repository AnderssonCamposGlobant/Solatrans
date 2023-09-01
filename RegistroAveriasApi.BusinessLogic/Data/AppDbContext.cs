using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegistroAveriasApi.BusinessLogic.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<estado>? estado { get; set; }

        public DbSet<conductor>? conductor { get; set; }

        public DbSet<seguimiento>? seguimiento { get; set; }

        public DbSet<linea>? linea { get; set; }

        public DbSet<sublinea>? sublinea { get; set; }

        public DbSet<fichas>? fichas { get; set; }

        public DbSet<parada>? parada { get; set; }

        public DbSet<criticidad>? criticidad { get; set; }

        public DbSet<empresa>? empresa { get; set; }

        public DbSet<adjuntos>? adjuntos { get; set; }

        public DbSet<averia>? averia { get; set; }

        public DbSet<tipo_averia>? tipo_averia { get; set; }

        public DbSet<tipo_servicio>? tipo_servicio { get; set; }

        public DbSet<usuarios>? usuarios { get; set; }

        public DbSet<roles>? roles { get; set; }

    }
}
