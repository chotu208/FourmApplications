using FourmApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.Repositary
{
    public interface IVotesRepositary
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepositary : IVotesRepositary
    {
        private FourmAppDBContext _dbContext;
        public VotesRepositary()
        {
            _dbContext = new FourmAppDBContext();   
        }
        public void UpdateVote(int aid, int uid, int value)
        {
            int UpdateValue;
            if(value > 0)
            {
                UpdateValue = 1;
            }
            else if(value < 0)
            {
                UpdateValue = -1;
            }
            else
            {
                UpdateValue = 0;
            }
           var vote = _dbContext.Votes.Where(x => x.AnswerID == aid && x.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValues = UpdateValue;
            }
            else
            {
                Votes votes = new Votes()
                {
                       UserID = uid,
                       AnswerID = aid,
                       VoteValues = value
                };
                _dbContext.Votes.Add(votes);    
                _dbContext.SaveChanges();   
            }
        }
    }

}
