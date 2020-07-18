using System.Collections.Generic;

namespace Infistream.DataModel
{
    public sealed class StreamHost : Entity
    {
        public string Name { get; set; }

        public string WebSocketUri { get; set; }

        public IEnumerable<Scene> Scenes { get; set; }

    }
}
