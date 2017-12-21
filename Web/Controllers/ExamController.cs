using BusinessLayer;
using Entity;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

using Web.Models;

namespace Web.Controllers
{

    public class ExamController : Controller
    {
        // GET: Exam

        ExamBusinees examBll = new ExamBusinees();
      
        public ActionResult Index() {
            if (Session["UserID"] == null)
            {
             return    RedirectToAction("Index","Login");

            }
            List<Exam> list = examBll.GetList();
            return View(list);
     
        }

        [HttpPost]
        public ActionResult GetExamCreateView(string title)
        {
            
            List<RssModel> list = GetListRss();
            RssModel rss = list.Where(x => x.Title == title).FirstOrDefault();
            ViewBag.Rss = rss;
            ViewBag.RssContent = GetRssContent(rss);
            return PartialView("_PartialExam",new Exam());


        }

    
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            ViewBag.RSSFeed = GetListRss();
            
            return View();
        }
        [ValidateInput(false)] 
        [HttpPost]
        public ActionResult Create(Exam exam)

        {
            
            if (exam !=null)
            {
                examBll.SaveExam(exam);

                return RedirectToAction("Index","Exam");
            }

            return null;
        }
        public List<RssModel> GetListRss()
        {
            List<RssModel> rssList = new List<RssModel>();

            string url = "https://www.wired.com/feed/rss";

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");
            var list = itemNodes.Cast<XmlNode>().Take(5);
            foreach (XmlNode itemNode in list)
            {
                RssModel rss = new RssModel();
                XmlNode titleNode = itemNode.SelectSingleNode("title");
                XmlNode descriptionNode = itemNode.SelectSingleNode("description");
                XmlNode urlNode = itemNode.SelectSingleNode("link");
                rss.Title = titleNode.InnerText;
                rss.Description = descriptionNode.InnerText;
                rss.URL=urlNode.InnerText;
                rssList.Add(rss);
            }
            return rssList;
        }
        public RssModel GetRssContent(RssModel rssModel)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(rssModel.URL);
            
            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//p").ToArray();
            for (var i = 0;i<nodes.Count<HtmlNode>();i++)
            {
                HtmlNode htmlNote = nodes[i];

                if (i<nodes.Count<HtmlNode>()-5)
                {
                    rssModel.Description += "<br>" + htmlNote.InnerHtml;

                }
                
            }

            return rssModel;
            
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
          bool result= examBll.Delete(ID);
            if (result)
            {
                return RedirectToAction("Index","Exam");
            }
            return null;

        }

        [HttpGet]
        
        public ActionResult StartExam(int ID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            Exam exam=  examBll.Get(ID);
            foreach (var item in exam.Questions)
            {
                foreach (var answer in item.Answers)
                {
                    answer.IsRight = null;
                }

            }


            ViewBag.RssTitle =exam.Article.Title ;
            ViewBag.RssContent = exam.Article.Content;
            return View("StartExam",exam);
        }
        [HttpPost]

        public ActionResult CheckAnswer(int id , bool IsRight)
        {
           Answer answer= examBll.GetAnswer(id);
            if (answer.IsRight==IsRight  )
            {
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            if (answer.IsRight != IsRight )
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }


            return Json("null", JsonRequestBehavior.AllowGet);
        }
    }
   
}