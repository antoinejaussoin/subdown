using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using FT.Subdown.Core.Logging;
using FT.Subdown.Core.Requests;
using FT.Subdown.Core.Settings;
using OSDBnet;

namespace FT.Subdown.Core.Sources.OpenSubtitles
{
    public class OpenSubtitleSource : ISubtitleSource
    {
        private static Log Log = Log.Create(typeof (OpenSubtitleSource).Namespace);
        private readonly ISettingsService _settingsService;
        private readonly IOpenSubtitleLanguageTranslator _languageTranslator;

        public OpenSubtitleSource(ISettingsService settingsService, IOpenSubtitleLanguageTranslator languageTranslator)
        {
            _settingsService = settingsService;
            _languageTranslator = languageTranslator;
        }

        public IList<ISubtitleResult> Find(ISubtitleRequest request)
        {
            var results = new List<ISubtitleResult>();

            var client = Osdb.Login(_settingsService.Read<string>(SettingsKeys.OpenSubtitlesApiKey));
            var movie = request.MovieLocation;

            var hash = HashHelper.ComputeMovieHash(movie.FullName);
            var hexHash = HashHelper.ToHexadecimal(hash);

            var movies = client.CheckMovieHash(hexHash).ToList();

            if (!movies.Any())
            {
                Log.Error("Couldn't find any movie matching on OpenSubtitle matching " + movie.Name);
            }
            if (movies.Count > 1)
                Log.Warn(string.Format("Found more than one movie ({0}) matching {1}", movies.Count, movie.Name));

            foreach (var movieInfo in movies)
            {
                Log.Debug("Movie found: " + movieInfo.MovieName);
            }

            var subs = client.SearchSubtitlesFromFile("", movie.FullName);
            var notFoundLanguages = new Dictionary<string, CultureInfo>(request.Languages.ToDictionary(x => _languageTranslator.Convert(x)));

            foreach (var subtitle in subs)
            {
                Log.Debug(string.Format("[{2}] {0}: {1}", subtitle.LanguageName, subtitle.MovieName, subtitle.LanguageId));

                if (subtitle.SubtitleFileName.EndsWith(".srt") && notFoundLanguages.ContainsKey(subtitle.LanguageId))
                {
                    results.Add(new OpenSubtitleResult(subtitle, notFoundLanguages[subtitle.LanguageId], client));

                    notFoundLanguages.Remove(subtitle.LanguageId);
                }
            }

            if (notFoundLanguages.Any())
            {
                Log.Debug("Didn't find all requested languages, missing: " + notFoundLanguages.Select(x => x.Value.EnglishName).Aggregate((s, s1) => s + "," + s1) + ", so requeuing");
            }

            return results;
        }

        public int Reliability
        {
            get { return 10; }
        }
    }
}
