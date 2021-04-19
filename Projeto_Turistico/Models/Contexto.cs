using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Turistico.Models
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pontos_Turisticos> Pontos_Turisticos { get; set; }
    }
}
