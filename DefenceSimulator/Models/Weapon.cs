using DefenceSimulator.Enums;
using System.ComponentModel.DataAnnotations;

namespace DefenceSimulator.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        [Required]
        public string WeaponType { get; set; }
        public int Speed { get; set; }
        public int? DefenceWeaponId { get; set; }
        public DefenceWeapon? DefenceWeapon { get; set; }
    }
}