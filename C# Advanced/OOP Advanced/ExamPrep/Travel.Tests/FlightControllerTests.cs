// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void CheckIfTripIsCompleted()
        {
            var airport = new Airport();

            var flightController = new FlightController(airport);

            Passenger passenger = new Passenger("Gosho");
            Bag bag = new Bag(passenger, new Item[] { new Colombian() });
            passenger.Bags.Add(bag);

            var airplane = new LightAirplane();
            airplane.AddPassenger(passenger);
            Trip trip = new Trip("Tuk", "tam", airplane);
            airport.AddTrip(trip);
            trip.Complete();

            var expectedResult = flightController.TakeOff();
            var actualResult = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TestIfAirplaneIsOverbooked()
        {
            var airport = new Airport();

            var airplane = new LightAirplane();
            var flightController = new FlightController(airport);
            List<Passenger> passengers = new List<Passenger>();
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));

            foreach (var item in passengers)
            {
                airplane.AddPassenger(item);
            }
            Trip trip = new Trip("Tuk", "tam", airplane);
            airport.AddTrip(trip);

            var actualResult = flightController.TakeOff();
            var expectedResult = "Tuktam3:\r\nOverbooked! Ejected Gsoho, Gsoho, Gsoho, Gsoho, Gsoho\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to tam.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(trip.IsCompleted, true);
        }

        [Test]
        public void Test3()
        {
            Airport airport = new Airport();
            Airplane airplane = new LightAirplane();
            Passenger passenger = new Passenger("Az");
            List<IItem> items = new List<IItem>();
            for (int i = 0; i < 30; i++)
            {
                Bag bag = new Bag(passenger, items);
                passenger.Bags.Add(bag);
            }

            Trip trip = new Trip("Holandiq", "Rusiq", airplane);
            trip.Airplane.AddPassenger(passenger);
            airport.AddTrip(trip);
            FlightController flightController = new FlightController(airport);
            Assert
                .Throws<InvalidOperationException>(() => flightController.TakeOff());
        }

        [Test]
        public void TestIfLoadCarryOnBaggage()
        {
            var airport = new Airport();

            var flightController = new FlightController(airport);

            Passenger passenger = new Passenger("Gosho");
            Item item = new CellPhone();
            Bag bag = new Bag(passenger, new Item[] { item });
            passenger.Bags.Add(bag);

            var airplane = new LightAirplane();
            List<Passenger> passengers = new List<Passenger>();
            passengers.Add(passenger);
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));
            passengers.Add(new Passenger("Gsoho"));

            foreach (var arg in passengers)
            {
                airplane.AddPassenger(arg);
            }
            Trip trip = new Trip("Tuk", "tam", airplane);
            airport.AddTrip(trip);


            var actualResult = flightController.TakeOff();
            var expectedResult = "Tuktam4:\r\nOverbooked! Ejected Gsoho, Gosho, Gsoho, Gsoho, Gsoho\r\nConfiscated 1 bags ($700)\r\nSuccessfully transported 5 passengers from Tuk to tam.\r\nConfiscated bags: 1 (1 items) => $700";
            Assert.AreEqual(expectedResult, actualResult);

        }


    }
}
