using System;
using System.Collections.Generic;
using WebSocketSharp;

namespace Infistream.ServiceModel
{
    public interface IStreamService
    {
        event EventHandler<MessageEventArgs> OnMessage;
        event EventHandler<IEnumerable<string>> ScenesListed;
        event EventHandler Connected;
        event EventHandler Disconnected;

        void Connect();

        void Disconnect();

        void ChangeScene(string sceneName);

        void RequestScenes();

        void ToggleMute(string sourceName);

        void SetMute(string sourceName, bool mute);

        bool IsConnected { get; }
    }
}
