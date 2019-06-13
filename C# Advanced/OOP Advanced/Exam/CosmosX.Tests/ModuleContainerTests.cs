
using System;

namespace CosmosX.Tests
{
    //using CosmosX.Entities.Containers;
    //using CosmosX.Entities.Modules.Absorbing;
    //using CosmosX.Entities.Modules.Energy;
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void Test1()
        {
            var moduleContainer = new ModuleContainer(3);
            var absorbingModule = new CooldownSystem(2, 0);
            var secondabsorbingModule = new CooldownSystem(5, 100);
            var energyModule = new CryogenRod(3, 200);
            var secondEnergyModule = new CryogenRod(4, 100);
            moduleContainer.AddAbsorbingModule(absorbingModule);
            moduleContainer.AddAbsorbingModule(secondabsorbingModule);
            moduleContainer.AddEnergyModule(energyModule);

            moduleContainer.AddEnergyModule(secondEnergyModule);

            var actualTotalHeatAbsorbingResult = moduleContainer.TotalHeatAbsorbing;
            var actualTotalEnergyOutput = moduleContainer.TotalEnergyOutput;

            var expectedTotalHeatAbsorbingResult = 100;
            var expectedTotalEnergyOutput = 300;


            var actualModulesByInputCount = moduleContainer.ModulesByInput.Count;
            var expectedModulesByInputCount = 3;

            Assert.AreEqual(expectedTotalHeatAbsorbingResult, actualTotalHeatAbsorbingResult);
            Assert.AreEqual(expectedTotalEnergyOutput, actualTotalEnergyOutput);
            Assert.AreEqual(expectedModulesByInputCount, actualModulesByInputCount);

            //Assert.AreEqual(actualModulesByInputCount, expectedModulesByInputCount);
            //Assert.Throws<ArgumentException>(() => moduleContainer.AddAbsorbingModule(null));
        }
    }
}