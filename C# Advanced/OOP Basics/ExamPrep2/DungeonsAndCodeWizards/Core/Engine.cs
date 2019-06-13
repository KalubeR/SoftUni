using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                try
                {
                    string[] inputArgs = input.Split();
                    string command = inputArgs[0];

                    string[] args = inputArgs.Skip(1).ToArray();
                    string result = string.Empty;

                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(args);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(args);
                            break;
                        case "IsGameOver":
                            dungeonMaster.IsGameOver();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException x)
                {
                    Console.WriteLine("Invalid Operation: "+ x.Message);
                }

                if (dungeonMaster.IsGameOver())
                {
                    break;
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
