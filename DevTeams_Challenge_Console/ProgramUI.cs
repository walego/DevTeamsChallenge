using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _devTeamRepo = new DevTeamsRepo();
        private bool _devTeamMenu;

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                //work with devteams or devs
                Console.WriteLine("Do you want to work with (1)DevTeams or (2)Developers?");
                string menuChoice = Console.ReadLine();
                if (menuChoice == "1")
                {
                    _devTeamMenu = true;
                    goto DevTeamMenu;
                }
                else if (menuChoice == "2")
                {
                    _devTeamMenu = false;
                    goto DeveloperMenu;
                }
                else
                {
                    Console.WriteLine("Please enter a vaild number");
                    AnyKey();
                    Console.Clear();
                }
            DevTeamMenu:
                {
                    while (_devTeamMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the number of the option you would like:\n" +
                            "DEV TEAM MENU\n" +
                            "1. Create a New Dev Team\n" +
                            "2. Show All Dev Teams\n" +
                            "3. Find an Individual Dev Team\n" +
                            "4. Add a Developer to a Dev Team\n" +
                            "5. Remove a Developer from a Dev Team\n" +
                            "6. Change a Dev Team's Name\n" +
                            "7. Remove a Dev Team\n" +
                            "\n" +
                            "8. Switch to Developer Menu\n" +
                            "9. Exit Program");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                CreateNewDevTeam();
                                break;
                            case "2":
                                DisplayAllDevTeamsMenu();
                                break;
                            case "3":
                                DisplayDevTeamInfo();
                                break;
                            case "4":
                                AddDeveloperToDevTeam();
                                break;
                            case "5":
                                RemoveDeveloperFromDevTeam();
                                break;
                            case "6":
                                ChangeDevTeamName();
                                break;
                            case "7":
                                DeleteExistingDevTeam();
                                break;
                            case "8":
                                _devTeamMenu = false;
                                goto DevTeamMenu;
                            case "9":
                                goto ExitProgram;
                            default:
                                Console.WriteLine("Please enter a valid number between 1 and 9");
                                AnyKey();
                                break;

                        }
                    }
                }

            DeveloperMenu:
                {
                    while (_devTeamMenu == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the number of the option you would like:\n" +
                            "DEVELOPER MENU\n" +
                            "1. Create a New Developer\n" +
                            "2. Show All Developers\n" +
                            "3. Individual Developer Info\n" +
                            "4. Monthly Pluralsight License Listing\n" +
                            "5. Update a Developer's Information\n" +
                            "6. Remove a Developer\n" +
                            "\n" +
                            "7. Switch to Dev Team Menu\n" +
                            "8. Exit Program");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                CreateNewDeveloper();
                                break;
                            case "2":
                                DisplayAllDevelopersMenu();
                                break;
                            case "3":
                                DisplayDeveloperByID();
                                break;
                            case "4":
                                DisplayDevelopersWithoutPluralsight();
                                break;
                            case "5":
                                UpdateExistingDeveloper();
                                break;
                            case "6":
                                DeleteExistingDeveloper();
                                break;
                            case "7":
                                _devTeamMenu = true;
                                goto DevTeamMenu;
                            case "8":
                                goto ExitProgram;
                            default:
                                Console.WriteLine("Please enter a valid number between 1 and 8");
                                AnyKey();
                                break;

                        }
                    }
                }
            ExitProgram:
                {
                    continueToRun = false;
                }
            }
        }
        // DevTeam Menu Methods
        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam team = new DevTeam();
            Console.Write("Enter Team Name: ");
            team.TeamName = Console.ReadLine();
            if (_devTeamRepo.AddNewTeam(team))
            {
                Console.WriteLine("Team successfully added");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                AnyKey();
            }
        }
        private void DisplayAllDevTeamsMenu()
        {
            DisplayAllDevTeams();
            AnyKey();
        }
        private void DisplayDevTeamInfo() //This should have been converted to a helper method (without the anykey)
        {
            DisplayAllDevTeams();
            Console.Write("Please enter Team Number: ");
            int teamID = Convert.ToInt32(Console.ReadLine());
            DevTeam team = _devTeamRepo.GetDevTeamByID(teamID);
            Console.Clear();
            DisplayFullTeamInfo(team);
            AnyKey();
        }
        private void AddDeveloperToDevTeam()
        {
            Console.Clear();
            DisplayAllDevTeams();
            Console.Write("Please enter Team Number of Dev Team to add members to: ");
            int teamID = Convert.ToInt32(Console.ReadLine());
            bool addMembers = true;
            while (addMembers)
            {
                Console.Clear();
                DisplayAllDevelopers();
                Console.Write("Please enter ID Number of the Developer you want to add: ");
                int devID = Convert.ToInt32(Console.ReadLine());
                if (_devTeamRepo.AddDeveloperToTeam(devID, teamID))
                {
                    Console.WriteLine("Developer successfully added");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
                Console.WriteLine("1: Add another developer to this team\n" +
                    "2: Back to Main Menu");
                int anotherMember = Convert.ToInt32(Console.ReadLine());
                if (anotherMember != 1)
                {
                    addMembers = false;
                }

            }
        }
        private void RemoveDeveloperFromDevTeam()
        {
            Console.Clear();
            DisplayAllDevTeams();
            Console.Write("Please enter Team Number of Dev Team to remove members from: ");
            int teamID = Convert.ToInt32(Console.ReadLine());
            DevTeam team = _devTeamRepo.GetDevTeamByID(teamID);
            bool addMembers = true;
            while (addMembers)
            {
                Console.Clear();
                DisplayAllDevelopers();
                Console.Write("Please enter ID Number of the Developer you want to remove: ");
                int devID = Convert.ToInt32(Console.ReadLine());
                if (_devTeamRepo.RemoveDeveloperFromTeam(devID, teamID))
                {
                    Console.WriteLine("Developer successfully removed");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
                Console.WriteLine("Press 1 if you want to remove another developer from this team");
                int anotherMember = Convert.ToInt32(Console.ReadLine());
                if (anotherMember != 1)
                {
                    addMembers = false;
                }
                else if (team.Developers.Count == 0)
                {
                    Console.WriteLine("There are no more members on this team to remove");
                    addMembers = false;
                }

            }
        }
        private void ChangeDevTeamName()
        {
            DisplayAllDevTeams();
            Console.Write("Please enter Team Number of team to update: ");
            int teamID = Convert.ToInt32(Console.ReadLine());
            DevTeam team = _devTeamRepo.GetDevTeamByID(teamID);
            Console.Write("Please enter new Team Name: ");
            team.TeamName = Console.ReadLine();
            AnyKey();
        }
        private void DeleteExistingDevTeam()
        {
            DisplayAllDevTeams();
            Console.Write("Please enter Team Number of the team you want to remove: ");
            int teamID = Convert.ToInt32(Console.ReadLine());
            DevTeam toRemove = _devTeamRepo.GetDevTeamByID(teamID);
            if (_devTeamRepo.RemoveDevTeam(toRemove))
            {
                Console.WriteLine($"{toRemove.TeamName} removed successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            AnyKey();
        }
        // Developer Menu Methods
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer dev = new Developer();
            Console.Write("Enter First Name: ");
            dev.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            dev.LastName = Console.ReadLine();
            Console.WriteLine("Please enter the Number corresponding to the Developer's Specialty:\n" +
                "1: Front-End\n" +
                "2: Back-End\n" +
                "3: Testing\n");
            dev.Specialty = (Specialty)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does developer have Pluralsight access? Y/N");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                    dev.PluralsightAccess = true;
                    break;
                case "n":
                case "no":
                    dev.PluralsightAccess = false;
                    break;
                default:
                    Console.WriteLine("Information not added");
                    break;
            }
            if (_devTeamRepo.AddDeveloper(dev))
            {
                Console.WriteLine("Developer Successfully Added");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                AnyKey();
            }
        }
        private void DisplayAllDevelopersMenu()
        {
            Console.Clear();
            List<Developer> listOfDevs = _devTeamRepo.GetAllDevelopers();
            foreach (Developer dev in listOfDevs)
            {
                DisplayDevBasicInfo(dev);
            }
            AnyKey();
        }
        private void DisplayDeveloperByID()
        {
            Console.Clear();
            foreach (Developer developer in _devTeamRepo.GetAllDevelopers())
            {
                DisplayDevBasicInfo(developer);
            }
            Console.Write("Enter the ID Number of the developer you want to look up: ");
            int devID = Convert.ToInt32(Console.ReadLine());
            Developer dev = _devTeamRepo.GetDevByID(devID);
            DisplayDevFullInfo(dev);
            AnyKey();

        }

        private void DisplayDevelopersWithoutPluralsight()
        {
            Console.Clear();
            Console.WriteLine("The following developers do not have Pluralsight access:");
            foreach (Developer dev in _devTeamRepo.GetAllDevelopers())
            {
                if (dev.PluralsightAccess == false)
                    DisplayDevBasicInfo(dev);
            }
            AnyKey();
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            foreach (Developer dev in _devTeamRepo.GetAllDevelopers())
            {
                DisplayDevBasicInfo(dev);
            }
            Console.Write("Enter the ID Number of the developer you want to update: ");
            int lookupID = Convert.ToInt32(Console.ReadLine());
            Developer oldDev = _devTeamRepo.GetDevByID(lookupID);
            if (oldDev != default)
            {
                Console.Write("Please enter new First Name or press Enter: ");
                string firstName = Console.ReadLine();
                if (firstName != "")
                    oldDev.FirstName = firstName;
                Console.Write("Please enter new Last Name or press Enter: ");
                string lastName = Console.ReadLine();
                if (lastName != "")
                    oldDev.LastName = lastName;
                Console.WriteLine("Input the Number corresponding to the Developer's new Specialty or press Enter:\n" +
                    "1: Front-End\n" +
                    "2: Back-End\n" +
                    "3: Testing\n");
                string devSpecialty = Console.ReadLine();
                if (devSpecialty != "")
                    oldDev.Specialty = (Specialty)Convert.ToInt32(devSpecialty);
                Console.WriteLine("Does the developer have Pluralsight access? Y/N or press enter to skip");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                    case "yes":
                        oldDev.PluralsightAccess = true;
                        break;
                    case "n":
                    case "no":
                        oldDev.PluralsightAccess = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("Here is the updated developer information:");
                DisplayDevFullInfo(oldDev);
            }
            else
            {
                Console.WriteLine("No Developer with that ID exists.");
            }
            AnyKey();
        }

        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            foreach (Developer dev in _devTeamRepo.GetAllDevelopers())
            {
                DisplayDevBasicInfo(dev);
            }
            Console.Write("Enter ID Number of developer you want to remove: ");
            int devID = Convert.ToInt32(Console.ReadLine());
            Developer toRemove = _devTeamRepo.GetDevByID(devID);
            if (_devTeamRepo.RemoveDeveloper(toRemove))
            {
                Console.WriteLine($"{toRemove.FullName} removed successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            AnyKey();
        }

        // Helpermethods 
        private void DisplayDevBasicInfo(Developer dev)
        {
            Console.WriteLine($"ID#{dev.DeveloperID}--{dev.LastName}, {dev.FirstName}");
        }

        private void DisplayDevFullInfo(Developer dev)
        {
            if (dev != default)
            {
                DisplayDevBasicInfo(dev);
                Console.WriteLine($"Specialty: {dev.Specialty}");
                Console.WriteLine($"Has Pluralsight Access: {dev.PluralsightAccess}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Developer exists with that ID");
            }
        }
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfDevs = _devTeamRepo.GetAllDevelopers();
            foreach (Developer dev in listOfDevs)
            {
                DisplayDevBasicInfo(dev);
            }
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void DisplayAllDevTeams()
        {
            Console.Clear();
            foreach (DevTeam team in _devTeamRepo.GetAllDevTeams())
            {
                DisplayTeamBasicInfo(team);
            }
        }

        private void DisplayTeamBasicInfo(DevTeam team)
        {
            Console.WriteLine($"Team #{team.TeamID} {team.TeamName}\n" +
                $"Members-{team.Developers.Count()}\n" +
                $"");
        }
        private void DisplayFullTeamInfo(DevTeam team)
        {
            if (team != default)
            {
                DisplayTeamBasicInfo(team);
                foreach (Developer dev in team.Developers)
                {
                    DisplayDevFullInfo(dev);
                }
            }
            else
            {
                Console.WriteLine("No Team exists with that ID");
            }
        }

        private void SeedContent()
        {
            Developer billy = new Developer("Billy", "Lego", Specialty.BackEnd, true);
            Developer alex = new Developer("Alex", "Williams", Specialty.FrontEnd, false);
            Developer taco = new Developer("Taco", "Bell", Specialty.Testing, false);
            Developer john = new Developer("John", "Darksouls", Specialty.BackEnd, true);
            Developer gelethar = new Developer("Gelethar", "R'thu'lk", Specialty.FrontEnd, true);
            _devTeamRepo.AddDeveloper(billy);
            _devTeamRepo.AddDeveloper(alex);
            _devTeamRepo.AddDeveloper(gelethar);
            _devTeamRepo.AddDeveloper(taco);
            _devTeamRepo.AddDeveloper(john);
            DevTeam spiders = new DevTeam("Spiders");
            DevTeam octopodes = new DevTeam("Octopodes");
            DevTeam lame = new DevTeam("Boring team");
            _devTeamRepo.AddNewTeam(spiders);
            _devTeamRepo.AddNewTeam(octopodes);
            _devTeamRepo.AddNewTeam(lame);
            _devTeamRepo.AddDeveloperToTeam(101, 1);
            _devTeamRepo.AddDeveloperToTeam(102, 1);
            _devTeamRepo.AddDeveloperToTeam(103, 2);
            _devTeamRepo.AddDeveloperToTeam(104, 2);
            _devTeamRepo.AddDeveloperToTeam(105, 2);
        }
    }
}
