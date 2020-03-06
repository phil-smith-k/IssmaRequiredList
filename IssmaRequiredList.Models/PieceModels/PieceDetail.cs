using IssmaRequiredList.Data;
using IssmaRequiredList.Models.MovementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Models.PieceModels
{
    public class PieceDetail
    {
        public int PieceId { get; set; }
        public string Title { get; set; }

        public int ComposerId { get; set; }
        public string ComposerName { get; set; }

        public int ArrangerId { get; set; }
        public string ArrangerName { get; set; }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public string Requirement { get; set; }
        public TimeSpan Duration { get; set; }
        public int YearPublished { get; set; }
        public bool IsOutOfPrint { get; set; }
        public List<MovementConcise> ListOfMovements {get; set;}
    }
}
