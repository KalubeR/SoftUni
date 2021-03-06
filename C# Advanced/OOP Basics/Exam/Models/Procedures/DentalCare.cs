﻿using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        public DentalCare()
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

            animal.Happiness += 12;
            animal.Energy += 10;

        }
    }
}
