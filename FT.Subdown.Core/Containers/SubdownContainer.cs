using FT.Subdown.Core.Engines;
using FT.Subdown.Core.Sources;
using FT.Subdown.Core.Sources.OpenSubtitles;
using StructureMap.Configuration.DSL;

namespace FT.Subdown.Core.Containers
{
    public class SubdownContainer : Registry 
    {
        public SubdownContainer()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<IEngine>();
                x.WithDefaultConventions();
            });

            For<ISubtitleSource>().Add<OpenSubtitleSource>();
        }
    }
}
