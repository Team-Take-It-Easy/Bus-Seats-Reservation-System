using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserDestination
    {
        public CurrentUserDestination()
        {

        }

        public CurrentUserDestination(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(5)]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
