namespace DbCompare.Objects
{
    internal class ColumnCompare
    {
        public ColumnCompare()
        {
        }

        public ColumnCompare(ColumnInfo sourceColumn, ColumnInfo targetColumn)
        {
            SourceColumn = sourceColumn;
            TargetColumn = targetColumn;
        }

        public ColumnInfo SourceColumn;
        public ColumnInfo TargetColumn;
    }
}