using System.Text.Json;

namespace eu.merrymake.service.csharp
{
    public class Envelope
    {
        /// <summary>
        /// Id of this particular message.
        /// Note: it is _not_ unique, since multiple rivers can deliver the same message.
        /// The combination of (river, messageId) is unique.
        /// </summary>
        public readonly string MessageId;
        /// <summary>
        /// Id shared by all messages in the current trace, ie. stemming from the same
        /// origin.
        /// </summary>
        public readonly string TraceId;
        /// <summary>
        /// (Optional) Id corresponding to a specific originator. This id is rotated
        /// occasionally, but in the short term it is unique and consistent. Same
        /// sessionId implies the trace originated from the same device.
        /// </summary>
        public readonly string? SessionId;

        private class InternalEnvelope
        {
            public string messageId { get; set; }
            public string traceId { get; set; }
            public string? sessionId { get; set; }
        }

        internal Envelope(string arg)
        {
            var env = JsonSerializer.Deserialize<InternalEnvelope>(arg)!;
            this.MessageId = env.messageId;
            this.TraceId = env.traceId;
            this.SessionId = env.sessionId;
        }

    }

}
