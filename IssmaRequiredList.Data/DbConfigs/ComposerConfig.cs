using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data.EntityConfigurations
{
    public class ComposerConfig : EntityTypeConfiguration<Composer>
    {
        public ComposerConfig()
        {
            // Primary Key Config
            this.HasKey(c => c.ComposerId);

            // Property Config
            this.Property(c => c.FirstName).HasMaxLength(200);
            this.Property(c => c.LastName).HasMaxLength(200);
            this.Property(c => c.Gender).IsOptional();
            this.Property(c => c.DateOfBirth).IsRequired();
            this.Property(c => c.DateOfDeath).IsOptional();

            // Relationship Config
            this.HasMany(c => c.ArrangerPieces)
                .WithOptional(p => p.Arranger)
                .HasForeignKey(p => p.ArrangerId);

            this.HasMany(c => c.ComposerPieces)
                .WithRequired(p => p.Composer)
                .HasForeignKey(p => p.ComposerId);
        }
    }
}
