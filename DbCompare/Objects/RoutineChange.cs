namespace DbCompare.Objects
{
    internal class RoutineChange
    {
        public RoutineChange(RoutineInfo source, RoutineInfo target, RoutineChangeType type)
        {
            Source = source;
            Target = target;
            ChangeType = type;
        }


        public RoutineInfo Source { get; private set; }
        public RoutineInfo Target { get; private set; }

        public RoutineChangeType ChangeType { get; private set; }
    }
}