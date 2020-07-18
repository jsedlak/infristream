using Infistream.ServiceModel;
using System;

namespace Infistream.Services
{
    public sealed class GuidMessageIdProvider : IMessageIdProvider
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
        }
    }
}
