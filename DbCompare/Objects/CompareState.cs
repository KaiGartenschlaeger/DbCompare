namespace DbCompare.Objects
{
    internal enum CompareState
    {
        ClearGUI,
        Connecting,

        Compare,

        AddedTable,
        RemovedTable,

        ViewAdded,
        ViewChanged,
        ViewRemoved,

        AddedColumn,
        RemovedColumn,
        CompareColumn,

        RefreshGUITables,
        RefreshGUIViews,
        RefreshGUIRoutines,
        RefreshGUIIndizees,
        RefreshGUIColumns,
        RefreshGUIForeignKeys,
        
        RoutineAdded,
        RoutineRemoved,
        RoutineChanged,

        TableConstraintAdded,
        TableConstraintRemoved,
        TableConstraintChanged,

        IndexAdded,
        IndexRemoved,
        IndexChanged,

        ForeignKeyAdded,
        ForeignKeyRemoved
    }
}