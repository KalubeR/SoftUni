using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int basicWeight = 10;

        public ArmorRepairKit() 
            : base(basicWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);

            character.Armor = character.BaseArmor;
        }
    }
}
