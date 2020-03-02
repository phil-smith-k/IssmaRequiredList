using IssmaRequiredList.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuild)
        {
            modelBuild.Configurations.Add(new PieceConfig());
            modelBuild.Configurations.Add(new ComposerConfig());
            modelBuild.Configurations.Add(new MovementConfig());
            modelBuild.Configurations.Add(new PublisherConfig());

            base.OnModelCreating(modelBuild);
        }
    }
}
