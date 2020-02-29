using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public class MovementEntity
    {
        [Key]
        public int MovementId { get; set; }

        [Required]
        public int MovementNumber { get; set; }

        public virtual PieceEntity Piece { get; set; }
    }
}
