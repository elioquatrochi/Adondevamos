using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Adondevamos.Models;

namespace Adondevamos
{
    public class Micontext: DbContext
    {


    
        public DbSet<Perfil> Usuarios { get; set; }
        // Agrega más DbSet para tus entidades

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Elio;Initial Catalog=Login;Integrated Security=True"); // Reemplaza con tu cadena de conexión
        }
    



}
}