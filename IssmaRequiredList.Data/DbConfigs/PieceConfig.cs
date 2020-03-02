using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data.EntityConfigurations
{
    public class PieceConfig : EntityTypeConfiguration<Piece>
    {
        public PieceConfig()
        {
            // Primary Key Config
            this.HasKey(p => p.PieceId);

            // Property Config
            this.Property(p => p.Title).IsRequired().HasMaxLength(500);
            this.Property(p => p.Requirement).IsOptional();
            this.Property(p => p.Duration).IsOptional();
            this.Property(p => p.ArrangerId).IsOptional();

            // Relationship Config
            this.HasMany(p => p.Movements)
                .WithRequired(m => m.Piece)
                .HasForeignKey(m => m.PieceId);

            this.HasRequired(p => p.Composer)
                .WithMany(c => c.ComposerPieces)
                .HasForeignKey(p => p.ComposerId);

            this.HasOptional(p => p.Arranger)
                .WithMany(c => c.ArrangerPieces)
                .HasForeignKey(p => p.ArrangerId);

            this.HasRequired(p => p.Publisher)
                .WithMany(pub => pub.PieceCatalog)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
