namespace BusSeatsReservation.Commands.Loggers
{
    using System;

    using Contracts;
    
    internal class ConsoleWriter :IWriter
    {
        public void Write(string args)
        {
            Console.WriteLine(args);
        }
    }
}
