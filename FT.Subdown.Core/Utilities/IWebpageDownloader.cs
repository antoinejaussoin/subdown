using System.Net;
using System.Text;

namespace FT.Subdown.Core.Utilities
{
    public interface IWebpageDownloader
    {
        string Download(string url);
    }

    public class WebpageDownloader : IWebpageDownloader
    {
        public string Download(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            return client.DownloadString(url);
        }
    }
}
