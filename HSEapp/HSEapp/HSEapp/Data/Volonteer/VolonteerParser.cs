using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HSEapp.Data.Volonteer
{
    class VolonteerParser
    {
        private List<VolonteerProjectTable> VolonteerData = new List<VolonteerProjectTable>();

        public void volonteerNewsParse()
        {
            try
            {
                var url = "https://www.hse.ru/volunteers/";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var XPath = "//div [@class='masonry__item']";
                var title = doc.DocumentNode.SelectNodes(XPath);
                //var element = new pfHSEDataDetailed();
                var counter = 0;
                foreach (var s in title)
                {
                    try
                    {
                        var element = new VolonteerProjectTable();
                        element.Name = ScrubHtml(s.SelectNodes("//div [@class='plate_news__title h4']")[counter].InnerText);
                        element.Description = ScrubHtml(s.SelectNodes("//div [@class='plate_news__text']")[counter].InnerText);
                        VolonteerData.Add(element);
                        counter += 1;
                        App.DatabaseVolonteerProjects.SaveProjectAsync(element);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;|&zwnj;|&raquo;|&laquo;|&mdash;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }
    }
}
