using System;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleRankTracker.Server
{
    public static class GoogleSearchRequest
    {
        public static string GetRankings(string keywords, string url)
        {
            var fullUrl = string.Format("{0}{1}", "https://www.google.co.uk/search?num=100&q=", WebUtility.UrlEncode(keywords));
            using var httpClient = new HttpClient();
            Task<string> t = httpClient.GetStringAsync(fullUrl);
            string strInput = t.Result;
            Regex regex = new ("<a href=\\\"/url\\?q=https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)");
            List<string> urls = regex.Matches(strInput)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            var ranks = (from u in urls where u.Contains(url, StringComparison.OrdinalIgnoreCase) select urls.IndexOf(u) + 1)
                .Distinct()
                .Where(x => x <= 100)
                .ToList();
            return (ranks.Count == 0 ? ranks.Count.ToString() : String.Join(",", ranks));
        }
    }
}
