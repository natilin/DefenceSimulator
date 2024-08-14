using DefenceSimulator.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DefenceSimulator.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Speed { get; set; }
        public int? DefenceWeaponId { get; set; }
        public DefenceWeapon? DefenceWeapon { get; set; }
    }
}