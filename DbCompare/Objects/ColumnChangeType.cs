namespace DbCompare.Objects
{
    internal enum ColumnChangeType
    {
        Added,
        Removed,
        NullableChanged,
        MaxLengthChanged,
        DataTypeChanged,
        PositionChanged,
        DefaultValueChanged
    }
}