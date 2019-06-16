using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Submissions;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetProblemById(id);
            var viewModel = new SubmissionsCreateViewModel
            {
                Name = problem.Name,
                ProblemId = id
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(SubmissionCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Submissions/Create");
            }

            var problem = this.problemService.GetProblemById(model.ProblemId);
            this.submissionService.CreateSubmission(model.ProblemId, model.Code, this.User.Id, problem.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionService.DeleteSubmissionById(id);
            return this.Redirect("/");
        }
    }
}