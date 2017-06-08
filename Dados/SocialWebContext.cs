using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dados
{
    public class SocialWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SocialWebContext() : base("name=SocialWebContext")
        {
        }

        public System.Data.Entity.DbSet<Negocio.Dominio.Horta> Hortas { get; set; }

        public System.Data.Entity.DbSet<Negocio.Dominio.Planta> Plantas { get; set; }

        public System.Data.Entity.DbSet<Negocio.Dominio.Perfil> Perfils { get; set; }

        public System.Data.Entity.DbSet<Negocio.Dominio.Seguir> Seguirs { get; set; }
    }
}
