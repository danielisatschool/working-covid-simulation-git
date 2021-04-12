using System;
using System.Threading;

namespace covid_simulation_game
{
    class Program
    {
        
        // creating my variables
        static int counter = 0;
        static double currentCases = 0;
        static double totalCases = 0;
        static double spreadRate = 0;
        static double orignalSpreadRate = 0;
        static double importedCases = 0;
        static double deathRate = 0;
        static double money = 0;
        static double deaths = 0;
        static double weekNum = 2;
        static double totalDeaths = 0;
        static string lockDown = "tbc";
        static bool trueOrFalse = false;
        static int level = 0;
        static int[] levelArray = new int[4];
        static int currentCasesForAInt = 1;
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
        static bool vaccinatedOrNot = false;
        static int counter2 = 0;
        static int counter3 = 0;
        static int counter1 = 0;

        static void Main(string[] args)
        {
            //getting my colours and telling the user what is happening
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Good morning. The New Zealand goverment has just found a new virus that is affecting people all over the world." + "\n" + "Your job is to help the New Zealand government, so that New Zealand survives this pandemic." + "\n" + "When your Text is Green you are safe, but if the text colour goes red then your whole country is at risk of the virus becoming out of control and take over the country");




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
                    orignalSpreadRate = 2.1;
                    deathRate = 0.034;
                    Thread.Sleep(1000);
                    break;
                case 2:
                    Console.Clear();
                    money = 10000000000;
                    orignalSpreadRate = 2.25;
                    deathRate = 0.04;
                    Thread.Sleep(1000);
                    break;
                case 3:
                    Console.Clear();
                    money = 5000000000;
                    orignalSpreadRate = 2.5;
                    deathRate = 0.05;
                    Thread.Sleep(1000);
                    break;


            }



            // telling the user what they have to work with
            Console.WriteLine("your total money to start with is $" + money);
            Console.WriteLine("your starting spread rate is " + orignalSpreadRate + " people infected per person infected");

            // calling the methods for what the user wants to do.
            while (totalCases < 6000000 && money > 0 && currentCasesForAInt > 0)
            {
                if (totalCases > 400000 || deaths > 5000 || money < 800000000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (totalCases <= 500000 || deaths <= 5000 || money >= 800000000)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                // no changes available before week 6
                if (weekNum <= 5)
                {
                    
                    noUserChanges();
                    Console.WriteLine("press enter when finished");
                    enter = Console.ReadLine();
                    Console.Clear();
                }

                //you can choose a lockdown at week 8 and above
                // you can chose an isolation facility at week 12 or above
                if (weekNum > 5 && weekNum <= 32)
                {

                    Console.WriteLine("do you want to start/stay in lockdown (yes or no)." + "\n" + " This will decrease your bank value by 400 million per week but remember to save enough  money for your vaccinations");
                    Console.WriteLine(" Vaccinations cost  around 1 billion dollars to vaccinate the whole country, some cost more and some cost less" + "\n" + "A isolation facility will cost $400 million to build");
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
                    if (weekNum >= 12)
                    {
                        callingTheIssalationFacility();
                    }
                    if (weekNum < 12)
                    {
                        calingGoingIntoLockdown();
                    }

                        
                }
                // above week 32 you can choose a vaccination
                if(weekNum > 32)
                {
                    usingVaccinationsChosen();
                }
                weekNum = weekNum + 2;

            }
                
            
// telling me if i lost of won or lost
                Console.ForegroundColor = ConsoleColor.Red;
                if (totalCases > 6000000)
                {
                    Console.WriteLine("you have too many cases");
                    Console.WriteLine("you lost");
                }
                else if (money < 10)
                {
                    Console.WriteLine("you have run out of money");
                    Console.WriteLine("you lost");
                }
                else if (currentCases < 1)
                {
                Console.ForegroundColor = ConsoleColor.Green;
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
            //converting to an int so that it is a whole number
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
            // choosing what spread rate to use
            if (vaccinatedOrNot == false)
            {
                spreadRate = orignalSpreadRate;
            }
            else
            {
                if (counter1 < 4)
                {
                    spreadRate = orignalSpreadRate;
                }
                else
                {
                    spreadRate = vaccinationSpreadRate;
                }
            }
            //setting cases to 0
            importedCases = 0;
            recovered = 0;
            //calling the needed methods
            iscalationNotWorking();
            figuringOutTheCases();
            return 1;
        }
        //method for going into lockdown without an issalation facility
        public static double goingIntoLockDown()
        {
            //setting variables to 0
            importedCases = 0;
            recovered = 0;
            //choosing the spread rate
            if (vaccinatedOrNot == false)
            {
                spreadRate = lockdownRValue;
            }
            else
            {
                if (counter1 < 4)
                {
                    spreadRate = lockdownRValue;
                }
                else
                {
                    spreadRate = vaccinationSpreadRate;
                }
            }
            //calling the needed methods
            iscalationNotWorking();
            figuringOutTheCases();

            return 1;
        }
        // method for no lockdown but with an isscalation facility
        public static double noUserChangesWithAIscalationFacilityWorking()
        {
            //deciding the spreadrate
            if (vaccinatedOrNot == false)
            {
                spreadRate = orignalSpreadRate;
            }
            else
            {
                if (counter1 < 4)
                {
                    spreadRate = orignalSpreadRate;
                }
                else
                {
                    spreadRate = vaccinationSpreadRate;
                }
            }
            // making the variables 0
            importedCases = 0;
            recovered = 0;
            // calling the needed method
            figuringOutTheCases();
            return 1;
        }
        // going into lockdown with a working issolation facility
        public static double goingIntoLockdownWithAIscalationFacilityWorking()
        {
            // setting the spreadrate
            if (vaccinatedOrNot == false)
            {
                spreadRate = lockdownRValue;
            }
            else
            {
                if (counter1 < 4)
                {
                    spreadRate = lockdownRValue;
                }
                else
                {
                    spreadRate = vaccinationSpreadRate;
                }
            }
            //zeroing the variables
            importedCases = 0;
            recovered = 0;
            //calling the methods
            figuringOutTheCases();
            return 1;
        }
        public static double callingTheIssalationFacility()
        {
            //what to do if there is no iscalation facility
            if (iccalationFacility != "yes")
            {
                Console.WriteLine("do you want to build a isolation  facility");
                trueOrFalse = false;
                while (trueOrFalse == false)
                {
                    //error handling
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
            // if the user wants isolation facility and lockdown
            if (iccalationFacility == "yes" && lockDown == "yes")
            {
                //calling the method
                goingIntoLockdownWithAIscalationFacilityWorking();
                //setting the money
                if (counter2 < 1)
                {
                    money = money - 800000000;
                }
                else
                {
                    money = money - 400000000;
                }
                Console.WriteLine("your total money is now $" + money);
                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();
                counter2++;
            }
            // if the user wants isolation facility and no lockdown
            else if (iccalationFacility == "yes" && lockDown == "no")
            {
                //setting the money
                if (counter3 < 1)
                {
                    money = money - 300000000;
                }
                else
                {
                    money = money + 100000000;
                }
                //calling the method
                noUserChangesWithAIscalationFacilityWorking();

                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();
                counter3++;
            }
            //if the user wants to do nothing
            else if (iccalationFacility == "no" && lockDown == "no")
            {
                //calling the method
                noUserChanges();
                //setting the money
                money = money + 100000000;

                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();

            }
            // if user wants only a lockdown
            else if (iccalationFacility == "no" && lockDown == "yes")
            {
                //calling the method
                goingIntoLockDown();
                //setting the money
                money = money - 400000000;
                Console.WriteLine("your total money is now $" + money);
                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();
            }
            return 1;
        }
        //going into lockdown method
        public static double calingGoingIntoLockdown()
        {
           
            if (lockDown == "yes")
            {
                //calling the method
                goingIntoLockDown();
                //setting the money
                money = money - 400000000;
                Console.WriteLine("your total money is now $" + money);
                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();
            }
            else if (lockDown == "no")
            {
                //calling the method needed
                noUserChanges();
                //setting the money
                money = money + 100000000;
                Console.WriteLine("press enter when finished");
                enter = Console.ReadLine();
                Console.Clear();
            }
            return 1;
        }


        public static double VaccinationsChoices()
        {

            if (areYouVaccinated == false)
            {
                
                //telling us about the vaccinations
                Console.WriteLine("do you want to get your country vaccinated" + '\n' + "you can choose between 3 vaccinations");
                Console.WriteLine("Astrazeneca: this vaccination is 70% effective and will cost you $500,000,000 to vaccinate");
                Console.WriteLine("Moderna: this vaccination is 95% effective and will cost $3,400,000,000 to vaccinate the whole country");
                Console.WriteLine("Pfizer: this vaccination is 85% effective and will cost $2,000,000,000 to vaccinate the country");
                Console.WriteLine("These will take two months to come into affect");
                Console.WriteLine("please tell me what vaccination you want or say no if you dont want a vaccination. please be careful it is case sensitive");

                trueOrFalse = false;

                //error handling
                while (trueOrFalse == false)
                {
                    try
                    {
                        vaccinationsChoice = Console.ReadLine();
                        if (vaccinationsChoice == "Astrazeneca" || vaccinationsChoice == "Moderna" || vaccinationsChoice == "Pfizer")
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
                //setting the money and the spreadrate
                if (vaccinationsChoice == "Astrazeneca")
                {
                    vaccinationSpreadRate = 0.3 * spreadRate;
                    //spreadRate = vaccinationSpreadRate;
                    if (counter < 1)
                    {
                        money = money - 500000000;
                    }
                    Console.WriteLine("your total money is now $" + money);
                }
                else if(vaccinationsChoice == "Moderna")
                {
                    vaccinationSpreadRate = 0.05 * spreadRate;
                    //spreadRate = vaccinationSpreadRate;
                    if (counter < 1)
                    {
                        money = money - 3400000000;
                    }
                    Console.WriteLine("your total money is now $" + money);
                }
                else if(vaccinationsChoice == "Pfizer")
                {
                    vaccinationSpreadRate = 0.15 * spreadRate;
                    //spreadRate = vaccinationSpreadRate;
                    if (counter < 1)
                    { 
                        money = money - 2000000000;
                    }
                    Console.WriteLine("your total money is now $" + money);
                }
            }

            return 1;

        }
        public static double usingVaccinationsChosen()
        {
            
            //calling the method
            VaccinationsChoices();
            //what to do if they want a vaccination
            if (vaccinationsChoice == "Astrazeneca" || vaccinationsChoice == "Moderna" || vaccinationsChoice == "Pfizer")
            {
                
                
                
                
                    vaccinatedOrNot = true;
                
                
                Console.WriteLine("do you want to start or stay in lockdown (yes or no)" + "\n" + " this will decrease  your bank value by 400 million per week but remember to save enough  money for your vaccinations");
                Console.WriteLine(" vaccinations  cost 1 billion dollars to vaccinate the whole country" + "\n" + "and a isolation facility will cost 500 million to build");
                trueOrFalse = false;
                //error handling
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
                //calling another method
                callingTheIssalationFacility();
                counter1++;
            }
            //what to do if they do not want a vaccination
            if(vaccinationsChoice == "no")
            {

                Console.WriteLine("do you want to start or stay in lockdown (yes or no)" + "\n" + " this will decrease  your bank value by 400 million per week but remember to save enough  money for your vaccinations");
                Console.WriteLine(" vaccinations  cost 1 billion dollars to vaccinate the whole country" + "\n" + "and a isolation facility will cost 500 million to build");
                trueOrFalse = false;
                //error handling
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
                //calling the method
                callingTheIssalationFacility();
            }

            return 1;
        }



    }
}
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://www.bbc.com/news/world-asia-india-55748124