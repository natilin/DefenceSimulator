using System.ComponentModel.DataAnnotations;
using DefenceSimulator.Enums;

namespace DefenceSimulator.Models
{
    public class Salvo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EnemyId { get; set; }
        public Enemy? Enemy { get; set; }
        // New property: Time when the threat was launched
        public DateTime? LaunchTime { get; set; }
        // Foreign Key for Weapon
        public int WeaponId { get; set; }
        // Navigation property for Weapon
        public Weapon? Weapon { get; set; }
        public int WeaponAmount {  get; set; }
        public bool IsActive { get; set; } = false;
        public ICollection<Response>? Responses { get; } = new List<Response>();

    }
}
