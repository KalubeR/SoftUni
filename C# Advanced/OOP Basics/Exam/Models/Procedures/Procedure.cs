using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory
        {
            get { return procedureHistory; }
            set { procedureHistory = value; }
        }
        
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
        
        
    }
}
