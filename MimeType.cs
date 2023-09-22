namespace eu.merrymake.service.csharp
{
    public class MimeType
    {
        public string Type { get; }
        public string Tail { get; }

        public static readonly MimeType aac = new ("audio", "aac");
        public static readonly MimeType abw = new ("application", "x-abiword");
        public static readonly MimeType arc = new ("application", "x-freearc");
        public static readonly MimeType avif = new ("image", "avif");
        public static readonly MimeType avi = new ("video", "x-msvideo");
        public static readonly MimeType azw = new ("application", "vnd.amazon.ebook");
        public static readonly MimeType bin = new ("application", "octet-stream");
        public static readonly MimeType bmp = new ("image", "bmp");
        public static readonly MimeType bz = new ("application", "x-bzip");
        public static readonly MimeType bz2 = new ("application", "x-bzip2");
        public static readonly MimeType cda = new ("application", "x-cdf");
        public static readonly MimeType csh = new ("application", "x-csh");
        public static readonly MimeType css = new ("text", "css");
        public static readonly MimeType csv = new ("text", "csv");
        public static readonly MimeType doc = new ("application", "msword");
        public static readonly MimeType docx = new ("application", "vnd.openxmlformats-officedocument.wordprocessingml.document");
        public static readonly MimeType eot = new ("application", "vnd.ms-fontobject");
        public static readonly MimeType epub = new("application", "epub+zip");
        public static readonly MimeType gz = new ("application", "gzip");
        public static readonly MimeType gif = new ("image", "gif");
        public static readonly MimeType htm = new ("text", "html");
        public static readonly MimeType html = new ("text", "html");
        public static readonly MimeType ico = new ("image", "vnd.microsoft.icon");
        public static readonly MimeType ics = new ("text", "calendar");
        public static readonly MimeType jar = new ("application", "java-archive");
        public static readonly MimeType jpeg = new ("image", "jpeg");
        public static readonly MimeType jpg = new ("image", "jpeg");
        public static readonly MimeType js = new ("text", "javascript");
        public static readonly MimeType json = new ("application", "json");
        public static readonly MimeType jsonld = new ("application", "ld+json");
        public static readonly MimeType mid = new ("audio", "midi");
        public static readonly MimeType midi = new ("audio", "midi");
        public static readonly MimeType mjs = new ("text", "javascript");
        public static readonly MimeType mp3 = new ("audio", "mpeg");
        public static readonly MimeType mp4 = new ("video", "mp4");
        public static readonly MimeType mpeg = new ("video", "mpeg");
        public static readonly MimeType mpkg = new ("application", "vnd.apple.installer+xml");
        public static readonly MimeType odp = new ("application", "vnd.oasis.opendocument.presentation");
        public static readonly MimeType ods = new ("application", "vnd.oasis.opendocument.spreadsheet");
        public static readonly MimeType odt = new ("application", "vnd.oasis.opendocument.text");
        public static readonly MimeType oga = new ("audio", "ogg");
        public static readonly MimeType ogv = new ("video", "ogg");
        public static readonly MimeType ogx = new ("application", "ogg");
        public static readonly MimeType opus = new ("audio", "opus");
        public static readonly MimeType otf = new ("font", "otf");
        public static readonly MimeType png = new ("image", "png");
        public static readonly MimeType pdf = new ("application", "pdf");
        public static readonly MimeType php = new ("application", "x-httpd-php");
        public static readonly MimeType ppt = new ("application", "vnd.ms-powerpoint");
        public static readonly MimeType pptx = new ("application", "vnd.openxmlformats-officedocument.presentationml.presentation");
        public static readonly MimeType rar = new ("application", "vnd.rar");
        public static readonly MimeType rtf = new ("application", "rtf");
        public static readonly MimeType sh = new ("application", "x-sh");
        public static readonly MimeType svg = new ("image", "svg+xml");
        public static readonly MimeType tar = new ("application", "x-tar");
        public static readonly MimeType tif = new ("image", "tiff");
        public static readonly MimeType tiff = new ("image", "tiff");
        public static readonly MimeType ts = new ("video", "mp2t");
        public static readonly MimeType ttf = new ("font", "ttf");
        public static readonly MimeType txt = new ("text", "plain");
        public static readonly MimeType vsd = new ("application", "vnd.visio");
        public static readonly MimeType wav = new ("audio", "wav");
        public static readonly MimeType weba = new ("audio", "webm");
        public static readonly MimeType webm = new ("video", "webm");
        public static readonly MimeType webp = new ("image", "webp");
        public static readonly MimeType woff = new ("font", "woff");
        public static readonly MimeType woff2 = new ("font", "woff2");
        public static readonly MimeType xhtml = new ("application", "xhtml+xml");
        public static readonly MimeType xls = new ("application", "vnd.ms-excel");
        public static readonly MimeType xlsx = new ("application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        public static readonly MimeType xml = new ("application", "xml");
        public static readonly MimeType xul = new ("application", "vnd.mozilla.xul+xml");
        public static readonly MimeType zip = new ("application", "zip");
        public static readonly MimeType _3gp = new ("video", "3gpp");
        public static readonly MimeType _3g2 = new ("video", "3gpp2");
        public static readonly MimeType _7z = new ("application", "x-7z-compressed");

        public MimeType(string type, string tail)
        {
            Type = type;
            Tail = tail;
        }

        public static Dictionary<string, MimeType> ext2mime = new Dictionary<string, MimeType>
            {
                { "aac", aac },
                { "abw", abw },
                { "arc", arc },
                { "avif", avif },
                { "avi", avi },
                { "azw", azw },
                { "bin", bin },
                { "bmp", bmp },
                { "bz", bz },
                { "bz2", bz2 },
                { "cda", cda },
                { "csh", csh },
                { "css", css },
                { "csv", csv },
                { "doc", doc },
                { "docx", docx },
                { "eot", eot },
                { "epub", epub },
                { "gz", gz },
                { "gif", gif },
                { "htm", htm },
                { "html", html },
                { "ico", ico },
                { "ics", ics },
                { "jar", jar },
                { "jpeg", jpeg },
                { "jpg", jpg },
                { "js", js },
                { "json", json },
                { "jsonld", jsonld },
                { "mid", mid },
                { "midi", midi },
                { "mjs", mjs },
                { "mp3", mp3 },
                { "mp4", mp4 },
                { "mpeg", mpeg },
                { "mpkg", mpkg },
                { "odp", odp },
                { "ods", ods },
                { "odt", odt },
                { "oga", oga },
                { "ogv", ogv },
                { "ogx", ogx },
                { "opus", opus },
                { "otf", otf },
                { "png", png },
                { "pdf", pdf },
                { "php", php },
                { "ppt", ppt },
                { "pptx", pptx },
                { "rar", rar },
                { "rtf", rtf },
                { "sh", sh },
                { "svg", svg },
                { "tar", tar },
                { "tif", tif },
                { "tiff", tiff },
                { "ts", ts },
                { "ttf", ttf },
                { "txt", txt },
                { "vsd", vsd },
                { "wav", wav },
                { "weba", weba },
                { "webm", webm },
                { "webp", webp },
                { "woff", woff },
                { "woff2", woff2 },
                { "xhtml", xhtml },
                { "xls", xls },
                { "xlsx", xlsx },
                { "xml", xml },
                { "xul", xul },
                { "zip", zip },
                { "3gp", _3gp },
                { "3g2", _3g2 },
                { "7z", _7z },
            };

        public override string ToString()
        {
            return Type + "/" + Tail;
        }
    }
}
