namespace Entities
{
    public class RepositoryBranch
    {
        public Value2[] value { get; set; }
        public int count { get; set; }
    }    

    public class Value2
    {
        public string name { get; set; }
        public string objectId { get; set; }
        public Creator creator { get; set; }
        public string url { get; set; }
    }

    public class Creator
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public _Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class _Links
    {
        public Avatar avatar { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }
}