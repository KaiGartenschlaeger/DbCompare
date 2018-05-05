using System.Collections.Generic;

namespace DbCompare.Objects
{
    public class Profile
    {
        public Profile()
        {
            ExcludedSchemas = new List<string>();
            ExcludedObjects = new List<string>();
        }

        public string SourceHost { get; set; }
        public string SourceUsername { get; set; }
        public string SourcePassword { get; set; }
        public bool SourceIntegratedMode { get; set; }
        public string SourceDatabase { get; set; }

        public string TargetHost { get; set; }
        public string TargetUsername { get; set; }
        public string TargetPassword { get; set; }
        public bool TargetIntegratedMode { get; set; }
        public string TargetDatabase { get; set; }

        public List<string> ExcludedSchemas { get; }
        public List<string> ExcludedObjects { get; }
    }
}