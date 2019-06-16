using System;
using System.Collections.Generic;
using System.Linq;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext context;

        public SubmissionService(SULSContext context)
        {
            this.context = context;
        }

        public void CreateSubmission(string problemId, string code, string userId, int problemTotalPoints)
        {
            var random = new Random();

            var submission = new Submission
            {
                Code = code,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                ProblemId = problemId,
                AchievedResult = random.Next(0, problemTotalPoints)
            };

            this.context.Submissions.Add(submission);
            this.context.SaveChanges();
        }

        public IEnumerable<Submission> GetAllSubmissionByProblemId(string problemId)
        {
            var submissions = this.context.Submissions
                .Where(x => x.ProblemId == problemId)
                .ToList();

            return submissions;
        }

        public void DeleteSubmissionById(string id)
        {
            var submission = this.context.Submissions.SingleOrDefault(x => x.Id == id);
            if (submission == null)
            {
                return;
            }

            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();
        }
    }
}