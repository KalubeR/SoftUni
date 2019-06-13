using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double initialBaseHealth = 100;
        private const double initialBaseArmor = 50;
        private const double initialAbilityPoints = 40;

        public Warrior(string name, Faction faction) 
            : base(name, initialBaseHealth, initialBaseArmor, initialAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            EnsureBothCharactersAreAlive(character);

            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
