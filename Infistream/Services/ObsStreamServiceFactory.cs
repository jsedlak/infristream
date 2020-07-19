using Infistream.ServiceModel;
using Microsoft.Extensions.Caching.Memory;

namespace Infistream.Services
{
    public sealed class ObsStreamServiceFactory : IStreamServiceFactory
    {
        private IMemoryCache _cache;
        private readonly IMessageIdProvider _messageIdProvider;

        public ObsStreamServiceFactory(IMessageIdProvider messageIdProvider, IMemoryCache memoryCache)
        {
            _messageIdProvider = messageIdProvider;
            _cache = memoryCache;
        }

        public IStreamService Connect(string webSocketUri)
        {
            return _cache.GetOrCreate(webSocketUri, (entry) =>
            {
                entry.AbsoluteExpiration = null;
                entry.SlidingExpiration = null;

                var service = new StreamService(webSocketUri, _messageIdProvider);
                service.Connect();

                return service;
            });
        }
    }
}
