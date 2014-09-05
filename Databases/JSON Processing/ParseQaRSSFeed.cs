namespace ParseQaRSSFeed
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web.UI;
    using System.Xml;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class ParseQaRssFeed
    {
        private const string RssFeedFilePath = "../../qa.xml";

        private const string HtmlFilePath = "../../qa.html";

        private const string Feedurl = "http://forums.academy.telerik.com/feed/qa.rss";

        private static void Main()
        {
            DownloadRssFeed();
            var jsonText = ConvertXmlToJson();
            var listOfQuestions = ConvertJsonToPoco(jsonText);
            RenderHtml(listOfQuestions);
            PrintQuestionTitles(jsonText);
        }

        private static void RenderHtml(IEnumerable<Question> listOfQuestions)
        {
            using (var streamWriter = new StreamWriter(HtmlFilePath))
            {
                using (var htmlWriter = new HtmlTextWriter(streamWriter))
                {
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Html);
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Head);
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Title);
                    htmlWriter.Write("Telerik Q&A Forum");
                    htmlWriter.RenderEndTag();
                    htmlWriter.RenderEndTag();
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Body);
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Ul);

                    foreach (var question in listOfQuestions)
                    {
                        RenderQuestion(htmlWriter, question);
                    }

                    htmlWriter.RenderEndTag();
                    htmlWriter.RenderEndTag();
                    htmlWriter.RenderEndTag();
                }
            }
        }

        private static void RenderQuestion(HtmlTextWriter htmlWriter, Question question)
        {
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Li);
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Href, question.Link);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.A);
            htmlWriter.Write(question.Title);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Span);
            htmlWriter.Write(" [Category: {0}]", question.Category);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
            htmlWriter.Write(question.Description);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
        }

        private static IEnumerable<Question> ConvertJsonToPoco(string jsonText)
        {
            var jobject = JObject.Parse(jsonText);
            var questionTittles = jobject["rss"]["channel"]["item"].ToString();
            return JsonConvert.DeserializeObject<List<Question>>(questionTittles);
        }

        private static void PrintQuestionTitles(string jsonText)
        {
            var jobject = JObject.Parse(jsonText);
            var questionTittles = jobject["rss"]["channel"]["item"].Select(item => item["title"]);

            foreach (var title in questionTittles)
            {
                Console.WriteLine(title);
            }
        }

        private static string ConvertXmlToJson()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(RssFeedFilePath);
            var jsonText = JsonConvert.SerializeXmlNode(xmlDocument);
            return jsonText;
        }

        private static void DownloadRssFeed()
        {
            var rssFeed = new WebClient();
            rssFeed.DownloadFile(Feedurl, RssFeedFilePath);
        }
    }
}