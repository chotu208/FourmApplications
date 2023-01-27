using FourmApplications.ViewModel.AnswerViewModel;
using FourmApplications.ViewModel.CategoriesViewModel;
using FourmApplications.ViewModel.UsersViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplications.ViewModel.QuestionsViewModel
{
    public class QuestionViewModel
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }
        public UserViewModel user { get; set; }
        public CategoryViewModel Categories { get; set; }
        public virtual List<AnswersViewModel> Answers { get; set; }
    }
}
