namespace CodeSamurai.API.Core.Domains
{
    public partial class BaseLog : BaseEntity
    {
        public int LogTypeId { get; set; }

        public string? ShortMessage { get; set; }

        public string? FullMessage { get; set; }

        public string? IpAddress { get; set; }

        public bool FromSearchEngine { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public LogType LogType
        {
            get => (LogType)LogTypeId;
            set => LogTypeId = (int)value;
        }
    }

}
