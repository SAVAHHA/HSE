using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace HSEapp.Data
{
    public class FairParserSavahha: INotifyPropertyChanged
    {
        private string url;
        private string name;
        private List<string> ops;
        private List<string> mops;
        private string deadline;
        private string period;
        private string points;
        private string curator;

        public string URL
        {
            get { return url; }
            private set
            {
                url = value;
                OnPropertyChanged("URL");
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<string> OPs
        {
            get { return ops; }
            private set
            {
                ops = value;
                OnPropertyChanged("OPs");
            }
        }
        public List<string> MOPs
        {
            get { return mops; }
            private set
            {
                mops = value;
                OnPropertyChanged("MOPs");
            }
        }
        public string Deadline
        {
            get { return deadline; }
            private set
            {
                deadline = value;
                OnPropertyChanged("Deadline");
            }
        }
        public string Period
        {
            get { return period; }
            private set
            {
                period = value;
                OnPropertyChanged("Period");
            }
        }
        public string Points
        {
            get { return points; }
            private set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }
        public string Curator
        {
            get { return curator; }
            private set
            {
                curator = value;
                OnPropertyChanged("Curator");
            }
        }

        public ICommand LoadDataCommand { protected set; get; }

        public FairParserSavahha()
        {
            this.LoadDataCommand = new Command(LoadData);
        }

        //private async void LoadData()
        //{
        //    string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(url);
        //        var response = await client.GetAsync(client.BaseAddress);
        //        response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

        //        // десериализация ответа в формате json
        //        var content = await response.Content.ReadAsStringAsync();
        //        JObject o = JObject.Parse(content);

        //        var str = o.SelectToken(@"$.query.results.rate");
        //        var rateInfo = JsonConvert.DeserializeObject<RateInfo>(str.ToString());

        //        this.Rate = rateInfo.Rate;
        //        this.Ask = rateInfo.Ask;
        //        this.Bid = rateInfo.Bid;
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        private async void LoadData()
        {
            try
            {
                int n = 1;
                while (true)
                {
                    if (n == 1)
                    {
                        var url = "https://pf.hse.ru/index.html";
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(url);
                        var response = await client.GetAsync(client.BaseAddress);
                        response.EnsureSuccessStatusCode();
                        var title = client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url)).Result.ToString();
                        //title.RemoveAt(0);

                        //Ниже перекопированный код из Parser.cs
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
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(url);
                        var response = await client.GetAsync(client.BaseAddress);
                        response.EnsureSuccessStatusCode();
                        //var web = new HtmlWeb();
                        //var doc = web.Load(url);
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
               
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
