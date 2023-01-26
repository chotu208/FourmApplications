using FourmApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.Repositary
{
    public interface IAnswersRepositary
    {
        void InsertAnswer(Answers a);
        void UpdateAnswer(Answers a);   
        void DeleteAnswer(Answers a);
        void UpdateAnswersVotesCount(int aid, int uid, int value);
        List<Answers> GetAnswerByQuestionID(int qid);
        List<Answers> GetAnswerByAnswerID(int aid);
    }
    public class AnswersRepositary : IAnswersRepositary
    {
        private FourmAppDBContext _dbContext;
        private QuestionsRepositary _qr;
        public AnswersRepositary()
        {
            _dbContext = new FourmAppDBContext();
            _qr = new QuestionsRepositary();
        }
        public void DeleteAnswer(Answers a)
        {
            _dbContext.Answers.Remove(_dbContext.Answers.Find(a));
            _dbContext.SaveChanges();
        }

        public List<Answers> GetAnswerByAnswerID(int aid)
        {
            return  _dbContext.Answers.Where(x => x.AnswerID == aid).ToList();
        }

        public List<Answers> GetAnswerByQuestionID(int qid)
        {
          return   _dbContext.Answers.Where(x => x.QuestionID == qid).ToList();
        }

        public void InsertAnswer(Answers a)
        {
            _dbContext.Answers.Add(a);
            _dbContext.SaveChanges();
            _qr.UpdateQuestionAnswerCount(a.QuestionID, 1);
            
        }

        public void UpdateAnswer(Answers a)
        {
           Answers ans = _dbContext.Answers.Where(x => x.AnswerID == a.AnswerID).FirstOrDefault();
            if(ans != null)
            {
                ans.AnswerText = a.AnswerText;
                ans.AnswerDateAndTime = a.AnswerDateAndTime;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateAnswersVotesCount(int aid, int uid, int value)
        {
          Answers ans =  _dbContext.Answers.Where(x => x.AnswerID == aid && x.UserID == uid).FirstOrDefault();
            if(ans != null)
            {
                ans.VotesCount += value;
                _dbContext.SaveChanges();
                _qr.UpdateQuestionVoteCount(ans.QuestionID, value);
            }
        }
    }
}
