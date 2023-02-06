using FourmApplication.ServiceLayer;
using FourmApplications.ViewModel.QuestionsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIfourmApp.Controllers
{
    public class HomeController : Controller
    {
        private IQuestionService _qr;
        public HomeController(IQuestionService qr)
        {
           this._qr = qr;
        }

        public ActionResult Index()
        {
            //var qus = this._qr.GetQuestions().ToList();
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult Questions()
        {
            var qus = this._qr.GetQuestions().ToList();
            return View(qus);
            
        }
        public ActionResult Login()
        {
            return View();
        }
      


    }
}