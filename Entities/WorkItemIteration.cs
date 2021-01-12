namespace Entities
{
    public class WorkItemIteration
    {
        public Workitemrelation[] workItemRelations { get; set; }
        public string url { get; set; }
        public _Links2 _links { get; set; }
    }

    public class _Links2
    {
        public Self self { get; set; }
        public Project2 project { get; set; }
        public Team team { get; set; }
        public Teamiteration teamIteration { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Project2
    {
        public string href { get; set; }
    }

    public class Team
    {
        public string href { get; set; }
    }

    public class Teamiteration
    {
        public string href { get; set; }
    }

    public class Workitemrelation
    {
        public string rel { get; set; }
        public Source source { get; set; }
        public Target target { get; set; }
    }

    public class Source
    {
        public int id { get; set; }
        public string url { get; set; }
    }

    public class Target
    {
        public int id { get; set; }
        public string url { get; set; }
    }
}