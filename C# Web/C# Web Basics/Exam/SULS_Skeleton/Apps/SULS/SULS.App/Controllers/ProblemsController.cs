using System.Collections.Generic;
using System.Linq;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Problems;
using SULS.App.ViewModels.Home;
using SULS.App.ViewModels.Problems;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public ProblemsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemService.CreateProblem(model.Name, model.Points);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var submissions = this.submissionService.GetAllSubmissionByProblemId(id)
                .ToList();

            var problem = this.problemService.GetProblemById(id);

            ProblemDetailsAllViewModel problemDetailsAllViewModel = new ProblemDetailsAllViewModel();
            problemDetailsAllViewModel.Name = problem.Name;


            var problemDetails = new List<ProblemDetailsViewModel>();
            foreach (var submission in submissions)
            {
                string date = submission.CreatedOn.ToString("d");
                ProblemDetailsViewModel problemDetailsViewModel = new ProblemDetailsViewModel
                {
                    Username = this.User.Username,
                    AchievedResult = submission.AchievedResult,
                    CreatedOn = date,
                    MaxPoints = problem.Points,
                    SubmissionId = submission.Id
                };
                problemDetails.Add(problemDetailsViewModel);
            }

            foreach (var problemDetail in problemDetails)
            {
                problemDetailsAllViewModel.Problems.Add(problemDetail);
            }

            return this.View(problemDetailsAllViewModel);
        }
    }
}