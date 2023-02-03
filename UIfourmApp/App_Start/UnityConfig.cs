using FourmApplication.ServiceLayer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using System.Web.Http;

namespace UIfourmApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUsersservice, UsersService>();
            container.RegisterType<IQuestionService , QuestionService>();
            container.RegisterType<IAnswerService, AnswerService>();
            container.RegisterType<ICategoryService, CategoryService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}