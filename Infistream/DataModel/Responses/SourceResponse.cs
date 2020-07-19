using System.Text.Json.Serialization;

namespace Infistream.DataModel.Responses
{
    public sealed class SourceResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
