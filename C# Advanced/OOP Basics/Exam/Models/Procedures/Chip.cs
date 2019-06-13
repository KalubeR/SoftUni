using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
            : base()
        {

        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            
            //animal.Happiness -= 5;

            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            animal.Happiness -= 5;

            animal.IsChipped = true;
        }
    }
}
