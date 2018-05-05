namespace DbCompare.Objects
{
    public class ColumnInfo
    {
        public string Schema { get; set; }
        public string Table { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public long MaximumLength { get; set; }
        public bool IsNullable { get; set; }
        public int Position { get; set; }
        public string Default { get; set; }
    }
}