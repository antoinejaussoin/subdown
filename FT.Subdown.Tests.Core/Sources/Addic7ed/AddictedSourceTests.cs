using System.Collections.Generic;
using System.Globalization;
using FT.Subdown.Core.Requests;
using FT.Subdown.Core.Sources.Addic7ed;
using FT.Subdown.Core.Utilities;
using Machine.Specifications;

namespace FT.Subdown.Tests.Core.Sources.Addic7ed
{
    public class AddictedSourceTests
    {
#pragma warning disable 169
        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Global
        // ReSharper disable UnusedMember.Local

        public abstract class AddictedSourceSpecs
        {
            private Establish context = () =>
                                            {
                                                _systemUnderTest = new AddictedSource(new AddictedUrlBuilder(), new WebpageDownloader(), new AddictedResultExtractor());
                                            };

            protected static AddictedSource _systemUnderTest;
        }

        [Subject(typeof (AddictedSource))]
        public class when_TestName : AddictedSourceSpecs
        {
            private It should_work =
                () =>
                _systemUnderTest.Find(new SubtitleRequest("Last Resort - s01e05 - Skeleton Crew",
                                                          new List<CultureInfo>()));
        }
    }
}
