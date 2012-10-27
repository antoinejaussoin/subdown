using FT.Subdown.Core.Sources.Addic7ed;
using Machine.Specifications;

namespace FT.Subdown.Tests.Core.Sources.Addic7ed
{
    public class AddictedResultExtractorTests
    {
#pragma warning disable 169
        // ReSharper disable InconsistentNaming
        // ReSharper disable UnusedMember.Global
        // ReSharper disable UnusedMember.Local

        public abstract class AddictedResultExtractorSpecs
        {
            Establish context = () =>
            {
                _systemUnderTest = new AddictedResultExtractor();
            };

            protected static AddictedResultExtractor _systemUnderTest;
        }

        [Subject(typeof (AddictedResultExtractor))]
        public class when_extracting_query_results_from_page : AddictedResultExtractorSpecs
        {
            Establish context = () => _resultPageContent = TestFileHelper.ReadFile("AddictedSearchResult1.txt");

            It should_have_one_item = () => _systemUnderTest.ExtractResultUrl(_resultPageContent).Count.ShouldEqual(1);

            It should_have_the_item_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[0].ShouldEqual("serie/Last_Resort/1/5/Skeleton_Crew");

            private static string _resultPageContent;
        }

        [Subject(typeof(AddictedResultExtractor))]
        public class when_extracting_query_results_from_page_with_5_results : AddictedResultExtractorSpecs
        {
            Establish context = () => _resultPageContent = TestFileHelper.ReadFile("AddictedSearchResult2.txt");

            It should_have_one_item = () => _systemUnderTest.ExtractResultUrl(_resultPageContent).Count.ShouldEqual(5);

            It should_have_the_item_1_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[0].ShouldEqual("serie/The_Big_Bang_Theory/1/2/The_big_bran_hypothesis");
            It should_have_the_item_2_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[1].ShouldEqual("serie/The_Big_Bang_Theory/2/11/The_Bath_Item_Gift_Hypothesis");
            It should_have_the_item_3_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[2].ShouldEqual("serie/The_Big_Bang_Theory/4/10/The_Alien_Parasite_Hypothesis");
            It should_have_the_item_4_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[3].ShouldEqual("serie/The_Big_Bang_Theory/5/2/The_Infestation_Hypothesis");
            It should_have_the_item_5_correct = () => _systemUnderTest.ExtractResultUrl(_resultPageContent)[4].ShouldEqual("serie/The_Big_Bang_Theory/5/13/The_Recombination_Hypothesis");

            private static string _resultPageContent;
        }

        [Subject(typeof(AddictedResultExtractor))]
        public class when_extracting_the_subtitles : AddictedResultExtractorSpecs
        {
            Establish context = () => _resultPageContent = TestFileHelper.ReadFile("AddictedEpisodePage.txt");

            It should_have_nine_item = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent).Count.ShouldEqual(9);

            It should_have_the_correct_download_link_for_file_1 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[0].DownloadLink.ShouldEqual("/original/68189/3");
            It should_have_the_correct_language_for_file_1 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[0].Language.ShouldEqual("English");
            It should_have_the_correct_number_of_editions_for_file_1 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[0].Edited.ShouldEqual(0);
            It should_have_the_correct_number_of_downloads_for_file_1 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[0].Downloads.ShouldEqual(675);

            It should_have_the_correct_download_link_for_file_2 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[1].DownloadLink.ShouldEqual("/original/68189/1");
            It should_have_the_correct_language_for_file_2 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[1].Language.ShouldEqual("English");
            It should_have_the_correct_number_of_editions_for_file_2 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[1].Edited.ShouldEqual(0);
            It should_have_the_correct_number_of_downloads_for_file_2 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[1].Downloads.ShouldEqual(4834);

            It should_have_the_correct_download_link_for_file_3 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[2].DownloadLink.ShouldEqual("/updated/35/68189/1");
            It should_have_the_correct_language_for_file_3 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[2].Language.ShouldEqual("Bulgarian");
            It should_have_the_correct_number_of_editions_for_file_3 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[2].Edited.ShouldEqual(398);
            It should_have_the_correct_number_of_downloads_for_file_3 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[2].Downloads.ShouldEqual(44);

            It should_have_the_correct_download_link_for_file_4 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[3].DownloadLink.ShouldEqual("/original/68189/2");
            It should_have_the_correct_language_for_file_4 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[3].Language.ShouldEqual("English");
            It should_have_the_correct_number_of_editions_for_file_4 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[3].Edited.ShouldEqual(0);
            It should_have_the_correct_number_of_downloads_for_file_4 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[3].Downloads.ShouldEqual(283);

            It should_have_the_correct_download_link_for_file_5 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[4].DownloadLink.ShouldEqual("/original/68189/0");
            It should_have_the_correct_language_for_file_5 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[4].Language.ShouldEqual("English");
            It should_have_the_correct_number_of_editions_for_file_5 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[4].Edited.ShouldEqual(3);
            It should_have_the_correct_number_of_downloads_for_file_5 = () => _systemUnderTest.ExtractSubtitleRecords(_resultPageContent)[4].Downloads.ShouldEqual(3946);

            private static string _resultPageContent;
        }
    }
}
