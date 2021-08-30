using AbastecaDAL.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.EFC
{
    public class AbastecaContext:DbContext
    {
        public AbastecaContext(DbContextOptions<AbastecaContext> options):base(options)
        {

        }
        public DbSet<Bomba> Bombas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Condutor> Condutors { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<Pessoa>().ToTable("Pessoa");
            //mb.Entity<Login>().ToTable("Login");
            //mb.Entity<Prestador>().ToTable("Prestador");
            //mb.Entity<ServicoPrestado>().ToTable("ServicoPrestado");


            //mb.Entity<Pessoa>(entity =>
            //{
            //    entity.HasIndex(e => e.Telefone).IsUnique();
            //    entity.HasIndex(e => e.Email).IsUnique();
            //});

        }
    }
}
