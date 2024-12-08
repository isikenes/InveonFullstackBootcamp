using System.Text.Json.Serialization;

namespace _3_LibraryAPI.Utilities
{
    public class PagingParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        [JsonIgnore]
        public int Skip => (PageNumber - 1) * PageSize;
    }
}
