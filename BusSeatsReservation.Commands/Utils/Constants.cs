using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.Utils
{
    internal static class Constants
    {
        internal const string AskForCommand = @"Please, enter command from the following:
Create user (creates new user);
Edit user (edits given user);
Delete user (deletes given user);
Get all users (returns a list of all the registered users);

Create Reservation (creates new reservation);
Edit reservation (edits given reservation);
Delete reservation (deletes given reservation);
Get all reservation (returns a list of all the existing reservations of a given user);

Create route (creates new route);
Edit route (edits given route);
Delete route (deletes given route);
Get all routes (returns a list of all the routes);";

        internal const string AskForUserName = "Please, enter username:";
        internal const string SuccessfullyCreatedUser = " successfully created!";

        internal static readonly string[] CommandsList = { "Create", "Edit", "Delete", "Get all" };
        internal static readonly string[] ModelsList = { "User", "Reservation", "Route", "Bus" };
    }
}
