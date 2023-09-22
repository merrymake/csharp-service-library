using System.Text.Json.Nodes;

namespace eu.merrymake.service.csharp
{
    public class Merrymake: IMerrymakeInterface
    {
        private readonly string action;
        private readonly JsonObject envelope;
        private readonly byte[] payloadBytes;

        public static Merrymake Service(string[] args)
        {
            return new Merrymake(args);
        }

        private Merrymake(string[] args)
        {
            try
            {
                action = args[args.Length - 2];
                JsonNode? jsonNodeEnvelope = JsonNode.Parse(args[args.Length - 1]);
                if (jsonNodeEnvelope != null)
                {
                    envelope = jsonNodeEnvelope.AsObject();
                }
                payloadBytes = StreamHelper.ReadToEnd(Console.OpenStandardInput());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SystemException("Could not read from stdin");
            }
        }

        public IMerrymakeInterface Handle(string action, Action<byte[], JsonObject> handler)
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

        public static void PostToRapids(string pEvent, byte[] body, MimeType contentType)
        {
            HttpContent content = new ByteArrayContent(body);
            InternalPostToRapids(pEvent, content);
        }

        public static void PostToRapids(string pEvent, string body, MimeType contentType)
        {
            HttpContent content = new StringContent(body, System.Text.Encoding.UTF8, contentType.ToString());
            InternalPostToRapids(pEvent, content);
        }
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

        public static void ReplyToOrigin(byte[] body, MimeType contentType)
        {
            PostToRapids("$reply", body, contentType);
        }
        public static void ReplyToOrigin(string body, MimeType contentType)
        {
            PostToRapids("$reply", body, contentType);
        }

        public static void ReplyFileToOrigin(string path, MimeType contentType)
        {
            byte[] data = StreamHelper.ReadToEnd(File.OpenRead(path));
            PostToRapids("$reply", data, contentType);
        }

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

    }

}
