using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace DefenceSimulator.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class DefenceWeapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Weapon> Weapons { get; } = new List<Weapon>();

    }
}
