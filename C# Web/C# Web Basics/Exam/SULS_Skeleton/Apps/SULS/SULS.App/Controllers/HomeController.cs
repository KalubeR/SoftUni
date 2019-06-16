using System.Collections.Generic;
using System.Linq;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.App.ViewModels.Problems;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            AllProblemsHomeViewModel orderHomeViewModel = new AllProblemsHomeViewModel();

            if (this.IsLoggedIn())
            {
                var problems = this.problemService.GetAllProblems().ToList();
                    var problemViewModels = new List<ProblemHomeViewModel>();

                foreach (var problem in problems)
                {
                    ProblemHomeViewModel problemHomeViewModel = new ProblemHomeViewModel
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = this.problemService.GetCountOfSubmissionByProblemName(problem.Name)
                    };
                    problemViewModels.Add(problemHomeViewModel);
                }

                foreach (var problem in problemViewModels)
                {
                    orderHomeViewModel.Problems.Add(problem);
                }
            }

            return this.View(orderHomeViewModel);
        }
    }
}