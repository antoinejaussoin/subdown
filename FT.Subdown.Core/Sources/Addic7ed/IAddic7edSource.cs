using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using FT.Subdown.Core.Requests;
using FT.Subdown.Core.Utilities;

namespace FT.Subdown.Core.Sources.Addic7ed
{
    public class AddictedSource : ISubtitleSource
    {
        private readonly IAddictedUrlBuilder _urlBuilder;
        private readonly IWebpageDownloader _webpageDownloader;
        private readonly IAddictedResultExtractor _resultExtractor;


        public AddictedSource(IAddictedUrlBuilder urlBuilder, IWebpageDownloader webpageDownloader, IAddictedResultExtractor resultExtractor)
        {
            _urlBuilder = urlBuilder;
            _webpageDownloader = webpageDownloader;
            _resultExtractor = resultExtractor;
        }

        public IList<ISubtitleResult> Find(ISubtitleRequest request)
        {
            var url = _urlBuilder.BuildUrl(request.MovieName);
            var resultPage = _webpageDownloader.Download(url);

            var possibleResults = _resultExtractor.ExtractResultUrl(resultPage);

            // At the moment, if we don't have exactly one result, we give up (we'll improve that later)
            if (possibleResults.Count != 1)
                return new List<ISubtitleResult>();

            var secondResultPageUrl = "http://www.addic7ed.com/" + possibleResults[0];
            var secondResultPage = _webpageDownloader.Download(secondResultPageUrl);

            var results = _resultExtractor.ExtractSubtitleRecords(secondResultPage);

            foreach (var addictedSubtitle in results)
            {
                WebClient client = new WebClient();
                client.Headers.Add("Referer", secondResultPageUrl);

                var subtitle = client.DownloadString("http://www.addic7ed.com" + addictedSubtitle.DownloadLink);
                //var subtitle = _webpageDownloader.Download();

                using (var writer = new FileInfo(string.Format("c:\\out\\{0}.{1}.srt", request.MovieName, addictedSubtitle.Language)).CreateText())
                {
                    writer.Write(subtitle);
                }
            }

            return new List<ISubtitleResult>();
        }


        public int Reliability { get { return 30; } }
    }
}
