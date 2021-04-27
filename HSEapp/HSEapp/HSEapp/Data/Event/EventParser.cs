using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace HSEapp.Data.Event
{
    class EventParser
    {
        private List<EventProjectTable> eventDataList = new List<EventProjectTable>();
        public void eventParse()
        {
            try
            {
                var url = "https://www.hse.ru/news/announcements/";
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var XPath = "//div [@class='b-events']";
                var title = doc.DocumentNode.SelectNodes(XPath);
                var counter = 0;
                var innerCounter = 0;
                foreach (var s in title)
                {
                    try
                    {
                        var innerTitle = s.SelectNodes("//div [@class='b-events__item js-events-item']");
                        counter += 1;
                        foreach (var k in innerTitle)
                        {
                            var element = new EventProjectTable();
                            element.Date = s.SelectNodes("//div [@class='title']")[counter - 1].InnerText;
                            element.Name = k.SelectNodes("//div [@class='b-events__body_title large']")[innerCounter].InnerText;
                            element.URL = k.SelectNodes("//div/p/a")[innerCounter].Attributes["href"].Value;
                            element.Time = k.SelectNodes("//div [@class='b-events__extra date']")[innerCounter].InnerText;
                            innerCounter += 1;
                            eventDataList.Add(element);
                            App.DatabaseEventProjects.SaveProjectAsync(element);
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                //Console.WriteLine(pfHSEData.ToString());
            }
            //return pfHSEData;
            //int i = 0;
            //foreach (var proj in pfHSEData)
            //{
            //FairProjectTable fairProject = new FairProjectTable();
            //fairProject.Id = i;
            //fairProject.Name = proj.Name;
            //fairProject.JoinUntil = proj.Deadline;
            //string mops = "";
            //foreach (var mop in proj.MOPs)
            //{
            //    mops += mop + ";";
            //}
            //fairProject.MOPs = mops;
            //string ops = "";
            //foreach (var op in proj.OPs)
            //{
            //    ops += op + ";";
            //}
            //fairProject.OPs = ops;
            //fairProject.Period = proj.Period;
            //fairProject.CreditAmount = proj.Points;
            //fairProject.Curator = proj.Curator;
            //fairProject.URL = proj.URL;
            //i += 1;
            //App.DatabaseFairProjects.SaveProjectAsync(fairProject);
            //}
        }
    }
}
