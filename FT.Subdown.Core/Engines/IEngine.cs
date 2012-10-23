using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using FT.Subdown.Core.Requests;
using FT.Subdown.Core.Sources;

namespace FT.Subdown.Core.Engines
{
    public interface IEngine
    {
        void Download(FileInfo movie, params CultureInfo[] languages);
    }

    public class Engine : IEngine
    {
        private readonly IList<ISubtitleSource> _sources;

        public Engine(IList<ISubtitleSource> sources)
        {
            _sources = sources.OrderByDescending(x => x.Reliability).ToList();
        }

        public void Download(FileInfo movie, params CultureInfo[] languages)
        {
            var request = new SubtitleRequest(movie, languages);

            foreach (var subtitleSource in _sources)
            {
                var results = subtitleSource.Find(request);

                foreach (var subtitleResult in results)
                {
                    subtitleResult.DownloadTo(new StreamWriter("c:\\out\\"+subtitleResult.FileName));
                }
            }
        }
    }
}
