using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infistream.DataModel.Responses
{
    public sealed class SceneResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sources")]
        public IEnumerable<SourceResponse> Sources { get; set; }
    }
}
