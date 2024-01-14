namespace Movies.Models.Response
{
    public class PageParams
    {
        public int Take { get; set; } = 200;
        public int Skip { get; set; } = 0;
        public string? OrderBy { get; set; } = "Title";
        public string? Filter { get; set; } 
        public string? FilterByType { get; set; } 
    }
}
