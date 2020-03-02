using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public class Movement
    {
        public int MovementId { get; set; }
        public int MovementNumber { get; set; }

        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }
    }
}
