namespace WebAPIDynamicLinq.Model
{
    public class QueryParams
    {
        public string? Filter { get; set; }
        public string? Select { get; set; }
        public string? Orderby { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public bool Count { get; set; } = false;
    }
}
