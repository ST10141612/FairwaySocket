using SignalRServer.Models;

namespace SignalRServer
{
    public interface IGameHubClient
    {
        Task ReceiveUpdate(UpdateInstruction instruction);
    }
}
