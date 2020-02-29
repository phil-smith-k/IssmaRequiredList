using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public class PieceEntity
    {
        [Key]
        public int PieceId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Requirement { get; set; }

        public bool IsMultiMovement { get; set; }

        public virtual ICollection<MovementEntity> Movements { get; set; }

        [Required]
        public virtual ComposerEntity Composer { get; set; }

        public virtual ComposerEntity Arranger { get; set; }

        public virtual PublisherEntity Publisher { get; set; }

        public TimeSpan? Duration { get; set; }
    }
}
