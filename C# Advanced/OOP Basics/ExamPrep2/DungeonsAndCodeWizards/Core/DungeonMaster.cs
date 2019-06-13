﻿using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, factionResult);
                    break;
                case "Cleric":
                    character = new Cleric(name, factionResult);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType }\"!");
            }
            characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;
            switch (itemName)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
            this.items.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Item itemToPickUp = items.Pop();
            character.Bag.AddItem(itemToPickUp);

            return $"{characterName} picked up {itemToPickUp.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            ((Warrior)attacker).Attack(receiver);

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string receiverName = args[1];

            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(receiverName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            ((Cleric)healer).Heal(receiver);

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.Where(x => x.IsAlive))
            {
                double healthBefore = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBefore} => {character.Health})");
            }
            if (characters.Count(x => x.IsAlive) <= 1)
            {
                rounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (rounds > 1)
            {
                return true;
            }
            return false;
        }

        private Character GetCharacter(string characterName)
        {
            Character character = characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }


            return character;
        }
    }
}
