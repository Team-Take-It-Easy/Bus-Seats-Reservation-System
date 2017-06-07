namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class BusTypePG
    {
        public BusTypePG(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
