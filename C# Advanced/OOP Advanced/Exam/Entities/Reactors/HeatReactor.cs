using System.Security.Cryptography;
using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

       
        public override long TotalEnergyOutput
        {
            get
            {
                long totalEnergyFromModules = base.TotalEnergyOutput;

                if (this.TotalHeatAbsorbing < base.TotalEnergyOutput)
                {
                    totalEnergyFromModules = 0;
                }

                return totalEnergyFromModules;
            }
        }

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}