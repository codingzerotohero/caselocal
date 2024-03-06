using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace BlazorWebAssemblyApp.Extensions
{
    public class DocumentCollection
    {
        public List<Document> Documents { get; set; }

        public DocumentCollection()
        {
            Documents = new List<Document>();
        }
    }

    public class Document
    {
        [JsonProperty(PropertyName = "partitionKey")]
        public string? partitionKey { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? id { get; set; }

        [JsonProperty(PropertyName = "Innspill")]
        public string? Innspill { get; set; }

        [JsonProperty(PropertyName = "Anerkjent")]
        public string? Anerkjent { get; set; }

        [JsonProperty(PropertyName = "Tidspunkt")]
        public string? Tidspunkt { get; set; }
    }
}
