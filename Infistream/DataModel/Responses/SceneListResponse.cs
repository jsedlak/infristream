using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infistream.DataModel.Responses
{
    public sealed class SceneListResponse
    {
        [JsonPropertyName("current-scene")]
        public string CurrentScene { get; set; }

        [JsonPropertyName("scenes")]
        public IEnumerable<SceneResponse> Scenes { get; set; }
    }
}
