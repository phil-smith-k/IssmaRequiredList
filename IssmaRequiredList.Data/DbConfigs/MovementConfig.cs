using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data.EntityConfigurations
{
    public class MovementConfig : EntityTypeConfiguration<Movement>
    {
        public MovementConfig()
        {
            // Primary Key Config
            this.HasKey(m => m.MovementId);

            // Relationship Config
            this.HasRequired(m => m.Piece)
                .WithMany(p => p.Movements)
                .HasForeignKey(m => m.PieceId);
        }
    }
}
