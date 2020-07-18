using System.Text.Json.Serialization;

namespace Infistream.DataModel.Requests
{
    public sealed class RequestSceneChange : BaseRequest
    {
        public RequestSceneChange() 
            : base(RequestConstants.SetCurrentScene)
        {
        }

        public RequestSceneChange(string sceneName)
            : base(RequestConstants.SetCurrentScene)
        {
            SceneName = sceneName;
        }

        [JsonPropertyName("scene-name")]
        public string SceneName { get; set; }
    }
}
