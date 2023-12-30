# C# Service Library for Merrymake

This is the official C# service library for Merrymake. It defines all the basic functions needed to work with Merrymake.

## Usage

Here is the most basic example of how to use this library: 

```cs
using eu.merrymake.service.csharp;

namespace template.basic
{
    internal class Program
    {

        static void HandleHello(byte[] payloadBytes, Envelope envelope)
        {
            string payload = System.Text.Encoding.UTF8.GetString(payloadBytes);
            Merrymake.ReplyToOrigin($"Hello, {payload}!", MimeType.txt);
        }

        static void Main(string[] args)
        {
            Merrymake.Service(args)
                     .Handle("handleHello", HandleHello);
        }

    }
}
```

## Tutorials and templates

For more information check out our tutorials at [merrymake.dev](https://merrymake.dev).

All templates are available through our CLI and on our [GitHub](https://github.com/merrymake).
