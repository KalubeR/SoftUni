using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private const double defaultRestHealMultiplier = 0.2;

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.IsAlive = true;
            this.RestHealMultiplier = defaultRestHealMultiplier;
            this.Name = name;
            this.baseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.Health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    this.Armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    this.Armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public virtual double RestHealMultiplier
        {
            get { return restHealMultiplier; }
            set { restHealMultiplier = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureIsAlive();

            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double remainder = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= remainder;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            EnsureIsAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureIsAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureBothCharactersAreAlive(character);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureIsAlive();

            this.Bag.AddItem(item);
        }

        protected void EnsureIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
        protected void EnsureBothCharactersAreAlive(Character character)
        {
            if (!this.IsAlive || !character.isAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
