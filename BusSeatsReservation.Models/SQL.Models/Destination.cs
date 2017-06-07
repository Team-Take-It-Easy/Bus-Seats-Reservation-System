namespace BusSeatsReservation.Models.SQL.Models
{
    public class Destination
    {
        public Destination(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
