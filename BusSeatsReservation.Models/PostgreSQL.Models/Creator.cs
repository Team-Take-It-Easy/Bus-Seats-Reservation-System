using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class Creator
    {
        private ICollection<Report> reports;

        public Creator()
        {
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
