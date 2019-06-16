using System.Collections;
using System.Collections.Generic;
using SULS.Models;

namespace SULS.Services
{
    public interface IProblemService
    {
        IEnumerable<Problem> GetAllProblems();

        int GetCountOfSubmissionByProblemName(string name);

        void CreateProblem(string name, int points);

        Problem GetProblemById(string Id);
    }
}