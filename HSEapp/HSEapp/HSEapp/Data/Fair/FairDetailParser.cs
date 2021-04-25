using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace HSEapp.Data.Fair
{
    public class FairDetailParser
    {
        private List<pfHSEData> pfHSEData = new List<pfHSEData>();
        private List<pfHSEDataDetailed> pfHSEDataDetailed = new List<pfHSEDataDetailed>();

        public void pfHSEDetailedParse(string URL)
        {
            try
            {
                        var url = URL;
                        var web = new HtmlWeb();
                        var doc = web.Load(url);
                        var XPath = "//div [@class='main']";
                        var title = doc.DocumentNode.SelectNodes(XPath);
                        //var element = new pfHSEDataDetailed();
                        var element = new CurrentFairProjectTable();
                        try
                        {
                            //element.Description = title.InnerText.Split(new string[] { "Рекомендуемые образовательные программы:" }, StringSplitOptions.None);
                            element.Description = title[0].InnerText.Replace("\r\n\r", "").Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            element.ID = title[0].InnerText.Split(new string[] { "Идентификационный номер проекта" }, StringSplitOptions.None)[1].Split(new string[] { "Кампус" }, StringSplitOptions.None)[0];
                            element.Campus = title[0].InnerText.Split(new string[] { "Кампус" }, StringSplitOptions.None)[1].Split(new string[] { "Руководитель" }, StringSplitOptions.None)[0];
                            element.Curator = title[0].InnerText.Split(new string[] { "Руководитель" }, StringSplitOptions.None)[1].Split(new string[] { "Соруководитель" }, StringSplitOptions.None)[0];
                            element.PartCurator = title[0].InnerText.Split(new string[] { "Соруководитель" }, StringSplitOptions.None)[1].Split(new string[] { "Подразделение-инициатор" }, StringSplitOptions.None)[0];
                            element.Initiator = title[0].InnerText.Split(new string[] { "Подразделение-инициатор" }, StringSplitOptions.None)[1].Split(new string[] { "Рекомендуется для образовательных программ" }, StringSplitOptions.None)[0];
                            element.OPs = title[0].InnerText.Split(new string[] { "Рекомендуется для образовательных программ" }, StringSplitOptions.None)[1].Split(new string[] { "Рекомендуется для магистерских программ" }, StringSplitOptions.None)[0];
                            element.MOPs = title[0].InnerText.Split(new string[] { "Рекомендуется для магистерских программ" }, StringSplitOptions.None)[1].Split(new string[] { "Тип проекта" }, StringSplitOptions.None)[0];
                            element.ProjectType = title[0].InnerText.Split(new string[] { "Тип проекта" }, StringSplitOptions.None)[1].Split(new string[] { "Тип занятости студента" }, StringSplitOptions.None)[0];
                            element.WorkType = title[0].InnerText.Split(new string[] { "Тип занятости студента" }, StringSplitOptions.None)[1].Split(new string[] { "Территория реализации проекта" }, StringSplitOptions.None)[0];
                            element.Territory = title[0].InnerText.Split(new string[] { "Территория реализации проекта" }, StringSplitOptions.None)[1].Split(new string[] { "Курс" }, StringSplitOptions.None)[0];
                            element.Course = title[0].InnerText.Split(new string[] { "Курс" }, StringSplitOptions.None)[1].Split(new string[] { "Сроки реализации проекта" }, StringSplitOptions.None)[0];
                            element.Dates = title[0].InnerText.Split(new string[] { "Сроки реализации проекта" }, StringSplitOptions.None)[1].Split(new string[] { "Заявки принимаются до" }, StringSplitOptions.None)[0];
                            element.Deadline = title[0].InnerText.Split(new string[] { "Заявки принимаются до" }, StringSplitOptions.None)[1].Split(new string[] { "Количество вакантных мест на проекте" }, StringSplitOptions.None)[0];
                            element.VacancyNum = title[0].InnerText.Split(new string[] { "Количество вакантных мест на проекте" }, StringSplitOptions.None)[1].Split(new string[] { "Количество кредитов" }, StringSplitOptions.None)[0];
                            element.Points = title[0].InnerText.Split(new string[] { "Количество кредитов" }, StringSplitOptions.None)[1].Split(new string[] { "Интенсивность проектной деятельности" }, StringSplitOptions.None)[0];
                            element.Intensivity = title[0].InnerText.Split(new string[] { "Интенсивность проектной деятельности" }, StringSplitOptions.None)[1].Split(new string[] { "Способ постановки задач" }, StringSplitOptions.None)[0];
                            element.TaskType = title[0].InnerText.Split(new string[] { "Способ постановки задач" }, StringSplitOptions.None)[1].Split(new string[] { "Необходимо" }, StringSplitOptions.None)[0];


                            
                        }
                        catch
                        {
                        }
                App.DatabaseCurrentFairProject.SaveProjectAsync(element);
            }
            catch
            {
                //Console.WriteLine(pfHSEData.ToString());
            }
            //return pfHSEData;


            //int i = 0;
            //foreach (var proj in pfHSEData)
            //{
              //  FairProjectTable fairProject = new FairProjectTable();
                //fairProject.Id = i;
                //fairProject.Name = proj.Name;
                //fairProject.JoinUntil = proj.Deadline;
                //string mops = "";
                //foreach (var mop in proj.MOPs)
                //{
                //    mops += mop + ";";
                //}
                //fairProject.MOPs = mops;
               // string ops = "";
                //foreach (var op in proj.OPs)
               // {
               //     ops += op + ";";
               // }
               // fairProject.OPs = ops;
                //fairProject.Period = proj.Period;
                //fairProject.CreditAmount = proj.Points;
               // fairProject.Curator = proj.Curator;
               // fairProject.URL = proj.URL;
               // i += 1;
              //  App.DatabaseFairProjects.SaveProjectAsync(fairProject);
            //}
        }
    }

    public class pfHSEDataDetailed
    {
        public string Name;
        public string ID;
        public string OPs;
        public string MOPs;
        public string Description;
        public string Deadline;
        public string Points;
        public string Curator;
        public string PartCurator;
        public string Initiator;
        public string Campus;
        public string ProjectType;
        public string WorkType;
        public string Territory;
        public string Course;
        public string Dates;
        public string VacancyNum;
        public string Intensivity;
        public string TaskType;
    }

}
