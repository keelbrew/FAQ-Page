using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project6Wight.Models;

namespace Project6Wight.Controllers
{
    public class HomeController : Controller
    {
        //sets the property for the faqs context
        private FaqsContext context { get; set; }
        /// <summary>
        /// creats the faqs context into a ctx
        /// </summary>
        /// <param name="ctx"></param>
        public HomeController(FaqsContext ctx)
        {
            context = ctx;
        }
        //routes the topic by category than by topic
        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]
        //organizes the topics categories and topics and populates them according to what is selected
        public IActionResult Index(string topic, string category)
        {
            //puts the viewbg into topics and orders by alabethical
            ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
            //puts the viewbag into categors and orders alabethical
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            //selects the top
            ViewBag.SelectedTopic = topic;
            //organxies them into a query
            IQueryable<FAQ> faqs = context.FAQs.Include(f => f.Topic).Include(f => f.Category).OrderBy(f => f.Question);
            //if topic is elected it will display
            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.TopicId == topic);
            }
            //category is selcted will display
            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.CategoryId == category);
            }
            return View(faqs.ToList());
        }
        
    }
}
