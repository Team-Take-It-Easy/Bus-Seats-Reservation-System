﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserRoute
    {
        public CurrentUserRoute()
        {

        }

        public int Id { get; set; }

        [Required]
        public virtual CurrentUserDestination FromDestination { get; set; }

        [Required]
        public virtual CurrentUserDestination ToDestination { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [DataType(DataType.Time)]
        public DateTime DepatureHour { get; set; }

        public decimal? Price { get; set; }

        public virtual CurrentUserBus Bus { get; set; }
    }
}