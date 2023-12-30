using System.Text.Json;
using System.Text.Json.Nodes;

namespace eu.merrymake.service.csharp
{
    public class Merrymake : IMerrymakeInterface
    {
        private readonly string action;
        private readonly Envelope envelope;
        private readonly byte[] payloadBytes;

        /// <summary>
        /// This is the root call for a Merrymake service.
        /// </summary>
        /// <param name="args">the arguments from the main method</param>
        /// <returns>A Merrymake builder to make further calls on</returns>
        public static Merrymake Service(string[] args)
        {
            return new Merrymake(args);
        }

        private Merrymake(string[] args)
        {
            try
            {
                action = args[args.Length - 2];
                envelope = new Envelope(args[args.Length - 1]);
                payloadBytes = StreamHelper.ReadToEnd(Console.OpenStandardInput());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SystemException("Could not read from stdin");
            }
        }

        public IMerrymakeInterface Handle(string action, Action<byte[], Envelope> handler)
        {
            if (this.action == action)
            {
                handler(payloadBytes, envelope);
                return new NullMerrymake();
            }
            else
            {
                return this;
            }
        }

        public void Init(Action handler)
        {
            handler();
        }
        /// <summary>
        /// Post an event to the central message queue (Rapids), with a payload and its
        /// content type.
        /// </summary>
        /// <param name="event">      the event to post</param>
        /// <param name="body">       the payload</param>
        /// <param name="contentType">the content type of the payload</param>
        public static void PostToRapids(string pEvent, byte[] body, MimeType contentType)
        {
            HttpContent content = new ByteArrayContent(body);
            content.Headers.Remove("Content-Type");
            content.Headers.Add("Content-Type", contentType.ToString());
            InternalPostToRapids(pEvent, content);
        }
        /// <summary>
        /// Post an event to the central message queue (Rapids), with a payload and its
        /// content type.
        /// </summary>
        /// <param name="event">      the event to post</param>
        /// <param name="body">       the payload</param>
        /// <param name="contentType">the content type of the payload</param>
        public static void PostToRapids(string pEvent, string body, MimeType contentType)
        {
            HttpContent content = new StringContent(body, System.Text.Encoding.UTF8, contentType.ToString());
            InternalPostToRapids(pEvent, content);
        }
        /// <summary>
        /// Post an event to the central message queue (Rapids), without a payload.
        /// </summary>
        /// <param name="event">the event to post</param>
        public static void PostToRapids(string pEvent)
        {
            InternalPostToRapids(pEvent, null);
        }

        static void InternalPostToRapids(string pEvent, HttpContent? content)
        {
            try
            {
                var client = new HttpClient();
                string uri = $"{Environment.GetEnvironmentVariable("RAPIDS")}/{pEvent}";

                _ = client.PostAsync(uri, content).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("failed posting to rapids");
            }
        }

        /// <summary>
        /// Post a reply back to the originator of the trace, with a payload and its
        /// content type.
        /// </summary>
        /// <param name="body">       the payload</param>
        /// <param name="contentType">the content type of the payload</param>
        public static void ReplyToOrigin(byte[] body, MimeType contentType)
        {
            PostToRapids("$reply", body, contentType);
        }
        /// <summary>
        /// Post a reply back to the originator of the trace, with a payload and its
        /// content type.
        /// </summary>
        /// <param name="body">       the payload</param>
        /// <param name="contentType">the content type of the payload</param>
        public static void ReplyToOrigin(string body, MimeType contentType)
        {
            PostToRapids("$reply", body, contentType);
        }

        /// <summary>
        /// Send a file back to the originator of the trace.
        /// </summary>
        /// <param name="path">       the path to the file starting from main/resources</param>
        /// <param name="contentType">the content type of the file</param>
        public static void ReplyFileToOrigin(string path, MimeType contentType)
        {
            byte[] data = StreamHelper.ReadToEnd(File.OpenRead(path));
            PostToRapids("$reply", data, contentType);
        }

        /// <summary>
        /// Send a file back to the originator of the trace.
        /// </summary>
        /// <param name="path">the path to the file starting from main/resources</param>
        public static void ReplyFileToOrigin(string path)
        {
            byte[] data = StreamHelper.ReadToEnd(File.OpenRead(path));

            MimeType? mime;
            string extension = Path.GetExtension(path).Substring(1).ToLower();
            MimeType.ext2mime.TryGetValue(extension, out mime);

            if (mime == null)
            {
                throw new Exception("Unknown file type. Add mimeType argument.");
            }
            PostToRapids("$reply", data, mime);
        }
        /// <summary>
        /// Subscribe to a channel, so events will stream back messages broadcast to that
        /// channel. You can join multiple channels. You stay in the channel until the
        /// request is terminated.
        ///
        /// Note: The origin-event has to be set as "streaming: true" in the
        /// event-catalogue.
        /// </summary>
        /// <param name="channel">the channel to join</param>
        public static void JoinChannel(string channel)
        {
            PostToRapids("$join", channel, MimeType.txt);
        }
        /// <summary>
        /// Broadcast a message (event and payload) to all listeners in a channel.
        /// </summary>
        /// <param name="to">the channel to broadcast to</param>
        /// <param name="event">the event-type of the message</param>
        /// <param name="payload">the payload of the message</param>
        public static void BroadcastToChannel(string to, string evt, string payload)
        {
            PostToRapids("$broadcast", JsonSerializer.Serialize(new
            {
                to = to,
                @event = evt,
                payload = payload
            }), MimeType.json);
        }
    }

}
