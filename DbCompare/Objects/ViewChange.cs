namespace DbCompare.Objects
{
    internal class ViewChange
    {
        public ViewChange(ViewInfo source, ViewInfo target, ViewChangeType type)
        {
            Source = source;
            Target = target;
            ChangeType = type;
        }

        public ViewInfo Source { get; set; }
        public ViewInfo Target { get; set; }
        public ViewChangeType ChangeType { get; set; }
    }
}