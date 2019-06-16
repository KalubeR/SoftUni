using System.Collections.Generic;
using System.Linq;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext context;

        public ProblemService(SULSContext context)
        {
            this.context = context;
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            var problems = this.context.Problems.ToList();
            return problems;
        }

        public int GetCountOfSubmissionByProblemName(string name)
        {
            var count = this.context.Submissions.Count(x => x.Problem.Name == name);
            return count;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.context.Problems.Add(problem);
            this.context.SaveChanges();
        }

        public Problem GetProblemById(string id)
        {
            var problem = this.context.Problems.SingleOrDefault(p => p.Id == id);
            return problem;
        }
    }
}