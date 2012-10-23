using System.Globalization;
using System.IO;
using FT.Subdown.Core.Logging;
using OSDBnet;

namespace FT.Subdown.Core.Sources.OpenSubtitles
{
    public class OpenSubtitleResult : ISubtitleResult
    {
        private static Log Log = Log.Create(typeof(OpenSubtitleSource).Namespace);

        private readonly Subtitle _subtitle;
        private readonly CultureInfo _language;
        private readonly IAnonymousClient _client;

        public OpenSubtitleResult(Subtitle subtitle, CultureInfo language, IAnonymousClient client)
        {
            _subtitle = subtitle;
            _language = language;
            _client = client;
        }

        public string FileName { get { return _subtitle.SubtitleFileName; } }

        public CultureInfo Language { get { return _language; } }

        public void DownloadTo(TextWriter destination)
        {
            var tempFile = Path.GetTempPath();
            var subFile = new FileInfo(_client.DownloadSubtitleToPath(tempFile, _subtitle));

            Log.Info("Downloading subtitle for " + _subtitle.MovieName + ": " + _subtitle.SubtitleFileName);
            
            using (var reader = subFile.OpenText())
            {
                destination.Write(reader.ReadToEnd());
            }

            subFile.Delete();
        }
    }
}
