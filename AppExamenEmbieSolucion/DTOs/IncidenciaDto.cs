namespace DTOs
{
    public class IncidenciaDto
    {
        public int Id { get; set; }
        public string NameClient { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ReportedAt { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
