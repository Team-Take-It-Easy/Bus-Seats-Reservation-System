namespace BusSeatsReservation.Commands
{
    using Contracts;
    using Utils;

    public class Engine
    {
        internal IWriter Writer { get; set; }

        internal IReader Reader { get; set; }

        public void Start()
        {
            this.Writer.Write(Constants.AskForCommand);
            string input = this.Reader.Read();
            string command;
            string model;
            
            foreach (var c in Constants.CommandsList)
            {
                if(input.ToLower().Contains(c.ToLower()))
                {
                    command = c;
                }
            }

            foreach (var m in Constants.ModelsList)
            {
                if(input.ToLower().Contains(m.ToLower()))
                {
                    model = m;
                }
            }

        }
    }
}
