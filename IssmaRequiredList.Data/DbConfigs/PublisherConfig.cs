using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data.EntityConfigurations
{
    public class PublisherConfig : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfig()
        {
            // Primary Key Config
            this.HasKey(pub => pub.PublisherId);

            // Property Config
            this.Property(pub => pub.Name).IsRequired().HasMaxLength(300);
            this.Property(pub => pub.Name).IsRequired().HasMaxLength(1000);

            // Relationship Config
            this.HasMany(pub => pub.PieceCatalog)
                .WithRequired(p => p.Publisher)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
