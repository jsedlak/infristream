using System.Text.Json.Serialization;

namespace Infistream.DataModel.Requests
{
    public sealed class ToggleMuteRequest : BaseRequest
    {
        public ToggleMuteRequest()
            : base(Requests.ToggleMute)
        {

        }

        public ToggleMuteRequest(string sourceName)
            : base(Requests.ToggleMute)
        {
            SourceName = sourceName;
        }

        [JsonPropertyName("source")]
        public string SourceName { get; set; }
    }
}
