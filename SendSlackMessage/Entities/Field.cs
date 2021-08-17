using System.Text.Json.Serialization;

namespace SendSlackMessage.Entities
{
    public class Field
    {

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("short")]
        public bool Short { get; set; }
    }
}
