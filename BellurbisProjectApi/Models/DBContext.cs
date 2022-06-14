using Microsoft.EntityFrameworkCore;
namespace BellurbisProjectApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<PlayerModel> PlayerTab { get; set; }

        public DbSet<RestaurantModel> RestaurantTab { get; set; }
        public DbSet<RestroPlayerLinkModel> RPLinkTab { get; set; }
        
    }
}
