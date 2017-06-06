namespace MoaTL.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string Character { get; set; }

        public int CharacterId { get; set; }

        public string Item { get; set; }

        public int ItemId { get; set; }

        public double Value { get; set; }
    }
}