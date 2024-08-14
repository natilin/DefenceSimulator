using System.ComponentModel.DataAnnotations;

namespace DefenceSimulator.Models
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Distance { get; set; }
        public ICollection<Salvo>? Salvo { get; } = new List<Salvo>();


    }
}
