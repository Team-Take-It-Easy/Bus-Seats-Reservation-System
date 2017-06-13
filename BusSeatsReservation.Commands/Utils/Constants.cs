namespace BusSeatsReservation.Commands.Utils
{
    internal static class Constants
    {
        // Constant arrays
        internal static readonly string[] CommandsList = { "Create", "Update", "Delete", "All", "Exit" };
        internal static readonly string[] ModelsList = { "User", "Reservation", "Route", "Trip", "App", "Report" };

        // UI strings
        internal const string AskForCommandShort = "Please, enter command";
        internal const string AskForCommandLong = @"Please, enter command from the following:
Create user (creates new user);
Update user (edits given user);
Delete user (deletes given user);
All users (returns a list of all the registered users);

Create Reservation (creates new reservation);
Update reservation (edits given reservation);
Delete reservation (deletes given reservation);
All reservations (returns a list of all the existing reservations of a given user);

Create route (creates new route);
Update route (edits given route);
Delete route (deletes given route);
All routes (returns a list of all the routes);

Create trip (creates new trip);
Update trip (edits given trip);
Delete trip (deletes given trip);
All trips (returns a list of all trips);

Exit app (exits the application);";

        internal const string ErrorInvalidCommand = "Wrong command, please choose one of the following:\n";
        internal const string ExitMessage = "Your job here is done!";

        // Create user
        internal const string CreateUser = "Create user:";
        internal const string AskForUserName = "Please, enter username:";
        internal const string AskForFirstName = "Please, enter first name";
        internal const string AskForLastName = "Please, enter last name";
        internal const string UserCreated = "User created successfully!";

        internal const string DeleteUser = "Delete user:";
        internal const string AskForUserByUsername = "Please, enter the username of the user:";
        internal const string SearchedUserDoesNotExist = "There is no user with this username!";
        internal const string EntityDeletedSuccessfully = "deleted successfully";

        internal const string AllUsers = "All users:";

        // Create route

        internal const string CreateRoute = "Create route:";
        internal const string AskForStartPoint = "Please, enter start city:";
        internal const string AskForDestinaion = "Please, enter destination";
        internal const string AskForWeekDay = "Please, enter day of the week with number from 1 to 7";
        internal const string AskForHour = "Please, enter hour in format HH:MM";
        internal const string RouteCreated = "Route created successfully!";

        // Create trip

        internal const string CreateTrip = "Create trip for a route:";

        // Create report
        internal const string CreateReport = "Create report:";
        internal const string AskForReportType = "Please, enter type of report - users or trip";
        internal const string InvalidReportType = "There is no report with this type!";
        internal const string AskForTripId = "Please, enter Trip Id";
        internal const string SearchedTripDoesNotExist = "There is no trip with this id!";
        internal const string ReportCreate = "Report created successfully";


        // User validations
        internal const string SuccessfullyCreatedUser = " successfully created!";
        internal const string SuccessfullyCreateReservation = "Reservation successfully created";
        internal const string SuccessfulSignedIn = "You are now signed in";

        internal const int MinUserNameLength = 5;
        internal const int MaxUserNameLength = 30;

        internal const int MinLastNameLength = 2;
        internal const int MaxLastNameLength = 30;

        internal const string ErrorUserAlreadyExists = "Error! User with this username already exists! Please choose another username!";
        internal const string ErrorNoUsername = "Error! The user must have a username!";
        internal const string ErrorUsernameWithInvalidLength = "Error! The username length must be between 5 and 30 symbols long!";
        internal const string ErrorNoLastName = "Error! The user must have a last name!";
        internal const string ErrorLastNameWIthInvalidLength = "Error! THe user's last name must be between 2 and 30 symbols long!";

        // Create reservation
        internal const string CreateReservation = "Create reservation:";
        internal const string FoundUser = "User found!";

        internal const string AllReservations = "All reservations:";
        //internal const string 

        // Reservation validations
        internal const string ErrorCreatingReservationWithNullTrip = "Error! Please enter trip for this reservation!";

        // Bus validations
        internal const int MinBusSeatsCount = 10;
        internal const int MaxBusSeatsCount = 99;
        internal const string ErrorBusTypeIsNotValid = "Error! Invalid bus type!";
        internal const string ErrorInvalidNumberOfSeats = "Error! The number of seats must be between 10 and 99!";

        // Destination validation
        internal const string ErrorDestinationNameMustBeUnique = "Error! This destination already exists!";
        internal const string ErrorDestinationNameCannotBeNull = "Error! Please enter destination name!";

        // Route validation
        internal const string ErrorEmptyFromDestination = "Error! Please enter route starting position!";
        internal const string ErrorEmptyToDestination = "Error! Please enter route destination!";
        internal const string ErrorNotValidHour = "Error! Please enter valid hour!";

        // Seat validation
        internal const string ErrorNoSeatLabel = "Error! Please enter seat label!";
        internal const string ErrorNoSeatBus = "Error! This seat must be on a bus!";

        // Trip validation
        internal const string ErrorNoTripBus = "Error! The trip must have a bus!";
        internal const string ErrorNoTripRoute = "Error! The trip must have a route!";
        internal const string ErrorNoTripDate = "Error! THe trip must have a date!";

        // Generic messages
        internal const string ErrorStringCannotBeNull = "Error! This value cannot be null!";
        internal const string ErrorStringWithInvalidLength = "Error! This string is with invalid length!";
    }
}
