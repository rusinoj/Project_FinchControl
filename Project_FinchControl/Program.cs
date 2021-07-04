using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{
    
    // User Commands
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Program to control finch robot actions through use of menus.
    //              Fred can display talents and record temperature and light.
    //              He can also set a light or temperature based alarm.
    // Application Type: Console
    // Author: Rusinowski, Jack
    // Dated Created: 6/6/2021
    // Last Modified: 7/4/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch fred = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Set Theme");
                Console.WriteLine("\tg) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(fred);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(fred);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(fred);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(fred);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(fred);
                        break;

                    case "f":
                        SetTheme();
                        break;

                    case "g":
                        DisplayDisconnectFinchRobot(fred);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(fred);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region SET THEME
        static void SetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;

            //
            // set current theme from data
            //
            themeColors = ReadThemeData();
            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            Console.Clear();
            DisplayScreenHeader("Set Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the current theme? (Yes or No): ");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    //
                    // set new theme
                    //
                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tIs this the theme you would like?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        WriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);
                    }

                } while (!themeChosen);
            }
            DisplayContinuePrompt();
        }

        private static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeData()
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            themeColors = File.ReadAllLines(dataPath);

            Enum.TryParse(themeColors[0], true, out foregroundColor);
            Enum.TryParse(themeColors[1], true, out backgroundColor);

            return (foregroundColor, backgroundColor);
        }

        static void WriteThemeData(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            string dataPath = @"Data/Theme.txt";

            File.WriteAllText(dataPath, foregroundColor.ToString() + "\n");
            File.AppendAllText(dataPath, backgroundColor.ToString());
        }

        static ConsoleColor GetConsoleColorFromUser(string color)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write($"\tEnter a value for the {color}:");
                validConsoleColor = Enum.TryParse(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\tIt appears you did not provide a valid console color. Please try again.\n");
                }
                else
                {
                    validConsoleColor = true;
                }

            } while (!validConsoleColor);

            return consoleColor;
        }
        #endregion

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch fred)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(fred);
                        break;

                    case "b":
                        TalentShowDisplayDance(fred);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(fred);
                        break;

                    case "d":
                        
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="fred">finch robot object</param>
        static void TalentShowDisplayMixingItUp(Finch fred)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It up");

            Console.WriteLine("\tFred the Finch robot will now perform his favorite tune, Twinkle Twinkle Little Star!");
            DisplayContinuePrompt();

            fred.setLED(255, 255, 255);
            fred.setMotors(100, 100);
            fred.noteOn(261);
            fred.wait(500);
            fred.noteOn(261);
            fred.wait(500);
            fred.setLED(0, 0, 0);
            fred.setMotors(0, 0);
            fred.noteOn(392);
            fred.wait(500);
            fred.noteOn(392);
            fred.wait(500);
            fred.setLED(255, 255, 255);
            fred.setMotors(-100, -100);
            fred.noteOn(440);
            fred.wait(500);
            fred.noteOn(440);
            fred.wait(500);
            fred.setLED(0, 0, 0);
            fred.setMotors(0, 0);
            fred.noteOn(261);
            fred.wait(1000);
            fred.noteOff();
            fred.wait(500);

            fred.setLED(255, 255, 255);
            fred.setMotors(100, 100);
            fred.noteOn(349);
            fred.wait(500);
            fred.noteOn(349);
            fred.wait(500);
            fred.setLED(0, 0, 0);
            fred.setMotors(0, 0);
            fred.noteOn(329);
            fred.wait(500);
            fred.noteOn(329);
            fred.wait(500);
            fred.setLED(255, 255, 255);
            fred.setMotors(-100, -100);
            fred.noteOn(293);
            fred.wait(500);
            fred.noteOn(293);
            fred.wait(500);
            fred.noteOn(261);
            fred.wait(500);
            fred.setMotors(0, 0);
            for (int song = 2; song > 0; song--)
            {
                fred.setLED(0, 0, 255);
                fred.wait(500);
                fred.setMotors(150, 0);
                fred.noteOn(392);
                fred.wait(500);
                fred.noteOn(392);
                fred.wait(500);
                fred.setMotors(0, 150);
                fred.noteOn(349);
                fred.wait(500);
                fred.noteOn(349);
                fred.wait(500);
                fred.setLED(255, 255, 0);
                fred.setMotors(150, 0);
                fred.noteOn(329);
                fred.wait(500);
                fred.noteOn(329);
                fred.wait(500);
                fred.setMotors(0, 0);
                fred.noteOn(293);
                fred.wait(500);
            }
            fred.setLED(0, 0, 0);
            fred.noteOn(261);
            fred.wait(500);
            fred.noteOn(261);
            fred.wait(500);
            fred.noteOn(392);
            fred.wait(500);
            fred.noteOn(392);
            fred.wait(500);
            fred.noteOn(440);
            fred.wait(500);
            fred.noteOn(440);
            fred.wait(500);
            fred.noteOn(261);
            fred.wait(500);
            fred.noteOff();

            fred.setLED(255, 255, 255);

            fred.wait(500);
            fred.noteOn(349);
            fred.wait(500);
            fred.noteOn(349);
            fred.wait(500);
            fred.noteOn(329);
            fred.wait(500);
            fred.noteOn(329);
            fred.wait(500);
            fred.noteOn(293);
            fred.wait(500);
            fred.noteOn(293);
            fred.wait(500);
            fred.noteOn(261);
            fred.wait(250);
            fred.setMotors(-200, 200);
            fred.wait(3000);
            fred.noteOff();
            fred.setMotors(0, 0);
            fred.setLED(0, 0, 0);


            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                             *
        /// *****************************************************************
        /// </summary>
        /// <param name="fred">finch robot object</param>
        static void TalentShowDisplayDance(Finch fred)
        {
            string userResponse;
            bool validResponse = false;
            int numberOfSpins;

            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tFred the Finch robot can now show off his impeccable dance moves!");

            do
            {
                
                Console.WriteLine("\tHow many spins would you like Fred to do? (Small integers are recommended.)");
                userResponse = Console.ReadLine();

                //
                // test response for a number and provide feedback
                //
                if (int.TryParse(userResponse, out numberOfSpins))
                {
                    //
                    // test response for a positive number and provide feedback
                    //
                    if (numberOfSpins <= 0)
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter a positive number.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }

            } while (!validResponse);

            Console.WriteLine($"Fred will perform {numberOfSpins} spins at the climax of his dance!");
            DisplayContinuePrompt();

            fred.setMotors(200, 200);
            fred.wait(1000);
            fred.setMotors(-150, 0);
            fred.wait(2000);
            fred.setMotors(0, -150);
            fred.wait(2000);
            fred.setMotors(-150, 0);
            fred.wait(1000);
            fred.setMotors(0, -150);
            fred.wait(1000);
            fred.setMotors(0, 0);
            fred.wait(1000);

            fred.setMotors(-50, 50);
            fred.wait(1000);
            fred.setMotors(150, -150);
            fred.wait(2000);
            fred.setMotors(-255, 255);
            fred.wait(5000);
            fred.setMotors(0, 0);
            fred.wait(1000);

            for (int fun = numberOfSpins; fun > 0; fun--)
            {
                for (int circle = 255; circle > 0; circle--)
                {
                    fred.setMotors(circle, -circle);
                }
            }

            fred.setMotors(100, 100);
            fred.wait(500);
            fred.setMotors(0, 0);
            fred.wait(250);
            fred.setMotors(-200, -200);
            fred.wait(1000);
            fred.setMotors(255, 255);
            fred.wait(200);
            fred.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="fred">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch fred)
        {
            
            string userResponse;

            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tFred the Finch robot must quickly warm up.");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 255; lightSoundLevel > 0; lightSoundLevel--)
            {
                fred.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                fred.noteOn(lightSoundLevel * 50);

            }
            fred.noteOff();
            Console.WriteLine("\tNow, would you like to see Fred's extra special light and sound show?");
            userResponse = Console.ReadLine().ToLower();
            while (userResponse != "yes" && userResponse != "no")
            {
                Console.WriteLine("\tIt appears you did not give a valid response. Please try again.");

                Console.WriteLine("\tDo want to see Fred's extra special light and sound show?");
                userResponse = Console.ReadLine().ToLower();
            }

            if (userResponse == "yes")
            {
                Console.WriteLine("\tGo Fred! Go Fred!");

                fred.noteOff();
                fred.noteOn(261);
                fred.setLED(255, 0, 0);
                fred.wait(1000);
                fred.noteOn(350);
                fred.setLED(0, 255, 0);
                fred.wait(1000);
                fred.noteOn(196);
                fred.setLED(0, 0, 255);
                fred.wait(1000);
                fred.noteOn(261);
                fred.setLED(0, 255, 0);
                fred.wait(1000);
                fred.noteOn(523);
                fred.setLED(255, 255, 255);
                fred.wait(2000);
                fred.noteOn(493);
                fred.setLED(255, 0, 0);
                fred.wait(500);
                fred.noteOn(440);
                fred.setLED(0, 255, 0);
                fred.wait(500);
                fred.noteOn(392);
                fred.setLED(255, 0, 0);
                fred.wait(500);
                fred.noteOn(349);
                fred.setLED(0, 255, 0);
                fred.wait(500);
                fred.noteOn(329);
                fred.setLED(255, 0, 0);
                fred.wait(500);
                fred.noteOn(293);
                fred.setLED(0, 255, 0);
                fred.wait(500);
                fred.noteOn(261);
                fred.setLED(255, 255, 255);
                fred.wait(4000);
                fred.noteOff();
                fred.setLED(0, 0, 0);
            }

            else
            {
                Console.WriteLine("I see. Not everyone can handle the talent Fred possesses.");
            }            

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER
        private static void DataRecorderDisplayMenuScreen(Finch fred)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            Console.CursorVisible = true;
            double[] temperatures = null;
            double[] rightLights = null;
            double[] leftLights = null;
            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Temperature Data");
                Console.WriteLine("\td) Get Right Light Data");
                Console.WriteLine("\te) Get Left Light Data");
                Console.WriteLine("\tf) Show Temperature Data");
                Console.WriteLine("\tg) Show Right Light Data");
                Console.WriteLine("\th) Show Left Light Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();
                
                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetNumberOfDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetDataTemps(numberOfDataPoints, dataPointFrequency, fred);
                        break;

                    case "d":
                        rightLights = DataRecorderDisplayGetDataRightLights(numberOfDataPoints, dataPointFrequency, fred);
                        break;

                    case "e":
                        leftLights = DataRecorderDisplayGetDataLeftLights(numberOfDataPoints, dataPointFrequency, fred);
                        break;

                    case "f":
                        DataRecorderDisplayDataTemps(temperatures);
                        break;

                    case "g":
                        DataRecorderDisplayDataRightLights(rightLights);
                        break;

                    case "h":
                        DataRecorderDisplayDataLeftLights(leftLights);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);

        }

        private static void DataRecorderDisplayDataLeftLights(double[] leftLights)
        {
            string userResponse;

            DisplayScreenHeader("Show Left Light Data");

            Console.WriteLine("Recording #".PadLeft(15) + "Left Light".PadLeft(15));
            Console.WriteLine("---------".PadLeft(15) + "---------".PadLeft(15));

            for (int index = 0; index < leftLights.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                 leftLights[index].ToString("n2").PadLeft(15));
            }
            DisplayContinuePrompt();

            Console.WriteLine("\tNow, would you like to average this sensor's values?");
            userResponse = Console.ReadLine().ToLower();
            while (userResponse != "yes" && userResponse != "no")
            {
                Console.WriteLine("\tIt appears you did not give a valid response. Please try again.");

                Console.WriteLine("\tWould you like to average this sensor's values?");
                userResponse = Console.ReadLine().ToLower();
            }

            if (userResponse == "yes")
            {
                double sum = 0, avg = 0;

                for (int i = 0; i < leftLights.Length; i++)
                {
                    sum += leftLights[i];
                }
                avg = sum / leftLights.Length;
                Console.WriteLine("The sum is : " + sum);
                Console.WriteLine("The average is : " + avg);
            }

            else
            {
                Console.WriteLine("I see. Not everyone cares for that information.");
            }
            DisplayContinuePrompt();
        }

        private static void DataRecorderDisplayDataRightLights(double[] rightLights)
        {
            string userResponse;

            DisplayScreenHeader("Show Right Light Data");

            Console.WriteLine("Recording #".PadLeft(15) + "Right Light".PadLeft(15));
            Console.WriteLine("---------".PadLeft(15) + "---------".PadLeft(15));

            for (int index = 0; index < rightLights.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                 rightLights[index].ToString("n2").PadLeft(15));
            }
            DisplayContinuePrompt();

            Console.WriteLine("\tNow, would you like to average this sensor's values?");
            userResponse = Console.ReadLine().ToLower();
            while (userResponse != "yes" && userResponse != "no")
            {
                Console.WriteLine("\tIt appears you did not give a valid response. Please try again.");

                Console.WriteLine("\tWould you like to average this sensor's values?");
                userResponse = Console.ReadLine().ToLower();
            }

            if (userResponse == "yes")
            {
                double sum = 0, avg = 0;
                
                for (int i = 0; i < rightLights.Length; i++)
                {
                    sum += rightLights[i];
                }
                avg = sum / rightLights.Length;
                Console.WriteLine("The sum is : " + sum);
                Console.WriteLine("The average is : " + avg);
            }

            else
            {
                Console.WriteLine("I see. Not everyone cares for that information.");
            }
            DisplayContinuePrompt();
        }

        static double[] DataRecorderDisplayGetDataLeftLights(int numberOfDataPoints, double dataPointFrequency, Finch fred)
        {
            double[] leftLights = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Left Light Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints} points");
            Console.WriteLine($"Data point frequency: {dataPointFrequency} seconds");
            Console.WriteLine();
            Console.WriteLine("Fred the Finch robot is ready to begin recording the left light sensor data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                leftLights[index] = fred.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {leftLights[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                fred.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            Console.WriteLine("The data readings are complete.");
            return leftLights;
        }

        static double[] DataRecorderDisplayGetDataRightLights(int numberOfDataPoints, double dataPointFrequency, Finch fred)
        {
            double[] rightLights = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Right Light Data");

            Console.WriteLine($"Number of data points: {numberOfDataPoints} points");
            Console.WriteLine($"Data point frequency: {dataPointFrequency} seconds");
            Console.WriteLine();
            Console.WriteLine("Fred the Finch robot is ready to begin recording the right light sensor data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                rightLights[index] = fred.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {rightLights[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                fred.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            Console.WriteLine("The data readings are complete.");
            return rightLights;
        }

        static void DataRecorderDisplayDataTemps(double[] temperatures)
       {
           DisplayScreenHeader("Show Data");

           Console.WriteLine("Recording #".PadLeft(15) + "Temp".PadLeft(15));
           Console.WriteLine("---------".PadLeft(15) + "---------".PadLeft(15));

           for (int index = 0; index < temperatures.Length; index++)
           {
               Console.WriteLine(
               (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15));
           }
                        DisplayContinuePrompt();
        }

        /// <summary>
        /// get data points from robot
        /// </summary>
        /// <returns>data points</returns>
        static double[] DataRecorderDisplayGetDataTemps(int numberOfDataPoints, double dataPointFrequency, Finch fred)
        {
           double[] temperatures = new double[numberOfDataPoints];

           DisplayScreenHeader("Get Data");

           Console.WriteLine($"Number of data points: {numberOfDataPoints} points");
           Console.WriteLine($"Data point frequency: {dataPointFrequency} seconds");
           Console.WriteLine();
           Console.WriteLine("Fred the Finch robot is ready to begin recording the temperature data.");
           DisplayContinuePrompt();

           for (int index = 0; index < numberOfDataPoints; index++)
           {
                temperatures[index] = fred.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                fred.wait(waitInSeconds);
           }

           DisplayContinuePrompt();
           Console.WriteLine("The data readings are complete.");
            return temperatures;
        }

        /// <summary>
        /// get frequency of data points from user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetNumberOfDataPointFrequency()
        {
            double DataPointFrequency;
            string userResponse;
            bool validResponse = false;


            DisplayScreenHeader("Data Point Frequency");
            do
            {
                Console.WriteLine("Frequency of data points in seconds: ");
                userResponse = Console.ReadLine();              
                //
                // test response for a number and provide feedback
                //
                if (double.TryParse(userResponse, out DataPointFrequency))
                {
                    //
                    // test response for a positive number and provide feedback
                    //
                    if (DataPointFrequency <= 0)
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter a positive number.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }

            } while (!validResponse);
            
            Console.WriteLine($"The data readings will occur every {DataPointFrequency} seconds.");
            DisplayContinuePrompt();

            return DataPointFrequency;
        }

        /// <summary>
        /// Get number of data points from user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;
            bool validResponse = false;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                Console.WriteLine("Number of data points: ");
                userResponse = Console.ReadLine();
                //
                // test response for a number and provide feedback
                //
                if (int.TryParse(userResponse, out numberOfDataPoints))
                {
                    //
                    // test response for a positive number and provide feedback
                    //
                    if (numberOfDataPoints <= 0)
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter a positive number.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }

            } while (!validResponse);
                       
            Console.WriteLine($"The temperature will be measured {numberOfDataPoints} times.");
            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        #endregion

        #region LIGHT ALARM

        static void AlarmSystemDisplayMenuScreen(Finch fred)
        {
            Console.CursorVisible = true;

            bool quitLightAlarmMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxTresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor(fred);
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxTresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, fred);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(fred, sensorsToMonitor, rangeType, minMaxTresholdValue, timeToMonitor);
                        break;

                    case "q":
                        quitLightAlarmMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitLightAlarmMenu);




        }

        static void LightAlarmSetAlarm(Finch fred, string sensorsToMonitor, string rangeType, int minMaxTresholdValue, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            double currentLightSensorValue = 0;
            DisplayScreenHeader("Set Alarm");
            Console.WriteLine();
            Console.WriteLine($"Sensors to Monitor: {sensorsToMonitor}");
            Console.WriteLine($"Range Type: {rangeType}");
            Console.WriteLine($"Min/Max Threshold Value: {minMaxTresholdValue}");
            Console.WriteLine($"Time to Monitor: {timeToMonitor}");
            Console.WriteLine();
            DisplayContinuePrompt();
            
            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = fred.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = fred.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (fred.getRightLightSensor() + fred.getLeftLightSensor()) / 2;
                        break;

                    case "temperature":
                        currentLightSensorValue = (fred.getTemperature());
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxTresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxTresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                }
                fred.wait(1000);
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                fred.noteOn(400);
                fred.wait(500);
                fred.noteOff();
                Console.WriteLine($"The {rangeType} threshold value of {minMaxTresholdValue} was exceeded by the current sensor value of {currentLightSensorValue}.");
            }
            else
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxTresholdValue} was not exceeded.");
            }

            DisplayContinuePrompt();
        }

        static int LightAlarmSetTimeToMonitor()
        {
            int timeToMonitor;
            string userResponse;
            bool validResponse = false;
            DisplayScreenHeader("Time to Monitor");
            Console.WriteLine();
            //prompt for and validate value
            //get value, validate, echo, convert to int, and return value
            do
            {
                Console.WriteLine($"Enter the time to monitor in seconds:");
                userResponse = Console.ReadLine();
                // test response for a number and provide feedback
                if (int.TryParse(userResponse, out timeToMonitor))
                {
                    // test response for a positive number and provide feedback
                    if (timeToMonitor <= 0)
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter a positive number.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }

            } while (!validResponse);

            //echo value
            Console.WriteLine($"Fred will monitor for {timeToMonitor} seconds.");
            DisplayContinuePrompt();
            return timeToMonitor;
        }

        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch fred)
        {
            int minMaxThresholdValue;
            string userResponse;
            bool validResponse = false;
            DisplayScreenHeader("Minimum/Maximum Threshold Value");
            //prompt user
            Console.WriteLine($"Left light sensor ambient value: {fred.getLeftLightSensor()}");
            Console.WriteLine($"Right light sensor ambient value: {fred.getRightLightSensor()}");
            Console.WriteLine($"Temperature sensor ambient value: {fred.getTemperature()}");
            Console.WriteLine();      
            
            //get value, validate, echo, convert to int, and return value
            do
            {
                Console.WriteLine($"Enter the desired {rangeType} sensor value:");
                userResponse = Console.ReadLine();
                // test response for a number and provide feedback
                if (int.TryParse(userResponse, out minMaxThresholdValue))
                {
                    // test response for a positive number and provide feedback
                    if (minMaxThresholdValue <= 0)
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter a positive number.");
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }

            } while (!validResponse);

            Console.WriteLine($"The {rangeType} sensor value is set to {minMaxThresholdValue}.");
            DisplayContinuePrompt();
            return minMaxThresholdValue;
        }
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;
            //display header
            DisplayScreenHeader("Range Type");
            //prompt user
            Console.Write("Select the range type, {minimum, maximum}:");
            rangeType = Console.ReadLine().ToLower();

            while (rangeType != "minimum" && rangeType != "maximum")
            {
                Console.WriteLine("I appears you did not give a valid response. Please try again.");

                Console.WriteLine("Select therange type, {minimum, maximum}:");
                rangeType = Console.ReadLine().ToLower();
            }
                        
            // process user response            
            if (rangeType == "minimum")
            {
                Console.WriteLine($"Fred's range type is now set to {rangeType}.");
            }
            else if (rangeType == "maximum")
            {
                Console.WriteLine($"Fred's range type is now set to {rangeType}.");
            }
            else
            {
                Console.WriteLine($"Please set Fred's range type.");
            }
            
            DisplayContinuePrompt();

            return rangeType;
        }

        static string LightAlarmDisplaySetSensorsToMonitor(Finch fred)
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Sensors to Monitor");
            //prompt user
            Console.WriteLine($"Left light sensor ambient value: {fred.getLeftLightSensor()}");
            Console.WriteLine($"Right light sensor ambient value: {fred.getRightLightSensor()}");
            Console.WriteLine($"Temperature sensor ambient value: {fred.getTemperature()}");
            Console.WriteLine();
            Console.Write("Select the sensors to be monitored, {left, right, both, or temperature}:");
            //validate and echo response
            sensorsToMonitor = Console.ReadLine().ToLower();
            
            while (sensorsToMonitor != "left" && sensorsToMonitor != "right" && sensorsToMonitor != "both" && sensorsToMonitor != "temperature")
            {
                Console.WriteLine("I appears you did not give a valid response. Please try again.");

                Console.WriteLine("Select the sensors to be monitored, {left, right, both, or temperature}:");
                sensorsToMonitor = Console.ReadLine().ToLower();
            }

            //
            // process user response
            //
            if (sensorsToMonitor == "left")
            {
                Console.WriteLine($"Fred will now monitor the {sensorsToMonitor} sensor.");
            }
            else if (sensorsToMonitor == "right")
            {
                Console.WriteLine($"Fred will now monitor the {sensorsToMonitor} sensor.");
            }
            else if (sensorsToMonitor == "both")
            {
                Console.WriteLine($"Fred will now monitor {sensorsToMonitor} light sensors.");
            }
            else if (sensorsToMonitor == "temperature")
            {
                Console.WriteLine($"Fred will now monitor the {sensorsToMonitor} sensor.");
            }
            else
            {
                Console.WriteLine("Fred needs to know what sensors to use.");
            }

            

            DisplayMenuPrompt("Light Alarm");


            return sensorsToMonitor;
        }



        #endregion
        
        #region USER PROGRAMMING
        static void UserProgrammingDisplayMenuScreen(Finch fred)
        {
            string menuChoice;
            bool quitUserProgrammingMenu = false;

            //
            // tuple (basket) to store all three command parameters 
            //
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            // Declare List of enum 

            List<Command> commands = new List<Command>();



            do
            {
                // display header
                DisplayScreenHeader("User Programming Menu");

                //
                // display and get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(fred, commands, commandParameters);
                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgrammingMenu);


        }

        static void UserProgrammingDisplayExecuteFinchCommands(Finch fred, List<Command> commands, 
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            //display header
            DisplayScreenHeader("Execute Commands");

            Console.WriteLine("Fred will now execute the listed commands.");
            DisplayContinuePrompt();
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        fred.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        fred.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        fred.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        fred.wait(waitMilliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandFeedback = $"Temperature: {fred.getTemperature().ToString("n2")}";
                        break;

                    case Command.TURNRIGHT:
                        fred.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        fred.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        fred.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        fred.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.DONE:
                        commandFeedback = Command.DONE.ToString();
                        break;

                }

                Console.WriteLine($"{commandFeedback}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            //header
            DisplayScreenHeader("View Commands");
            //display stored commands
            foreach (Command command in commands)
            {
                Console.WriteLine($"{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            //header
            DisplayScreenHeader("Add Commands");
            //instructions

            Console.WriteLine("List of All Commands:");
            Console.WriteLine();
            Console.WriteLine("none, moveforward, movebackward, stopmotors, wait, turnright,\n turnleft, ledon, ledoff, gettemperature, done");

            Console.WriteLine();
            //loop to prompt, validate, add to list
            while (command != Command.DONE)
            {
                Console.WriteLine("Enter Command: ");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid command from the approved list.");
                    Console.WriteLine();
                }
            }
            DisplayMenuPrompt("User Programming");
        }

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            string userResponse;
            bool validResponse = false;
            DisplayScreenHeader("Enter Command Parameters");
            //
            //prompt, get, validate user response
            //
            do
            {
                Console.WriteLine("Please Enter Motor Speed (1-255): ");
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out commandParameters.motorSpeed))
                {
                    if (commandParameters.motorSpeed >= 1 && commandParameters.motorSpeed <= 255)
                    {
                        validResponse = true; 
                    }
                    else
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter an integer within the valid range.");
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }
            } while (!validResponse);
            //
            // process user response
            //
            Console.WriteLine($"Motor speed now set to {commandParameters.motorSpeed}.");
            validResponse = false;
            //
            //prompt, get, validate user response
            //
            do
            {
                Console.WriteLine("Please Enter LED Brightness (1-255): ");
                userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out commandParameters.ledBrightness))
                {
                    if (commandParameters.ledBrightness >= 1 && commandParameters.ledBrightness <= 255)
                    {
                        validResponse = true; 
                    }
                    else
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter an integer within the valid range.");
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }
            } while (!validResponse);
            //
            // process user response
            //
            Console.WriteLine($"LED brightness now set to {commandParameters.ledBrightness}.");
            validResponse = false;
            //
            //prompt, get, validate user response
            //
            do
            {
                Console.WriteLine("Please Enter Wait Time in Seconds (1-10): ");
                userResponse = Console.ReadLine();
                if (double.TryParse(userResponse, out commandParameters.waitSeconds))
                {
                    if (commandParameters.waitSeconds >= 1 && commandParameters.waitSeconds <= 10)
                    {
                        validResponse = true; 
                    }
                    else
                    {
                        Console.WriteLine("I appears you did not give a valid response. Please enter an integer within the valid range.");
                    }
                }
                else
                {
                    Console.WriteLine("It appears that you did not provide a number.");
                }
            } while (!validResponse);
            //
            // process user response
            //
            Console.WriteLine($"Wait time now set to {commandParameters.waitSeconds}.");
            DisplayMenuPrompt("User Programming");
            return commandParameters;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="fred">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch fred)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from Fred the Finch robot.");
            DisplayContinuePrompt();

            fred.disConnect();

            Console.WriteLine("\tFred the Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="fred">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch fred)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Fred the Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = fred.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            fred.setLED(0, 0, 0);
            fred.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine("\tWelcome to the world of Fred the Finch!");
            Console.WriteLine("\tFred shows off by dancing, singing, and recording data for you.");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Fred's Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
         
    }
}
