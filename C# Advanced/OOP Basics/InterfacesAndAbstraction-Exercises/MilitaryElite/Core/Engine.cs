using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] inputArgs = input.Split();
                string type = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];
                decimal salary = decimal.Parse(inputArgs[4]);

                if (type == "Private")
                {
                    IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
                    this.soldiers.Add(privateSoldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < inputArgs.Length; i++)
                    {
                        int priv = int.Parse(inputArgs[i]);
                        IPrivate privateSoldier = (IPrivate)this.soldiers.FirstOrDefault(x => x.Id == priv);

                        if (privateSoldier != null)
                        {
                            lieutenantGeneral.Privates.Add(privateSoldier);
                        }
                    }
                    soldiers.Add(lieutenantGeneral);
                }
                else if (type == "Engineer")
                {
                    string corpsAsString = inputArgs[5];
                    if (!Enum.TryParse(corpsAsString, out Corps corps))
                    {
                        continue;
                    }
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < inputArgs.Length; i += 2)
                    {
                        string repairPart = inputArgs[i];
                        int hours = int.Parse(inputArgs[i + 1]);
                        IRepair repair = new Repair(repairPart, hours);
                        engineer.Repairs.Add(repair);
                    }
                    soldiers.Add(engineer);
                }
                else if (type == "Commando")
                {
                    string corpsAsString = inputArgs[5];
                    if (!Enum.TryParse(corpsAsString, out Corps corps))
                    {
                        continue;
                    }
                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < inputArgs.Length; i += 2)
                    {
                        string codeName = inputArgs[i];
                        string stateAsString = inputArgs[i + 1];

                        if (!Enum.TryParse(stateAsString, out State state))
                        {
                            continue;
                        }

                        Mission mission = new Mission(codeName, state);
                        commando.Missions.Add(mission);
                    }
                    soldiers.Add(commando);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(inputArgs[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
