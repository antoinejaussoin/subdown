using System.Globalization;
using System.IO;

namespace FT.Subdown.Core.Sources
{
    public interface ISubtitleResult
    {
        string FileName { get; }

        CultureInfo Language { get; }

        void DownloadTo(TextWriter destination);
    }
}
