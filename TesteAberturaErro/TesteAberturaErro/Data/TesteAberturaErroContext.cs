using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteAberturaErro.Models
{
    public class TesteAberturaErroContext : DbContext
    {
        public TesteAberturaErroContext (DbContextOptions<TesteAberturaErroContext> options)
            : base(options)
        {
        }

        public DbSet<TesteAberturaErro.Models.Erros> Erros { get; set; }
    }
}
