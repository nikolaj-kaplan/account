using Raven.Client.Document;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class HomeController : Controller
    {
        private static DocumentStore _documentStore;
        public ActionResult Index()
        {
            if (_documentStore == null)
            {
                _documentStore = new EmbeddableDocumentStore { ConnectionStringName = "Local" };
                _documentStore.Initialize();
            }

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";


            Random r = new Random();

            using (var session = _documentStore.OpenSession())
            {
                session.Store(new TestClass() { A = r.Next(100), B = r.Next(100) });
                session.SaveChanges();
            }


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.<br />";
            using (var session = _documentStore.OpenSession())
            {
                var objects = session.Query<TestClass>();
                foreach (TestClass c in objects)
                {
                    ViewBag.Message += c.ToString() + "<br />";
                }
            }

            return View();
        }
    }
}
