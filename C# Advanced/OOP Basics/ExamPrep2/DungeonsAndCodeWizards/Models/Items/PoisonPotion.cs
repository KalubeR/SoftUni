using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int basicWeight = 5;

        public PoisonPotion()
            : base(basicWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);

            character.Health -= 20;
            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
