using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageComparment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageComparment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageComparment.AsReadOnly();

        public bool IsOverbooked => passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();


        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var baggage = this.baggageComparment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageComparment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return baggage;

        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageComparment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            this.baggageComparment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }
    }
}
