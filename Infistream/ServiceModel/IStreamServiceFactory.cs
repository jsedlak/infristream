namespace Infistream.ServiceModel
{
    public interface IStreamServiceFactory
    {
        IStreamService Connect(string webSocketUri);
    }
}
