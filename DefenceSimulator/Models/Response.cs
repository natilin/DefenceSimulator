using DefenceSimulator.Enums;
using System.ComponentModel.DataAnnotations;

namespace DefenceSimulator.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public int SalvoId { get; set; }
        public Salvo salvo { get; set; }
        [Required]
        public DateTime LaunchTime { get; set; }
        public DateTime? InterceptTime { get; set; }
        public ResponseStatus status { get; set; }
    }
}