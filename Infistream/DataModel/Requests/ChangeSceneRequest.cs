using System.Text.Json.Serialization;

namespace Infistream.DataModel.Requests
{
    public sealed class ChangeSceneRequest : BaseRequest
    {
        public ChangeSceneRequest() 
            : base(Requests.SetCurrentScene)
        {
        }

        public ChangeSceneRequest(string sceneName)
            : base(Requests.SetCurrentScene)
        {
            SceneName = sceneName;
        }

        [JsonPropertyName("scene-name")]
        public string SceneName { get; set; }
    }
}
