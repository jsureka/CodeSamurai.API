namespace CodeSamurai.API.Models
{
    public class QueryParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
        public string? SortBy { get; set; }

        public string? Fields { get; set; }

        public string? Search { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }
    }
}
