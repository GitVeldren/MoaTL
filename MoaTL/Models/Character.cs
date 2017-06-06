using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoaTL.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ApplicationUser Player { get; set; }

        public string PlayerName { get; set; }

        [Required]
        public string PlayerId { get; set; }

        [Display(Name = "Class")]
        public string PlayerClass { get; set; }

        public int? Wealth { get; set; }

        public List<Item> Inventory { get; set; }

        public Party Party { get; set; }

        public string PartyId { get; set; }
    }
}