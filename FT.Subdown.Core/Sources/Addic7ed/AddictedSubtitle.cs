namespace FT.Subdown.Core.Sources.Addic7ed
{
    public class AddictedSubtitle
    {
        public AddictedSubtitle(string language, string downloadLink, int edited, int downloads)
        {
            Language = language;
            DownloadLink = downloadLink;
            Edited = edited;
            Downloads = downloads;
        }

        public string Language { get; private set; }

        public string DownloadLink { get; private set; }

        public int Edited { get; private set; }

        public int Downloads { get; private set; }
    }
}
