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
            List<QuestionViewModel> questions = this._qr.GetQuestions();  
            return View(questions); 
        }
    }
}