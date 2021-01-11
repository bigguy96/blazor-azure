namespace Entities
{
    public class RepositoryFile
    {
        public int count { get; set; }
        public Value3[] value { get; set; }
    }

    public class Value3
    {
        public string objectId { get; set; }
        public string gitObjectType { get; set; }
        public string commitId { get; set; }
        public string path { get; set; }
        public bool isFolder { get; set; }
        public Contentmetadata contentMetadata { get; set; }
        public string url { get; set; }
    }

    public class Contentmetadata
    {
        public string fileName { get; set; }
    }
}