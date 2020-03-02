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
        private DateTime _dateOfDeath;
        
        public int ComposerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath
        {
            get => _dateOfDeath;
            set
            {
                if (!this.IsAlive)
                    _dateOfDeath = value;
            }
        }
        public int Age
        {
            get
            {
                if (this.IsAlive)
                {
                    TimeSpan span = DateTime.Now - this.DateOfBirth;
                    double age = Math.Floor(span.TotalDays / 365.25);
                    return Convert.ToInt32(age);
                }
                else
                {
                    TimeSpan span = this.GetDateOfDeath() - this.DateOfBirth;
                    double age = Math.Floor(span.TotalDays / 365.25);
                    return Convert.ToInt32(age);
                }
            }
        }
        public bool IsAlive { get; set; } = true;

        public virtual ICollection<Piece> ArrangerPieces { get; set; }
        public virtual ICollection<Piece> ComposerPieces { get; set; }

        public DateTime GetDateOfDeath()
        {
            if (this.IsAlive)
                return _dateOfDeath;
            else
                throw new InvalidOperationException("The composer is still alive.");
        }
    }
}
