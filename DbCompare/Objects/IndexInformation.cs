namespace DbCompare.Objects
{
    public class IndexInformation
    {
        public string Schema { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public string Index { get; set; }
        public int Type { get; set; }
        public bool IsUnique { get; set; }
        public bool IsPrimary { get; set; }
    }
}