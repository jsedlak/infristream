using System.Collections.Generic;

namespace Infistream.DataModel
{
    public sealed class ActionSequence
    {
        public string Name { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
}
