using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.DataModel
{
    public class Answers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }   
        public string AnswerText { get; set; }  
        public DateTime AnswerDateAndTime { get; set; } 
        public int UserID { get; set; } 
        public int QuestionID { get; set; } 
        public int VotesCount { get; set; }
        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
        [ForeignKey("QuestionID")]
        public virtual Questions Questions { get; set; }    
        public virtual List<Votes> Votes { get; set; }
    }
}
