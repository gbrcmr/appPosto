using appPosto.Models;
using Microsoft.EntityFrameworkCore;

namespace appPosto.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {
        }

        public DbSet<PostosModel> Postos { get; set; }
    }
}
