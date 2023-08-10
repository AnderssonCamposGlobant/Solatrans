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
        public DbSet<estado_averia>? estado_averia { get; set; }

        public DbSet<averias>? averias { get; set; }

        public DbSet<tipo_averia>? tipo_averia { get; set; }

        public DbSet<tipo_servicio>? tipo_servicio { get; set; }

        public DbSet<usuarios>? usuarios { get; set; }

    }
}
