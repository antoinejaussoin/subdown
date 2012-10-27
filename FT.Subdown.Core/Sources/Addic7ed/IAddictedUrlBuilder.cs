using System.Web;

namespace FT.Subdown.Core.Sources.Addic7ed
{
    public interface IAddictedUrlBuilder
    {
        string BuildUrl(string search);
    }

    public class AddictedUrlBuilder : IAddictedUrlBuilder
    {
        private const string SearchUrl = "http://www.addic7ed.com/search.php?search={0}&Submit=Search";

        public string BuildUrl(string search)
        {
            var encodedSearch = HttpUtility.UrlEncode(search);
            return string.Format(SearchUrl, encodedSearch);
        }
    }
}
