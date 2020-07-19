using Infistream.DataModel.Requests;
using Infistream.DataModel.Responses;
using Infistream.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebSocketSharp;

namespace Infistream.Services
{
    public sealed class StreamService : IStreamService
    {
        private readonly string _webSocketUri;
        private readonly IMessageIdProvider _messageIdProvider;
        private readonly Dictionary<string, Action<MessageEventArgs>> _callbacks = new Dictionary<string, Action<MessageEventArgs>>();
        private WebSocket _client;

        public event EventHandler<MessageEventArgs> OnMessage;
        public event EventHandler<IEnumerable<string>> ScenesListed;
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public StreamService(string webSocketUri, IMessageIdProvider messageIdProvider)
        {
            _webSocketUri = webSocketUri;
            _messageIdProvider = messageIdProvider;
        }

        public void Connect()
        {
            if(_client != null && _client.ReadyState != WebSocketState.Closed)
            {
                return;
            }

            _client = new WebSocket(_webSocketUri);
            _client.OnMessage += HandleMessage;
            _client.Connect();

            Connected?.Invoke(this, EventArgs.Empty);
        }

        public void Disconnect()
        {
            _client.Close();
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        private void Send<TRequest>(TRequest data, Action<MessageEventArgs> callback = null) where TRequest : BaseRequest
        {
            // setup the message id
            data.MessageId = _messageIdProvider.Generate();

            // set the callback
            if(callback != null)
            {
                _callbacks[data.MessageId] = callback;
            }

            // serialize
            var jsonData = JsonSerializer.Serialize(data);

            // and ship it!
            _client.Send(jsonData);
        }

        private void HandleMessage(object sender, MessageEventArgs args)
        {
            OnMessage?.Invoke(sender, args);

            if (!args.IsText)
            {
                return;
            }

            var doc = JsonDocument.Parse(args.Data);

            if(doc.RootElement.TryGetProperty("message-id", out JsonElement element))
            {
                var messageId = element.GetString();
                if (_callbacks.ContainsKey(messageId))
                {
                    var callback = _callbacks[messageId];
                    _callbacks.Remove(messageId);
                    callback(args);
                }
            }
        }

        public void SetMute(string sourceName, bool mute)
        {
            Send(new SetMuteRequest(sourceName, mute));
        }

        public void ToggleMute(string sourceName)
        {
            Send(new ToggleMuteRequest(sourceName));
        }

        public void ChangeScene(string sceneName)
        {
            Send(new ChangeSceneRequest(sceneName));
        }

        public void RequestScenes()
        {
            Send(new ListScenesRequest(), (args) => {
                var response = JsonSerializer.Deserialize<SceneListResponse>(args.Data);
                ScenesListed?.Invoke(this, response.Scenes.Select(m => m.Name));
            });
        }

        public bool IsConnected { get { return _client.ReadyState == WebSocketState.Open; } }
    }
}
