using System.Text.Json.Nodes;

namespace eu.merrymake.service.csharp
{
    public interface IMerrymakeInterface
    {
        /// <summary>
        /// Used to link actions in the Merrymake.json file to code.
        /// </summary>
        /// <param name="action">the action from the Merrymake.json file</param> 
        /// <param name="handler"> the code to execute when the action is triggered</param>
        /// <returns>the Merrymake builder to define further actions</returns>
        IMerrymakeInterface Handle(string action, Action<byte[], Envelope> handler);
        /// <summary>
        /// Used to define code to run after deployment but before release. Useful for smoke tests or database consolidation. Similar to an 'init container'
        /// </summary>
        /// <param name="handler">the code to execute</param>
        void Init(Action handler);
    }
}
