using FourmApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.Repositary
{
    public interface IQuestionsRepositary
    {
        void InsertQuestion(Questions q);
        void UpdateQuestionDetails(Questions q);
        void UpdateQuestionVoteCount(int qid, int value);
        void UpdateQuestionAnswerCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid);
        void DeleteQuestion(int q);
        List<Questions> GetQuestions();
        Questions GetQuestionByQuestionID(int qid); 
    }
    public class QuestionsRepositary : IQuestionsRepositary
    {
        private FourmAppDBContext _dbContext;    
        public QuestionsRepositary()
        {
            _dbContext = new FourmAppDBContext();
        }
        public void DeleteQuestion(int q)
        {
            _dbContext.Questions.Remove(_dbContext.Questions.Find(q));
            _dbContext.SaveChanges();   
        }

        public Questions GetQuestionByQuestionID(int qid)
        {
          Questions qus =  _dbContext.Questions.Find(qid);
            return qus; 
        }

        public List<Questions> GetQuestions()
        {
          return  _dbContext.Questions.ToList();
        }

        public void InsertQuestion(Questions q)
        {
           _dbContext.Questions.Add(q);
            _dbContext.SaveChanges();
        }

        public void UpdateQuestionDetails(Questions q)
        {
           Questions qus = _dbContext.Questions.Where(x => x.QuestionID == q.QuestionID).FirstOrDefault();
            if(qus != null)
            {
                qus.QuestionName = q.QuestionName;
                qus.CategoryID = q.CategoryID;
                qus.QuestionDateAndTime = q.QuestionDateAndTime;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateQuestionAnswerCount(int qid, int value)
        {
          Questions qus =  _dbContext.Questions.Where(x => x.QuestionID == qid).FirstOrDefault();
            if(qus!= null)
            {
                qus.AnswersCount += value;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int qid)
        {
          Questions qus =  _dbContext.Questions.Where(x => x.QuestionID == qid).FirstOrDefault();
            if(qus != null)
            {
                qus.ViewsCount += 1;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateQuestionVoteCount(int qid, int value)
        {
            Questions qus = _dbContext.Questions.Where(x => x.QuestionID == qid).FirstOrDefault();
            if (qus != null)
            {
                qus.VotesCount += value;
                _dbContext.SaveChanges();
            }
        }
    }
}
