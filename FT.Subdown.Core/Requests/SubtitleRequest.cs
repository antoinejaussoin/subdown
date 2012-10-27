using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FT.Subdown.Core.Requests
{
    public class SubtitleRequest : ISubtitleRequest
    {
        public SubtitleRequest(FileInfo movieLocation, IList<CultureInfo> languages)
        {
            MovieLocation = movieLocation;
            Languages = languages;
        }

        public SubtitleRequest(string movieName, IList<CultureInfo> languages)
        {
            MovieName = movieName;
            Languages = languages;
        }

        public string MovieName { get; private set; }

        public FileInfo MovieLocation { get; private set; }

        public IList<CultureInfo> Languages { get; private set; }
    }
}