using FT.Subdown.Core.Sources.Addic7ed;
using Machine.Specifications;

namespace FT.Subdown.Tests.Core.Sources.Addic7ed
{
    public class AddictedUrlBuilderTests
    {
        #pragma warning disable 169
        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Global
        // ReSharper disable UnusedMember.Local

        public abstract class AddictedUrlBuilderSpecs
        {
            Establish context = () =>
            {
                _systemUnderTest = new AddictedUrlBuilder();
            };

            protected static AddictedUrlBuilder _systemUnderTest;
        }

        [Subject(typeof(AddictedUrlBuilder))]
        public class when_building_the_addicted_url : AddictedUrlBuilderSpecs
        {
            It should_work = () => _systemUnderTest.BuildUrl("Last Resort - s01e05 - Skeleton Crew").ShouldEqual("http://www.addic7ed.com/search.php?search=Last+Resort+-+s01e05+-+Skeleton+Crew&Submit=Search");
        }
    }
}
