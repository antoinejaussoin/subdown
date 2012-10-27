using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FT.Subdown.Core.Sources.Addic7ed
{
    public interface IAddictedResultExtractor
    {
        IList<string> ExtractResultUrl(string pageContent);
        
        IList<AddictedSubtitle> ExtractSubtitleRecords(string pageContent);
    }

    public class AddictedResultExtractor : IAddictedResultExtractor
    {
        public IList<string> ExtractResultUrl(string pageContent)
        {
            IList<string> results = new List<string>();

            Regex regex = new Regex(@"<tr><td><img src=""images\/television\.png"" \/><\/td><td><a href=""(.*?)"" debug");
            var matches = regex.Matches(pageContent);

            foreach (Match match in matches)
            {
                results.Add(match.Groups[1].Value);
            }

            return results;
        }

        public IList<AddictedSubtitle> ExtractSubtitleRecords(string pageContent)
        {
            IList<AddictedSubtitle> results = new List<AddictedSubtitle>();

            Regex regex = new Regex(@"<td width=""21%"" class=""language"">(.*?)&nbsp;<a.*?<a class=""buttonDownload"" href=""(.*?)""><strong>.*?<\/strong>.*?(\d*?) times edited .? (\d*?) Downloads", RegexOptions.Multiline | RegexOptions.Singleline);
            var matches = regex.Matches(pageContent);

            foreach (Match match in matches)
            {
                results.Add(ParseOneMatch(match));
            }

            return results;
        }

        private AddictedSubtitle ParseOneMatch(Match match)
        {
            if (match.Groups.Count != 5)
                throw new Exception("There should be 5 groups");

            var language = match.Groups[1].Value.Trim();
            var url = match.Groups[2].Value;
            var edited = int.Parse(match.Groups[3].Value.Trim());
            var downloaded = int.Parse(match.Groups[4].Value.Trim());

            return new AddictedSubtitle(language, url, edited, downloaded);
        }
    }
}
