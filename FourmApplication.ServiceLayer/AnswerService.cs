using AutoMapper;
using FourmApplication.DataModel;
using FourmApplication.Repositary;
using FourmApplications.ViewModel.AnswerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.ServiceLayer
{
        public interface IAnswerService
        {
            void InsertAnswer(AnswersViewModel a);
            void UpdateAnswer(EditAnswerViewModel a);
            void DeleteAnswer(int a);
            void UpdateAnswerVotesCount(int aid, int uid, int value);
            List<AnswersViewModel> GetAnswerByQuestionID(int qid);
            List<AnswersViewModel> GetAnswerByAnswerID(int aid);
        }
        public class AnswerService : IAnswerService
        {
            AnswersRepositary _ar;
            private AnswerService()
            {
                _ar = new AnswersRepositary();
            }
            public void DeleteAnswer(int a)
            {
                _ar.DeleteAnswer(a);
            }

            public List<AnswersViewModel> GetAnswerByAnswerID(int aid)
            {
                List<Answers> a = new List<Answers>(aid);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AnswersViewModel, Answers>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                List<AnswersViewModel> v = mapper.Map<List<Answers>, List<AnswersViewModel>>(a);
                _ar.GetAnswerByAnswerID(aid);
                return v;
            }

            public List<AnswersViewModel> GetAnswerByQuestionID(int qid)
            {
                List<Answers> avm = new List<Answers>(qid);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AnswersViewModel, Answers>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                List<AnswersViewModel> v = mapper.Map<List<Answers>, List<AnswersViewModel>>(avm);
                _ar.GetAnswerByAnswerID(qid);
                return v;

            }

            public void InsertAnswer(AnswersViewModel a)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AnswersViewModel, Answers>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                Answers ans = mapper.Map<AnswersViewModel, Answers>(a);
                _ar.InsertAnswer(ans);

            }

            public void UpdateAnswer(EditAnswerViewModel a)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EditAnswerViewModel, Answers>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                Answers ans = mapper.Map<EditAnswerViewModel, Answers>(a);
                _ar.UpdateAnswer(ans);
            }

            public void UpdateAnswerVotesCount(int aid, int uid, int value)
            {
                //Answers a =   _ar.UpdateAnswerVotesCount(aid, uid, value);
                //  var config = new MapperConfiguration(cfg =>
                //  {
                //      cfg.CreateMap<EditAnswersViewModel, Answers>();
                //      cfg.IgnoreUnmapped();
                //  });
                //  var mapper = config.CreateMapper();
                //  Answers ans = mapper.Map<AnswersViewModel, Answers>();
                _ar.UpdateAnswersVotesCount(aid, uid, value);
            }
        }
    
}
