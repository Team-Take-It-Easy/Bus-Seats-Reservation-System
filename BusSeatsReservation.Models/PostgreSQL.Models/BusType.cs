namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class BusType
    {
        public BusType(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
