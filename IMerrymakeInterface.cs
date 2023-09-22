using System.Text.Json.Nodes;

namespace eu.merrymake.service.csharp
{
    public interface IMerrymakeInterface
    {
        IMerrymakeInterface Handle(string action, Action<byte[], JsonObject> handler);
        void Init(Action handler);
    }
}
