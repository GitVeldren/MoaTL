using System.Collections.Generic;

namespace MoaTL.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DungeonMasterId { get; set; }
        public ApplicationUser DungeonMaster { get; set; }
        public List<Item> Inventory { get; set; }
        public double Wealth { get; set; }
    }
}