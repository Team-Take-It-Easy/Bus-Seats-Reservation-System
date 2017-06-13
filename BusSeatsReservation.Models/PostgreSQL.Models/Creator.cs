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
        private ICollection<Log> logs;

        public Creator()
        {
            this.reports = new HashSet<Report>();
            this.logs = new HashSet<Log>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }

        public virtual ICollection<Log> Logs
        {
            get
            {
                return this.logs;
            }

            set
            {
                this.logs = value;
            }
        }
    }
}
