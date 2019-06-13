namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Test1()
        {
            IVehicle revenger = new Revenger("BMW", 100, 100 ,100 , 100, 100, new VehicleAssembler());
            revenger.AddArsenalPart(new ArsenalPart("M3", 100, 100, 1));
            var expectedResult = "Revenger - BMW\r\nTotal Weight: 200.000\r\nTotal Price: 200.000\r\nAttack: 101\r\nDefense: 100\r\nHitPoints: 100\r\nParts: M3";
            var actualResult = revenger.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}