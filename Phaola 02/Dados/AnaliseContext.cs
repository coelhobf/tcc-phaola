using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Phaola_02.Dados
{
    class AnaliseContext : DbContext
    {
        public DbSet<Analise> Analises { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = ConfigurationManager.ConnectionStrings["bdAnalisesCS"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }
    }
}
