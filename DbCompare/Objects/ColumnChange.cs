namespace DbCompare.Objects
{
    internal class ColumnChange
    {
        public ColumnChange(ColumnChangeType changeType, ColumnInfo srcColumn, ColumnInfo tarColumn)
        {
            ChangeType = changeType;
            SourceColumn = srcColumn;
            TargetColumn = tarColumn;
        }

        public ColumnChangeType ChangeType { get; set; }
        public ColumnInfo SourceColumn { get; set; }
        public ColumnInfo TargetColumn { get; set; }
    }
}