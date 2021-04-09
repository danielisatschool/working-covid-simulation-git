using System;
using System.Threading;

namespace covid_simulation_game
{
    class Program
    {
        // hi
        // comment
        // creating my variables
        static double currentCases = 0;
        static double totalCases = 0;
        static double spreadRate = 0;
        static double orignalSpreadRate = 0;
        static double importedCases = 0;
        static double deathRate = 0.034;
        static double money = 0;
        static double deaths = 0;
        static double weekNum = 2;
        static double totalDeaths = 0;
        static string lockDown = "tbc";
        static bool trueOrFalse = false;
        static int level = 0;
        static int[] levelArray = new int[4];
        static int currentCasesForAInt = 0;
        static int totalCasesInAInt = 0;
        static int deathsInAInt = 0;
        static double lockdownRValue = 0.8;
        static int importedCasesInAInT = 0;
        static int totalDeathsInAInt = 0;
        static double numCurrentCasesIncreasesBy = 0;
        static string enter = "tbc";
        static string iccalationFacility = "tbc";
        static double recovered = 0;
        static string[] vaccinations = new string[4];
        static bool areYouVaccinated = false;
        static string vaccinationsChoice = "tbc";
        static double vaccinationSpreadRate = 0;
        static void Main(string[] args)
        {
            //getting my colours and telling the user what is happening
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Good morning the world organisation has just found a new virus that is affecting people all over the world," + "\n" + "Your job is to help the New Zealand Government  so that New Zealand survives this pandemic." + "\n" + "when your Text is Green you are safe, but if the text colour goes red then your whole country is at risk of the virus becoming out of control and take over the country");




            Console.WriteLine("please press enter");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            enter = Console.ReadLine();
            Console.Clear();
            // getting the level of difficulity
            Console.WriteLine("How hard do you want your game to be. (easy = 1, medium = 2, hard = 3)");

            levelArray[0] = 0;
            levelArray[1] = 1;
            levelArray[2] = 2;
            levelArray[3] = 3;


            while (!trueOrFalse)
            {
                try
                {
                    level = Convert.ToInt32(Console.ReadLine());
                    if (level > 0 && level < 4)
                        trueOrFalse = true;
                    else
                    {
                        Console.WriteLine("write your number between 1 and 3");
                    }

                }
                catch
                {

                    Console.WriteLine("WRONG you need to input NUMBERS between 1-3");
                }
            }
            // giving the values for the different levels
            switch (levelArray[level])
            {
                case 1:
                    Console.Clear();
                    money = 15000000000;
                    orignalSpreadRate = 2;
                    Thread.Sleep(1000);
                    break;
                case 2:
                    Console.Clear();
                    money = 10000000000;
                    orignalSpreadRate = 2.25;
                    Thread.Sleep(1000);
                    break;
                case 3:
                    Console.Clear();
                    money = 5000000000;
                    orignalSpreadRate = 2.5;
                    Thread.Sleep(1000);
                    break;


            }



            // telling the user what they have to work with
            Console.WriteLine("your total money to start with is $" + money);
            Console.WriteLine("your starting spread rate is " + orignalSpreadRate + " people infected per person infected");

            // calling the methods for what the user wants to do.
            while (totalCases < 6000000 && money > 0)
            {
                if (totalCases > 500000 || deaths > 5000 || money < 800000000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (totalCases <= 500000 || deaths <= 5000 || money >= 800000000)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (weekNum <= 5)
                {

                    noUserChanges();
                    Console.WriteLine("press enter when finished");
                    enter = Console.ReadLine();
                    Console.Clear();
                }
                

                if (weekNum > 5 && weekNum <= 2000)
                {

                    Console.WriteLine("do you want to start or stay in lockdown (yes or no)" + "\n" + " this will decrease  your bank value by 400 million per week but remember to save enough  money for your vaccinations");
                    Console.WriteLine(" vaccinations  cost 1 billion dollars to vaccinate the whole country" + "\n" + "and a isolation facility will cost 500 million to build");
                    trueOrFalse = false;
                    while (trueOrFalse == false)
                    {
                        try
                        {
                            lockDown = Console.ReadLine();
                            if (lockDown == "yes" || lockDown == "no")
                                trueOrFalse = true;
                            else
                            {
                                Console.WriteLine("please check your spelling, yes or no");
                            }

                        }
                        catch
                        {

                            Console.WriteLine("please check your spelling yes or no");
                        }

                    }
                    if (weekNum > 9)
                    {
                        if (iccalationFacility != "yes")
                        {
                            Console.WriteLine("do you want to build a isolation  facility");
                            trueOrFalse = false;
                            while (trueOrFalse = false)
                            {
                                try
                                {
                                    iccalationFacility = Console.ReadLine();
                                    if (iccalationFacility == "yes" || iccalationFacility == "no")
                                        trueOrFalse = true;
                                    else
                                    {
                                        Console.WriteLine("please check your spelling, yes or no");
                                    }

                                }
                                catch
                                {

                                    Console.WriteLine("please check your spelling yes or no");
                                }



                            }
                        }
                            if (iccalationFacility == "yes" && lockDown == "yes")
                            {
                                goingIntoLockdownWithAIscalationFacilityWorking();
                                money = money - 450000000;
                                Console.WriteLine("your total money is now $" + money);
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                            else if (iccalationFacility == "yes" && lockDown == "no")
                            {
                                noUserChangesWithAIscalationFacilityWorking();
                                money = money + 50000000;
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                            else if (iccalationFacility == "no" && lockDown == "no")
                            {
                                noUserChanges();
                                money = money + 50000000;
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                            else if (iccalationFacility == "no" && lockDown == "yes")
                            {
                                goingIntoLockDown();
                                money = money - 450000000;
                                Console.WriteLine("your total money is now $" + money);
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        if (weekNum < 9)
                        {
                            if (lockDown == "yes")
                            {
                                goingIntoLockDown();
                                money = money - 400000000;
                                Console.WriteLine("your total money is now $" + money);
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                            else if (lockDown == "no")
                            {
                                noUserChanges();
                                money = money + 50000000;
                                Console.WriteLine("press enter when finished");
                                enter = Console.ReadLine();
                                Console.Clear();
                            }
                        }

                        
                    }
                    weekNum = weekNum + 2;

                }
                
            
// telling me if i lost of won or lost
                Console.ForegroundColor = ConsoleColor.Red;
                if (totalCases > 5000000)
                {
                    Console.WriteLine("you have too many cases");
                    Console.WriteLine("you lost");
                }
                if (money < 1000000)
                {
                    Console.WriteLine("you have run out of money");
                    Console.WriteLine("you lost");
                }
                if (currentCases < 1)
                {
                    Console.WriteLine("You won, congratulations");
                }
        }



        // creating my method for imported cases
        public static double iscalationNotWorking()
        {
            Random rando = new Random();

            for (int i = 0; i <= 14; i++)
            {
                importedCases = importedCases + rando.Next(0, 5);
            }
            return 1;
        }
        //method for number of cases
        public static double figuringOutTheCases()
        {
            currentCases = currentCases + importedCases;
            numCurrentCasesIncreasesBy = spreadRate * currentCases;


            currentCases = 0;

            currentCasesForAInt = 0;
            totalCasesInAInt = 0;
            deathsInAInt = 0;
            importedCasesInAInT = 0;
            totalDeathsInAInt = 0;
            currentCases = currentCases + numCurrentCasesIncreasesBy;
            totalCases = totalCases + currentCases;

            deaths = currentCases * deathRate;
            totalDeaths = totalDeaths + deaths;

            currentCasesForAInt = Convert.ToInt32(currentCases);
            totalCasesInAInt = Convert.ToInt32(totalCases);
            deathsInAInt = Convert.ToInt32(deaths);
            importedCasesInAInT = Convert.ToInt32(importedCases);
            totalDeathsInAInt = Convert.ToInt32(totalDeaths);
            recovered = totalCasesInAInt - currentCasesForAInt;

            Console.WriteLine("total money in the bank is $" + money);
            Console.WriteLine("week " + weekNum);
            Console.WriteLine("your current cases for the past 2 weeks  are " + currentCasesForAInt + " people infected");
            Console.WriteLine("you have had " + importedCasesInAInT + " imported cases in the past 2 weeks");
            Console.WriteLine("you have had " + totalCasesInAInt + " people infected in total");
            Console.WriteLine("you have had a total of " + deathsInAInt + " deaths in the past two weeks");
            Console.WriteLine("you have had " + recovered + " recovered cases in total");
            Console.WriteLine("you have had a total death toll of " + totalDeathsInAInt);
            Console.WriteLine("\n");
            return 1;
        }
        // method for nolockdown, and no isscalation facility
        public static double noUserChanges()
        {
            spreadRate = orignalSpreadRate;
            importedCases = 0;
            recovered = 0;
            iscalationNotWorking();
            figuringOutTheCases();
            return 1;
        }
        //method for going into lockdown without an issalation facility
        public static double goingIntoLockDown()
        {
            importedCases = 0;
            recovered = 0;
            spreadRate = lockdownRValue;
            iscalationNotWorking();
            figuringOutTheCases();

            return 1;
        }
        // method for no lockdown but with an isscalation facility
        public static double noUserChangesWithAIscalationFacilityWorking()
        {
            spreadRate = orignalSpreadRate;
            importedCases = 0;
            recovered = 0;
            figuringOutTheCases();
            return 1;
        }
        // going into lockdown with a working issolation facility
        public static double goingIntoLockdownWithAIscalationFacilityWorking()
        {
            spreadRate = lockdownRValue;
            importedCases = 0;
            recovered = 0;
            figuringOutTheCases();
            return 1;
        }
        public static double VaccinationsChoices()
        {
            weekNum = weekNum + 2;
            areYouVaccinated = false;
            if (areYouVaccinated == false)
            {
                

                Console.WriteLine("do you want to get your country vaccinated" + '\n' + "you can choose between 3 vaccinations");
                Console.WriteLine("Astrazeneca: this vaccination is 90% effective and will cost you $500,000,000 to vaccinate");
                Console.WriteLine("Moderna: this vaccination is 95% effective and will cost $3,400,000,000 to vaccinate the whole country");
                Console.WriteLine("pfizer: this vaccination is 95% effective and will cost $2,000,000,000 to vaccinate the country");
                string[] typeOfVaccinations = { "Astrazeneca", "Moderna", "pfizer" };
                trueOrFalse = false;

                string vaccinationsChoice = "tbc";
                while (trueOrFalse == false)
                {
                    try
                    {
                        vaccinationsChoice = Console.ReadLine();
                        if (vaccinationsChoice == "Astrazeneca" || vaccinationsChoice == "Moderna" || vaccinationsChoice == "pfizer")
                        {
                            trueOrFalse = true;
                            areYouVaccinated = true;
                        }
                        else if (vaccinationsChoice == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please check your spelling");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("please check your spelling");
                    }
                }
                if (vaccinationsChoice == "Astrazeneca")
                {
                    vaccinationSpreadRate = 0.25 * orignalSpreadRate;
                    spreadRate = vaccinationSpreadRate;
                    money = money - 500000000;
                    Console.WriteLine("your total money is now $" + money);
                }
                else if(vaccinationsChoice == "Moderna")
                {
                    vaccinationSpreadRate = 0.05 * orignalSpreadRate;
                    spreadRate = vaccinationSpreadRate;
                    money = money - 3400000000;
                    Console.WriteLine("your total money is now $" + money);
                }
                else if(vaccinationsChoice == "pfizer")
                {
                    vaccinationSpreadRate = 0.05 * orignalSpreadRate;
                    spreadRate = vaccinationSpreadRate;
                    money = money - 2000000000;
                    Console.WriteLine("your total money is now $" + money);
                }
            }

            return 1;

        }



    }
}
////https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://www.bbc.com/news/world-asia-india-55748124