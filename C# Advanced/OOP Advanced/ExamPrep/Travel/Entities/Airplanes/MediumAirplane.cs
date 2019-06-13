using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int LightAirplaneSeats = 10;
        private const int LightAirplaneBaggageCompartments = 14;

        public MediumAirplane() 
            : base(LightAirplaneSeats, LightAirplaneBaggageCompartments)
        {
        }
    }
}
