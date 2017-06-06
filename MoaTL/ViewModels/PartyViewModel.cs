using MoaTL.Models;
using System.Collections.Generic;

namespace MoaTL.ViewModels
{
    public class PartyViewModel
    {
        public Party Party { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
        public List<Character> Members { get; set; }
        public double Wealth { get; set; }
        public List<Item> Inventory { get; set; }
    }
}