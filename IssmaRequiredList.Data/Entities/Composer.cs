using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public enum Gender { Agender, CisFemale, CisMale, NonBinary, Trans }

    public class Composer
    {
        public int ComposerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int Age
        {
            get
            {
                if (this.DateOfDeath == null)
                {
                    TimeSpan span = DateTime.Now - this.DateOfBirth;
                    double age = Math.Floor(span.TotalDays / 365.25);
                    return Convert.ToInt32(age);
                }
                else
                {
                    DateTime dateOfDeath = (DateTime)this.DateOfDeath;
                    TimeSpan span = dateOfDeath - this.DateOfBirth;
                    double age = Math.Floor(span.TotalDays / 365.25);
                    return Convert.ToInt32(age);
                }
            }
        }
        public virtual ICollection<Piece> ArrangerPieces { get; set; }
        public virtual ICollection<Piece> ComposerPieces { get; set; }
    }
}
