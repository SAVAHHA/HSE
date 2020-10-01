using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace HSEapp.Data
{
    public class Parser
    {
        private List<pfHSEData> pfHSEData = new List<pfHSEData>();
        public List<pfHSEData> pfHSEParse()
        {
            try
            {
                int n = 1;
                while (true)
                {
                    if (n == 1)
                    {
                        var url = "https://pf.hse.ru/index.html";
                        var web = new HtmlWeb();
                        var doc = web.Load(url);
                        var XPath = "//div [@class='main content']";
                        var title = doc.DocumentNode.SelectNodes(XPath);
                        title.RemoveAt(0);
                        foreach (var s in title)
                        {
                            var element = new pfHSEData();
                            try
                            {
                                var name_text = s.InnerText.Split("Рекомендуемые образовательные программы:".ToCharArray());
                                element.URL = s.InnerHtml.Split("<a href=".ToCharArray())[1].Split(".html".ToCharArray())[0].Split('"')[1] + ".html";
                                element.Name = name_text[0];
                                var test = name_text[1].Split("Рекомендуемые магистерские программы:".ToCharArray());
                                if (test.Length == 1)
                                {
                                    var op_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray());
                                    element.OPs = op_text[0].Split(',').ToList();
                                    element.OPs[element.OPs.Count - 1] = element.OPs[element.OPs.Count - 1].Substring(0, element.OPs[element.OPs.Count - 1].Length - 12);
                                }
                                else
                                {
                                    var op_text = name_text[1].Split("Рекомендуемые магистерские программы:".ToCharArray());
                                    element.OPs = op_text[0].Split(',').ToList();
                                    element.OPs[element.OPs.Count - 1] = element.OPs[element.OPs.Count - 1].Substring(0, element.OPs[element.OPs.Count - 1].Length - 12);
                                    var mops_text = op_text[1].Split("Срок записи на проект истекает:".ToCharArray());
                                    element.MOPs = mops_text[0].Split(',').ToList();
                                    element.MOPs[element.MOPs.Count - 1] = element.MOPs[element.MOPs.Count - 1].Substring(0, element.MOPs[element.MOPs.Count - 1].Length - 12);
                                }
                                var deadline_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray())[1];
                                deadline_text = deadline_text.Split("Сроки реализации проекта:".ToCharArray())[0];
                                element.Deadline = deadline_text;
                                var period_text = name_text[1].Split("Сроки реализации проекта:".ToCharArray())[1];
                                period_text = period_text.Split("Количество кредитов:".ToCharArray())[0];
                                element.Period = period_text;
                                var point_text = name_text[1].Split("Количество кредитов:".ToCharArray())[1];
                                point_text = point_text.Split("Руководитель:".ToCharArray())[0];
                                element.Points = point_text;
                                var curator_text = name_text[1].Split("Руководитель:".ToCharArray())[1];
                                var curator_text_list = curator_text.Split(" ".ToCharArray());
                                curator_text = curator_text_list[1] + " " + curator_text_list[2];
                                element.Curator = curator_text;
                                pfHSEData.Add(element);
                            }
                            catch
                            {
                                var name_text = s.InnerText.Split("Рекомендуется:".ToCharArray());
                                element.URL = s.InnerHtml.Split("<a href=".ToCharArray())[1].Split(".html".ToCharArray())[0].Split('"')[1] + ".html";
                                element.Name = name_text[0];
                                element.OPs = new List<string>() { "Все направления" };
                                var deadline_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray())[1];
                                deadline_text = deadline_text.Split("Сроки реализации проекта:".ToCharArray())[0];
                                element.Deadline = deadline_text;
                                var period_text = name_text[1].Split("Сроки реализации проекта:".ToCharArray())[1];
                                period_text = period_text.Split("Количество кредитов:".ToCharArray())[0];
                                element.Period = period_text;
                                var point_text = name_text[1].Split("Количество кредитов:".ToCharArray())[1];
                                point_text = point_text.Split("Руководитель:".ToCharArray())[0];
                                element.Points = point_text;
                                var curator_text = name_text[1].Split("Руководитель:".ToCharArray())[1];
                                var curator_text_list = curator_text.Split(" ".ToCharArray());
                                curator_text = curator_text_list[1] + " " + curator_text_list[2];
                                element.Curator = curator_text;
                                pfHSEData.Add(element);
                            }
                        }
                        n += 1;
                    }
                    else
                    {
                        var url = $"https://pf.hse.ru/page{n}.html";
                        var web = new HtmlWeb();
                        var doc = web.Load(url);
                        var XPath = "//div [@class='main content']";
                        var title = doc.DocumentNode.SelectNodes(XPath);
                        title.RemoveAt(0);
                        foreach (var s in title)
                        {
                            var element = new pfHSEData();
                            try
                            {
                                var name_text = s.InnerText.Split("Рекомендуемые образовательные программы:".ToCharArray());
                                element.URL = s.InnerHtml.Split("<a href=".ToCharArray())[1].Split(".html".ToCharArray())[0].Split('"')[1] + ".html";
                                element.Name = name_text[0];
                                var test = name_text[1].Split("Рекомендуемые магистерские программы:".ToCharArray());
                                if (test.Length == 1)
                                {
                                    var op_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray());
                                    element.OPs = op_text[0].Split(',').ToList();
                                    element.OPs[element.OPs.Count - 1] = element.OPs[element.OPs.Count - 1].Substring(0, element.OPs[element.OPs.Count - 1].Length - 12);
                                }
                                else
                                {
                                    var op_text = name_text[1].Split("Рекомендуемые магистерские программы:".ToCharArray());
                                    element.OPs = op_text[0].Split(',').ToList();
                                    element.OPs[element.OPs.Count - 1] = element.OPs[element.OPs.Count - 1].Substring(0, element.OPs[element.OPs.Count - 1].Length - 12);
                                    var mops_text = op_text[1].Split("Срок записи на проект истекает:".ToCharArray());
                                    element.MOPs = mops_text[0].Split(',').ToList();
                                    element.MOPs[element.MOPs.Count - 1] = element.MOPs[element.MOPs.Count - 1].Substring(0, element.MOPs[element.MOPs.Count - 1].Length - 12);
                                }
                                var deadline_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray())[1];
                                deadline_text = deadline_text.Split("Сроки реализации проекта:".ToCharArray())[0];
                                element.Deadline = deadline_text;
                                var period_text = name_text[1].Split("Сроки реализации проекта:".ToCharArray())[1];
                                period_text = period_text.Split("Количество кредитов:".ToCharArray())[0];
                                element.Period = period_text;
                                var point_text = name_text[1].Split("Количество кредитов:".ToCharArray())[1];
                                point_text = point_text.Split("Руководитель:".ToCharArray())[0];
                                element.Points = point_text;
                                var curator_text = name_text[1].Split("Руководитель:".ToCharArray())[1];
                                var curator_text_list = curator_text.Split(" ".ToCharArray());
                                curator_text = curator_text_list[1] + " " + curator_text_list[2];
                                element.Curator = curator_text;
                                pfHSEData.Add(element);
                            }
                            catch
                            {
                                try
                                {
                                    var name_text = s.InnerText.Split("Рекомендуется:".ToCharArray());
                                    element.Name = name_text[0];
                                    element.OPs = new List<string>() { "Все направления" };
                                    var deadline_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray())[1];
                                    deadline_text = deadline_text.Split("Сроки реализации проекта:".ToCharArray())[0];
                                    element.Deadline = deadline_text;
                                    var period_text = name_text[1].Split("Сроки реализации проекта:".ToCharArray())[1];
                                    period_text = period_text.Split("Количество кредитов:".ToCharArray())[0];
                                    element.Period = period_text;
                                    var point_text = name_text[1].Split("Количество кредитов:".ToCharArray())[1];
                                    point_text = point_text.Split("Руководитель:".ToCharArray())[0];
                                    element.Points = point_text;
                                    var curator_text = name_text[1].Split("Руководитель:".ToCharArray())[1];
                                    var curator_text_list = curator_text.Split(" ".ToCharArray());
                                    curator_text = curator_text_list[1] + " " + curator_text_list[2];
                                    element.Curator = curator_text;
                                    pfHSEData.Add(element);
                                }
                                catch
                                {
                                    var name_text = s.InnerText.Split("Рекомендуемые магистерские программы:".ToCharArray());
                                    element.Name = name_text[0];
                                    var mops_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray());
                                    element.MOPs = mops_text[0].Split(',').ToList();
                                    element.MOPs[element.MOPs.Count - 1] = element.MOPs[element.MOPs.Count - 1].Substring(0, element.MOPs[element.MOPs.Count - 1].Length - 12);
                                    var deadline_text = name_text[1].Split("Срок записи на проект истекает:".ToCharArray())[1];
                                    deadline_text = deadline_text.Split("Сроки реализации проекта:".ToCharArray())[0];
                                    element.Deadline = deadline_text;
                                    var period_text = name_text[1].Split("Сроки реализации проекта:".ToCharArray())[1];
                                    period_text = period_text.Split("Количество кредитов:".ToCharArray())[0];
                                    element.Period = period_text;
                                    var point_text = name_text[1].Split("Количество кредитов:".ToCharArray())[1];
                                    point_text = point_text.Split("Руководитель:".ToCharArray())[0];
                                    element.Points = point_text;
                                    var curator_text = name_text[1].Split("Руководитель:".ToCharArray())[1];
                                    var curator_text_list = curator_text.Split(" ".ToCharArray());
                                    curator_text = curator_text_list[1] + " " + curator_text_list[2];
                                    element.Curator = curator_text;
                                    pfHSEData.Add(element);
                                }
                            }
                        }
                        n += 1;
                    }
                }
            }
            catch
            {
                //Console.WriteLine(pfHSEData.ToString());
            }
            return pfHSEData;
            //foreach (var proj in pfHSEData)
            //{
            //    FairProjectTable fairProject = new FairProjectTable();
            //    fairProject.Name = proj.Name;
            //    fairProject.JoinUntil = proj.Deadline;
            //   // fairProject.MOPs = proj.MOPs;
            //   // fairProject.OPs = proj.OPs;
            //    fairProject.Period = proj.Period;
            //    fairProject.CreditAmount = proj.Points;
            //   // fairProject.Curator = proj.Curator;
            //   // fairProject.URL = proj.URL;
            //    App.DatabaseFairProjects.SaveProjectAsync(fairProject);
            //}
        }
    }
    public class pfHSEData
    {
        public string URL;
        public string Name;
        public List<string> OPs;
        public List<string> MOPs;
        public string Deadline;
        public string Period;
        public string Points;
        public string Curator;
    }
}
