namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            var airplaneInstance = (IAirplane)Activator.CreateInstance(airplaneType);
            return airplaneInstance;

		}
	}
}