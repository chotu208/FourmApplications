using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplications.ViewModel.AnswerViewModel
{
    public  class NewAnswerViewModel
    {
        public string AnswerText { get; set; }  
        public DateTime AnswerDateAndTime { get; set; } 
        public int UserID { get; set; } 
        public int QuestionID { get; set; } 
        public int votesCount { get; set; } 
    }
}
