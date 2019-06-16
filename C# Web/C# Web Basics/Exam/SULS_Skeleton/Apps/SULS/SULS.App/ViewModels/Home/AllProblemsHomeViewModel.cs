using System.Collections.Generic;
using SULS.App.ViewModels.Problems;

namespace SULS.App.ViewModels.Home
{
    public class AllProblemsHomeViewModel
    {
        public AllProblemsHomeViewModel()
        {
            this.Problems = new List<ProblemHomeViewModel>();
        }

        public List<ProblemHomeViewModel> Problems { get; set; }
    }
}