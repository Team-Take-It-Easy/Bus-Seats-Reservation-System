using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class User
    {
        private ICollection<Reservation> reservations;

        public User()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public User(string userName, string firstName, string lastName)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [MaxLength(30)]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Reservation> Reservations
        {
            get
            {
                return this.reservations;
            }

            set
            {
                this.reservations = value;
            }
        }
    }
}
