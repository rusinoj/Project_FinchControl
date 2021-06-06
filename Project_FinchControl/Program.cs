using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Program to control finch robot actions through use of menus.
    // Application Type: Console
    // Author: Rusinowski, Jack
    // Dated Created: 6/6/2021
    // Last Modified: 6/6/2021
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
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
        }

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
                Console.WriteLine("\tf) Disconnect Finch Robot");
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

        #region CONSTRUCTION

        private static void UserProgrammingDisplayMenuScreen(Finch fred)
        {
            DisplayScreenHeader("User Programming");
            Console.WriteLine("This module is currently under development.");
            Console.WriteLine("Thank you for your patience as the guy writing this figures out what he's doing.");

            DisplayContinuePrompt();
        }

        private static void AlarmSystemDisplayMenuScreen(Finch fred)
        {
            DisplayScreenHeader("Alarm System");
            Console.WriteLine("This module is currently under development.");
            Console.WriteLine("Thank you for your patience as the guy writing this figures out what he's doing.");

            DisplayContinuePrompt();
        }

        private static void DataRecorderDisplayMenuScreen(Finch fred)
        {
            DisplayScreenHeader("Data Recorder");
            Console.WriteLine("This module is currently under development.");
            Console.WriteLine("Thank you for your patience as the guy writing this figures out what he's doing.");

            DisplayContinuePrompt();
        }

        #endregion
    }
}
