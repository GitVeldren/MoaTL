using System.Collections.Generic;
using MoaTL.Models;

namespace MoaTL.ViewModels
{
    public class InventoryViewModel
    {
        public Inventory Inventory { get; set; }
        public Character Character { get; set; }
        public List<Item> Items { get; set; }
    }
}