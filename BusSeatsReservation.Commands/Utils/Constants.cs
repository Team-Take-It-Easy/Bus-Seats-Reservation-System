using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.Utils
{
    internal static class Constants
    {
        // Constant arrays
        internal static readonly string[] CommandsList = { "Create", "Edit", "Delete", "Get all" };
        internal static readonly string[] ModelsList = { "User", "Reservation", "Route", "Bus" };

        // UI strings
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

        // User validations
        internal const string SuccessfullyCreatedUser = " successfully created!";
        internal const string SuccessfullyCreateReservation = "Reservation successfully created";

        // Reservation validations
        internal const string ErrorCreatingReservationWithNullTrip = "Error! Please enter trip for this reservation!";

        // Bus validations
        internal const int MinBusSeatsCount = 10;
        internal const int MaxBusSeatsCount = 99;
        internal const string ErrorBusTypeIsNotValid = "Error! Invalid bus type!";
        internal const string ErrorInvalidNumberOfSeats = "Error! The number of seats must be between 10 and 99!";

        // Destination validation
        internal const string ErrorDestinationNameMustBeUnique = "Error! This destination already exists!";

        // Route validation
        internal const string ErrorEmptyFromDestination = "Error! Please enter route starting position!";
        internal const string ErrorEmptyToDestination = "Error! Please enter route destination!";

        // Seat validation
        internal const string ErrorNoSeatLabel = "Error! Please enter seat label!";
        internal const string ErrorNoSeatBus = "Error! This seat must be on a bus!";

        // Trip validation
        internal const string ErrorNoTripBus = "Error! The trip must have a bus!";
        internal const string ErrorNoTripRoute = "Error! The trip must have a route!";
        internal const string ErrorNoTripDate = "Error! THe trip must have a date!";

        // User validation
        internal const int MinUserNameLength = 5;
        internal const int MaxUserNameLength = 30;

        internal const int MinLastNameLength = 2;
        internal const int MaxLastNameLength = 30;

        internal const string ErrorUserAlreadyExists = "Error! User with this username already exists! Please choose another username!";
        internal const string ErrorNoUsername = "Error! The user must have a username!";
        internal const string ErrorUsernameWithInvalidLength = "Error! The username length must be between 5 and 30 symbols long!";
        internal const string ErrorNoLastName = "Error! The user must have a last name!";
        internal const string ErrorLastNameWIthInvalidLength = "Error! THe user's last name must be between 2 and 30 symbols long!";
    }
}
