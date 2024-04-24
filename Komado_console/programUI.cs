using System;
using System.Collections.Generic;
using Repository;

namespace KomodoInsuranceConsoleApp
{
    public class ProgramUI
    {
        private DeveloperRepo developerRepo;
        private DevTeamRepo devTeamRepo;

        public ProgramUI()
        {
            developerRepo = new DeveloperRepo();
            devTeamRepo = new DevTeamRepo();
        }

        public void Run()
        {
            bool continueManaging = true;

            while (continueManaging)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Manage Developers");
                Console.WriteLine("2. Manage Development Teams");
                Console.WriteLine("3. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ManageDevelopers();
                            break;
                        case 2:
                            ManageDevTeams();
                            break;
                        case 3:
                            continueManaging = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number."); 
                    System.Console.Clear() ;
                }
            }
        }
        //Developers menu 
        private void ManageDevelopers()
        {
            bool backToMain = false;

            while (!backToMain)
            {
                Console.WriteLine("Developer Management");
                Console.WriteLine("1. Add Developer");
                Console.WriteLine("2. Remove Developer");
                Console.WriteLine("3. List All Developers");
                Console.WriteLine("4. Back to Main Menu");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddDeveloper();
                            break;
                        case 2:
                            RemoveDeveloper();
                            break;
                        case 3:
                            ListAllDevelopers();
                            break;
                        case 4:
                            backToMain = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        //Create 
        private void AddDeveloper()
        {
            Console.Write("Enter Developer Name: ");
            string name = Console.ReadLine();
            Console.Write("Does the Developer have Pluralsight Access? (true/false): ");
            if (bool.TryParse(Console.ReadLine(), out bool hasPluralsightAccess))
            {
                Developer developer = new Developer
                {
                    Name = name,
                    HasPluralsightAccess = hasPluralsightAccess
                };

                developerRepo.AddDeveloper(developer);
                Console.WriteLine("Developer added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter true or false.");
            } 
        } 
        
        //Delete 
        private void RemoveDeveloper()
        {
            Console.Write("Enter Developer ID to Remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                developerRepo.RemoveDeveloper(id);
                Console.WriteLine("Developer removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Developer ID.");
            }
        }
        //Read 
        private void ListAllDevelopers()
        {
            var developers = developerRepo.GetAllDevelopers();
            Console.WriteLine("List of Developers:");
            foreach (var developer in developers)
            {
                Console.WriteLine($"ID: {developer.DeveloperId}, Name: {developer.Name}, Pluralsight Access: {developer.HasPluralsightAccess}");
            }
        }
        //DevTeams 
        private void ManageDevTeams()
        {
            bool backToMain = false;

            while (!backToMain)
            {
                Console.WriteLine("Development Team Management");
                Console.WriteLine("1. Create Team");
                Console.WriteLine("2. Remove Team");
                Console.WriteLine("3. Add Developer to Team");
                Console.WriteLine("4. Remove Developer from Team");
                Console.WriteLine("5. List All Teams");
                Console.WriteLine("6. Back to Main Menu");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateTeam();
                            break;
                        case 2:
                            RemoveTeam();
                            break;
                        case 3:
                            AddDeveloperToTeam();
                            break;
                        case 4:
                            RemoveDeveloperFromTeam();
                            break;
                        case 5:
                            ListAllTeams();
                            break;
                        case 6:
                            backToMain = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        //Create a team of Developers 
        private void CreateTeam()
        {
            Console.Write("Enter Team Name: ");
            string name = Console.ReadLine();

            DevTeam team = new DevTeam
            {
                TeamName = name,
                TeamMembers = new List<Developer>()
            };

            devTeamRepo.AddTeam(team);
            Console.WriteLine("Team created successfully.");
        }

        private void RemoveTeam()
        {
            Console.Write("Enter Team ID to Remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                devTeamRepo.RemoveTeam(id);
                Console.WriteLine("Team removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Team ID.");
            }
        }

        //Adding Developers to a team
        private void AddDeveloperToTeam()
        {
            Console.Write("Enter Team ID: ");
            if (int.TryParse(Console.ReadLine(), out int teamId))
            {
                Console.Write("Enter Developer ID to Add: ");
                if (int.TryParse(Console.ReadLine(), out int developerId))
                {
                    Developer developer = developerRepo.GetDeveloperById(developerId);
                    if (developer != null)
                    {
                        devTeamRepo.AddDeveloperToTeam(teamId, developer);
                        Console.WriteLine("Developer added to team successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Developer not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Developer ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Team ID.");
            }
        }

            //Delete 
        private void RemoveDeveloperFromTeam()
        {
            Console.Write("Enter Team ID: ");
            if (int.TryParse(Console.ReadLine(), out int teamId))
            {
                Console.Write("Enter Developer ID to Remove: ");
                if (int.TryParse(Console.ReadLine(), out int developerId))
                {
                    devTeamRepo.RemoveDeveloperFromTeam(teamId, developerId);
                    Console.WriteLine("Developer removed from team successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Developer ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Team ID.");
            }
        }

        //Read 
        private void ListAllTeams()
        {
            var teams = devTeamRepo.GetAllTeams();
            Console.WriteLine("List of Teams:");
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.TeamId}, Name: {team.TeamName}");
                Console.WriteLine("Members:");
                foreach (var member in team.TeamMembers)
                {
                    Console.WriteLine($"- ID: {member.DeveloperId}, Name: {member.Name}");
                }
                Console.WriteLine();
            }
        }
    } 


}