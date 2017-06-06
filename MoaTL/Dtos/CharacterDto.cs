using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoaTL.Dtos
{
    public class CharacterDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PlayerClass { get; set; }

        public int? Wealth { get; set; }

        public List<string> Inventory { get; set; }

        public string Party { get; set; }

        public string Player { get; set; }
    }
}