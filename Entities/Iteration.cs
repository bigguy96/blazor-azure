using System;

namespace Entities
{
   public class Iteration
    {
        public int count { get; set; }
        public Value4[] value { get; set; }
    }

    public class Value4
    {
        public string id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public Attributes attributes { get; set; }
        public string url { get; set; }
    }

    public class Attributes
    {
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public string timeFrame { get; set; }
    }
}