using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.IO;

namespace Health
{

    class Program
    {



        static void Main(string[] args)
        {
            Welcome();
            Files();
            Login();
        }

        static void Files()
        {
            string pathHealthData = @"C:\Users\amalie.drue\Documents\Skole\Health\HealthData.txt";
            string pathLogin = @"C:\Users\amalie.drue\Documents\Skole\Health\LoginData.txt";
            if (!File.Exists(pathHealthData)) { File.CreateText(pathHealthData); }
            if (!File.Exists(pathLogin)) { File.CreateText(pathLogin); }

        }

        static void Welcome()
        {
            Console.WriteLine("Welcome to your daily health info tracker! ");
            Console.WriteLine("Please CREATE LOGIN or LOGIN to continue....");
        }

        static void Login() 
        {

            string pathLogin = @"C:\Users\amalie.drue\Documents\Skole\Health\LoginData.txt";

            Console.WriteLine("USERNAME: ");
            string username = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine().Trim().ToLower();
            string login = username + password;

            Console.WriteLine("(C)CREATE LOGIN INFORMATION  \n(L)LOGIN?");
            string userCreate = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                Console.WriteLine("No input. Try Again");
                Login();
            }

            if (userCreate == "c")
            {
                if (File.Exists(pathLogin))
                {
                    StreamWriter sw = File.AppendText(pathLogin);
                    sw.WriteLine(login);
                    sw.Close();
                }
            }

            if (userCreate == "l")
            {
                if (File.Exists(pathLogin))
                {



                    if (File.ReadAllText(pathLogin).Contains(login))
                    {
                        Menu();
                    }

                    else
                    {
                        Console.WriteLine("Username or password incorrect, try again.");
                        Login();
                    }



                }
            }
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Please choose one of the options below ");
            Console.WriteLine("1. Submit data \n2. See statistics \nX: Close App ");

            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    InputData();
                    break;
                case "2":
                    ShowData();
                    break;
                default:
                    Console.WriteLine("Error: Choose between menu options 1-2. ");
                    break;
            }

        }


        static void InputData()
        {
            Console.Clear();

            string pathHealthData = @"C:\Users\amalie.drue\Documents\Skole\Health\HealthData.txt";

            Console.WriteLine("Input your data here: ");

            Console.WriteLine("Weight: ");
            string wei = Console.ReadLine();
            Console.WriteLine("Steps: ");
            string steps = Console.ReadLine();
            Console.WriteLine("Sleep: ");
            string sleep = Console.ReadLine();

            string healthData = String.Join("|", wei, steps, sleep);

            if (File.Exists(pathHealthData))
            {
                StreamWriter sw = File.AppendText(pathHealthData);
                sw.WriteLine(healthData);
                sw.Close();
            }


        }

        static void ShowData()
        {
            Console.WriteLine("Here is your weight, steps and sleephours.");
            string[] data = File.ReadAllLines(@"C:\Users\amalie.drue\Documents\Skole\Health\HealthData.txt");


            foreach (string line in data)
            {
                Console.Write("\n" + line);
            }

            Console.WriteLine("\nPress anykey to exit.");
            Console.ReadKey();

        }

    }
}
