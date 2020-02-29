using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Data
{
    public enum Gender { Agender, CisFemale, CisMale, Trans, NonBinary, TransMan, TransWoman }

    public class ComposerEntity
    {
        private DateTime _dateOfDeath;
        
        [Key]
        public int ComposerId { get; set; }

        public virtual ICollection<PieceEntity> PieceCatalog { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath
        {
            set
            {
                if (!this.IsAlive)
                    _dateOfDeath = value;
            }
        }

        public bool IsAlive { get; set; } = true;

        public Gender? Gender { get; set; }

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

        public string FullName => $"{this.FirstName} {this.LastName}";

        public DateTime GetDateOfDeath()
        {
            if (this.IsAlive)
                return _dateOfDeath;
            else
                throw new InvalidOperationException("The composer is still alive.");
        }
    }
}
