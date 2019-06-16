using System;
using SIS.MvcFramework.Attributes.Validation;

namespace SULS.Models
{
    public class Submission
    {
        public string Id { get; set; }

        [RequiredSis]
        public string Code { get; set; }

        [RequiredSis]
        public int AchievedResult { get; set; }

        [RequiredSis]
        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string ProblemId { get; set; }

        public Problem Problem { get; set; }
    }
}