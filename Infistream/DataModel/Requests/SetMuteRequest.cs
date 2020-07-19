using System.Text.Json.Serialization;

namespace Infistream.DataModel.Requests
{
    public sealed class SetMuteRequest : BaseRequest
    {
        public SetMuteRequest()
            : base(Requests.SetMute)
        {

        }

        public SetMuteRequest(string sourceName, bool mute)
            : base(Requests.SetMute)
        {
            SourceName = sourceName;
            Mute = mute;
        }

        [JsonPropertyName("source")]
        public string SourceName { get; set; }

        [JsonPropertyName("mute")]
        public bool Mute { get; set; }
    }
}
