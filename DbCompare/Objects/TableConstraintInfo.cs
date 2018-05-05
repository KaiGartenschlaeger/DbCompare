namespace DbCompare.Objects
{
    public class TableConstraintInfo
    {
        public string ConstraintSchema { get; set; }
        public string ConstraintName { get; set; }
        public string ConstraintType { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public bool IsDeferrable { get; set; }
        public bool InitiallyDeferred { get; set; }
    }
}