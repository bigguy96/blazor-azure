using System.Text.Json.Serialization;

namespace Entities
{
    public class WorkItem
    {
        public int count { get; set; }
        public Value5[] value { get; set; }
    }

    public class Value5
    {
        public int id { get; set; }
        public int rev { get; set; }
        public Fields fields { get; set; }
        public string url { get; set; }
        public Commentversionref commentVersionRef { get; set; }
    }

    public class Fields
    {
        [JsonPropertyName("System.Id")]
        public int SystemId { get; set; }
        
        [JsonPropertyName("SystemIteration.Path")]
        public string SystemIterationPath { get; set; }
        
        [JsonPropertyName("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }
        
        [JsonPropertyName("SystemAssignedTo")]
        public SystemAssignedto SystemAssignedTo { get; set; }
        
        [JsonPropertyName("System.Title")]
        public string SystemTitle { get; set; }
        
        [JsonPropertyName("System.Description")]
        public string SystemDescription { get; set; }
        
        [JsonPropertyName("Microsoft.VSTS.TCM.ReproSteps")]
        public string MicrosoftVSTSTCMReproSteps { get; set; }
        
        [JsonPropertyName("Microsoft.VSTS.Common.AcceptanceCriteria")]
        public string MicrosoftVSTSCommonAcceptanceCriteria { get; set; }
    }

    public class SystemAssignedto
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public _Links3 _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class _Links3
    {
        public Avatar avatar { get; set; }
    }

    //public class Avatar
    //{
    //    public string href { get; set; }
    //}

    public class Commentversionref
    {
        public int commentId { get; set; }
        public int version { get; set; }
        public string url { get; set; }
    }
}