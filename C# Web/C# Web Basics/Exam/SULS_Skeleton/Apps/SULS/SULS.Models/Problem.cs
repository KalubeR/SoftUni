using SIS.MvcFramework.Attributes.Validation;

namespace SULS.Models
{
    public class Problem
    {
        public string Id { get; set; }

        [RequiredSis]
        public string Name { get; set; }

        [RequiredSis]
        public int Points { get; set; }
    }
}