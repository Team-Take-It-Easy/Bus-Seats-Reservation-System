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
            StringBuilder sb = new StringBuilder();
            while(!string.IsNullOrEmpty(input))
            {
                sb.Append(input);
                sb.Append("\n");
                input = Console.ReadLine();
            }

            return sb.ToString();
        }
    }
}
