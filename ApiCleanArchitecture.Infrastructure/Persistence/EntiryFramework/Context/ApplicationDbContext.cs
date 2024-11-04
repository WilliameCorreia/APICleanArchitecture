using ApiCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<CirculacaoInterna> CirculacaoInterna { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
    }
}
