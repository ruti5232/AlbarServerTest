
namespace BLL.DTOs
{
    public class LogDTO
    {
        public int? LogId { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
        public string? Level { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public string? Source { get; set; }
        public string? RequestPath { get; set; }
    }
}
