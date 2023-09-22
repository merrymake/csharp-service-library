using System.Text.Json.Nodes;

namespace eu.merrymake.service.csharp
{
    internal class NullMerrymake : IMerrymakeInterface
    {
        public IMerrymakeInterface Handle(string action, Action<byte[], JsonObject> handler)
        {
            return this;
        }

        public void Init(Action handler)
        {

        }
    }
}