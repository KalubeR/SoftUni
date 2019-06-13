using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TheTankGame.Entities.Vehicles.Contracts;
using System.Reflection;
using TheTankGame.Entities.Vehicles.Factories.Contracts;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Miscellaneous;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == vehicleType);
            var instance = (IVehicle)Activator.CreateInstance(type, new object[] { model, weight, price, attack, defense, hitPoints, new VehicleAssembler()});

            return instance;
        }
    }
}
