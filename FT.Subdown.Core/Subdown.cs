using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using FT.Subdown.Core.Containers;
using FT.Subdown.Core.Engines;
using StructureMap;

namespace FT.Subdown.Core
{
    public static class Subdown
    {
        private static IEngine _engine;

        static Subdown()
        {
            Bootstrap.Run();
        }

        public static void DownloadSubtitles(FileInfo movie, params CultureInfo[] languages)
        {
            if (_engine == null)
                _engine = ObjectFactory.GetInstance<IEngine>();

            _engine.Download(movie, languages);
        }

        public static void Plop()
        {
            var languages = OSDBnet.Osdb.Login("Monitr v0.1").GetSubLanguages();
            foreach (var language in languages)
            {
                Console.Out.WriteLine(language.LanguageName);
                Console.Out.WriteLine(language.SubLanguageID);
                Console.Out.WriteLine(language.ISO639);
            }
        }
    }
}
