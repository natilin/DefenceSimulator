using System.ComponentModel.DataAnnotations;
using DefenceSimulator.Enums;

namespace DefenceSimulator.Models
{
    public class Salvo
    {
        [Key]
        public int SalvoId { get; set; }
        [Required]
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        // New property: Time when the threat was launched
        public DateTime LaunchTime { get; set; }
        // Foreign Key for Weapon
        public int WeaponId { get; set; }
        // Navigation property for Weapon
        public Weapon Weapon { get; set; }
        public Response? Response { get; set; }
    }
}
