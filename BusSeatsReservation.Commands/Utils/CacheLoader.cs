using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Data.Common.UnitsOfWork;
using BusSeatsReservation.Models.SQLite.Models;
using BusSeatsReservation.Data;

namespace BusSeatsReservation.Commands.Utils
{
    public class CacheLoader : ICacheLoader
    {

        public void LoadData(int userId, EfUnitOfWork sqlUnitOfWork, SQLiteUnitOfWork sqliteUnitOfWork)
        {
            //get user reservations

            var currentUserReservations = sqlUnitOfWork.ReservationRepository.Search(r => r.User.Id == userId).ToArray();

            // get reservations 
            
            foreach (var r in currentUserReservations)
            {
                // currentUserBus
                var bus = new CurrentUserBus()
                {
                    Type = r.Trip.Bus.Type,
                    RegNumber = r.Trip.Bus.RegNumber
                };
                // currentUserSeat 
                var seat = new CurrentUserSeat()
                {
                    Label = r.Seat.Label,
                    Bus = bus
                };

                // from currentUserDestination

                var fromDestination = new CurrentUserDestination()
                {
                    Name = r.Trip.Route.FromDestination.Name
                };

                // to currentUserDestination

                var toDestination = new CurrentUserDestination()
                {
                    Name = r.Trip.Route.ToDestination.Name
                };

                //route 
                var route = new CurrentUserRoute()
                {
                    FromDestination = fromDestination,
                    ToDestination = toDestination,
                    DayOfWeek = r.Trip.Route.DayOfWeek,
                    DepatureHour = r.Trip.Route.DepatureHour,
                    Price = r.Trip.Route.Price,
                    Bus = bus
                };

                //trip

                var trip = new CurrentUserTrip()
                {
                    Route = route,
                    Bus = bus,
                    Date = r.Trip.Date
                };

                var reservation = new CurrentUserReservation()
                {
                    Trip = trip,
                    Seat = seat
                };

                sqliteUnitOfWork.ReservationRepository.Add(reservation);

            }

            sqliteUnitOfWork.Commit();
        }
    }
}
