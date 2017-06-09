using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Destination
    {
        public Destination()
        {

        }

        public Destination(string name)
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
