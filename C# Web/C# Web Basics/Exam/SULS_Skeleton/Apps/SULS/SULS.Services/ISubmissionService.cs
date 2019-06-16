using System.Collections;
using System.Collections.Generic;
using SULS.Models;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        void CreateSubmission(string problemId, string code, string userId, int problemTotalPoints);

        IEnumerable<Submission> GetAllSubmissionByProblemId(string problemId);

        void DeleteSubmissionById(string id);
    }
}