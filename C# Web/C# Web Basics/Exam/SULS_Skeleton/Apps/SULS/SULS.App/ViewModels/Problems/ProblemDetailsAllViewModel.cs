using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsAllViewModel
    {
        public ProblemDetailsAllViewModel()
        {
            this.Problems = new List<ProblemDetailsViewModel>();
        }

        public string Name { get; set; }

        public List<ProblemDetailsViewModel> Problems { get; set; }
    }
}