using System;
using System.Text.Json;
using WebSocketSharp;

namespace Infistream.Services
{
    public sealed class StreamService
    {
        private readonly string _webSocketUri;
        private WebSocket _client;

        public event EventHandler<MessageEventArgs> OnMessage;

        public StreamService(string webSocketUri)
        {
            _webSocketUri = webSocketUri;
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
        }

        public void Send(object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            _client.Send(jsonData);
        }

        private void HandleMessage(object sender, MessageEventArgs args)
        {
            OnMessage?.Invoke(sender, args);
        }
    }
}
