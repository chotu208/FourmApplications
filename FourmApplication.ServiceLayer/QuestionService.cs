using AutoMapper;
using FourmApplication.DataModel;
using FourmApplication.Repositary;
using FourmApplications.ViewModel.QuestionsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.ServiceLayer
{
        public interface IQuestionService
        {
            void InsertQuestion(NewQuestionViewModel q);
            void UpdateQuestionDetails(EditQuestionViewModel q);
            void UpdateQuestionVoteCount(int qid, int value);
            void UpdateQuestionAnswerCount(int qid, int value);
            void UpdateQuestionViewsCount(int qid);
            void DeleteQuestion(int q);
            List<QuestionViewModel> GetQuestions();
            QuestionViewModel GetQuestionByQuestionID(int qid);
        }
        public class QuestionService : IQuestionService
    {
            QuestionsRepositary _qr;
            public QuestionService()
            {
                _qr = new QuestionsRepositary();
            }
            public void DeleteQuestion(int q)
            {
                _qr.DeleteQuestion(q);
            }

            public QuestionViewModel GetQuestionByQuestionID(int qid)
            {
                Questions q = _qr.GetQuestionByQuestionID(qid);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Questions, QuestionViewModel>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                QuestionViewModel qvm = mapper.Map<Questions, QuestionViewModel>(q);
                return qvm;

            }

            public List<QuestionViewModel> GetQuestions()
            {
                List<Questions> list = _qr.GetQuestions();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Questions, QuestionViewModel>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                List<QuestionViewModel> qvm = mapper.Map<List<Questions>, List<QuestionViewModel>>(list);
                return qvm;

            }

            public void InsertQuestion(NewQuestionViewModel q)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NewQuestionViewModel, Questions>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                Questions qus = mapper.Map<NewQuestionViewModel, Questions>(q);
                _qr.InsertQuestion(qus);
            }

            public void UpdateQuestionAnswerCount(int qid, int value)
            {
                _qr.UpdateQuestionVoteCount(qid, value);
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<QuestionsViewModel, Questions>();
                //    cfg.IgnoreUnmapped();
                //});
                //var mapper = config.CreateMapper();
                //mapper.Map<QuestionsViewModel, Questions>();

            }

            public void UpdateQuestionDetails(EditQuestionViewModel q)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<EditQuestionViewModel, Questions>();
                    cfg.IgnoreUnmapped();
                });
                var mapper = config.CreateMapper();
                Questions qus = mapper.Map<EditQuestionViewModel, Questions>(q);
                _qr.UpdateQuestionDetails(qus);
            }

            public void UpdateQuestionViewsCount(int qid)
            {

                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<EditQuestionsViewModel, Questions>();
                //    cfg.IgnoreUnmapped();
                //});
                //var mapper = config.CreateMapper();
                //Questions qus = mapper.Map<EditQuestionsViewModel, Questions>();
                _qr.UpdateQuestionViewsCount(qid);
            }

            public void UpdateQuestionVoteCount(int qid, int value)
            {
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<EditQuestionsViewModel, Questions>();
                //    cfg.IgnoreUnmapped();
                //});
                //var mapper = config.CreateMapper();
                //Questions qus = mapper.Map<EditQuestionsViewModel, Questions>();
                _qr.UpdateQuestionVoteCount(qid, value);
            }
        }
    
}
