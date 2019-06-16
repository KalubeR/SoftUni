using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.BindingModels.Problems
{
    public class ProblemCreateInputModel
    {
        private const string NameErrorMessage = "Name must be between 5 and 20 symbols!";
        private const string PointsErrorMessage = "Points must be between 50 and 300!";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, PointsErrorMessage)]
        public int Points { get; set; }
    }
}