namespace BusSeatsReservation.Commands.Readers
{
    using System;

    using Contracts;
    using System.Text;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
