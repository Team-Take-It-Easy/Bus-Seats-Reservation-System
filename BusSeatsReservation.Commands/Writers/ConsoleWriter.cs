namespace BusSeatsReservation.Commands.Writers
{
    using System;

    using Contracts;
    
    public class ConsoleWriter :IWriter
    {
        public void Write(string args)
        {
            Console.WriteLine(args);
        }
    }
}
