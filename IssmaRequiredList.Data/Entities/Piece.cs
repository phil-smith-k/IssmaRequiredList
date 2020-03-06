using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public class Piece
    {
        public int PieceId { get; set; }
        public string Title { get; set; }
        public string Requirement { get; set; }
        public TimeSpan Duration { get; set; }
        public int YearPublished { get; set; }
        public bool IsOutOfPrint { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        public int ComposerId { get; set; }
        public virtual Composer Composer { get; set; }

        public int ArrangerId { get; set; }
        public virtual Composer Arranger { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
