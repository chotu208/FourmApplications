using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.DataModel
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }    
        public DateTime QuestionDateAndTime { get; set; }   
        public int UserID { get; set; } 
        public int CategoryID { get; set; } 
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }   
        public int ViewsCount { get; set; }
        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }  
    }
}
