using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplications.ViewModel.QuestionsViewModel
{
    public  class EditQuestionViewModel
    {
        public int QuestionId { get; set; } 
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int CategoryID { get; set; }  
    }
}
