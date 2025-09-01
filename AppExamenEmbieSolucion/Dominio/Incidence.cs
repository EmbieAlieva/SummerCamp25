using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Incidence
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string NameClient { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime ReportedAt { get; set; }
        [Required]
        public bool IsUrgent { get; set; }
        [Required]
        public IncidentStatus Status { get; set; }
    }

    public enum IncidentStatus
    {
        Reported,
        InProgress,
        Resolved,
        Closed
    }


}
