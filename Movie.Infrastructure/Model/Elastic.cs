namespace Movie.Infrastructure.Model
{
    public  class LogEntry
    {
        public string ServiceName { get; set; }
        public string Message { get; set; }
        public string Level { get; set; } = "Information"; 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Dictionary<string, object>? ExtraData { get; set; }
    }

}
