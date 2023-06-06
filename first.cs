using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine("Enter Username");
                string? UserName = Console.ReadLine();

                Console.WriteLine("Enter Password");
                string? Password = Console.ReadLine();

                string jsonFile2 = File.ReadAllText(@"C:\Users\acer\source\repos\intern\day1\day1\credentials2.json");
                Console.WriteLine(jsonFile2);
                //   Console.WriteLine(jsonFile.GetType());
                /*
                                var Person2 = JsonSerializer.Deserialize<List<User2>>(jsonFile2);*/


                if (UserName == "roey1" && Password == "singup")
                {
                    //individual either un or pw wrong bhayo bhane xutinu paryo
                    Console.WriteLine("You are on it");
                    break;
                }
                Console.WriteLine("You are invalid");


            }

        }
    }
}

//day 2 
/*
// See https://aka.ms/new-console-template for more information
using Day1;
using System;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

while (true)
{

    Console.WriteLine("Enter Username");
    string? UserName = Console.ReadLine();

    Console.WriteLine("Enter Password");
    string? Password = Console.ReadLine();

    string jsonFile = File.ReadAllText(@"C:\Users\acer\source\repos\intern\day1\day1\credentials.json");
    Console.WriteLine(jsonFile.GetType());

    var Person = JsonSerializer.Deserialize<List<User>>(jsonFile);

   
        foreach (var items1 in Person)
        {
            if (items1.UserName == UserName && items1.Password == Password)
            {
                //Username and Password is correct
                Console.WriteLine(" \r\n You are on it");
                Console.WriteLine(" \r\n \r\n ");

                //Checking the user type
                string jsonFile2 = File.ReadAllText(@"C:\Users\acer\source\repos\intern\day1\day1\credentials2.json");
                Console.WriteLine(jsonFile2);
                //   Console.WriteLine(jsonFile.GetType());
/*
                var Person2 = JsonSerializer.Deserialize<List<User2>>(jsonFile2);
           
                    if (items1.User_Type == "admin")
                    {
                        Console.WriteLine("Please select an option:");
                        Console.WriteLine("1 -Customer Summary");
                        Console.WriteLine("2- Financial Forecast");
                        Console.WriteLine("3- Transfer Money - GUI");
                        Console.WriteLine("4- Account Management - GUI");
                        Console.WriteLine(" \r\n Enter a number to select your option: ");
                        string? Option0 = Console.ReadLine();
                    }
                    if (items1.User_Type == "customer")
                    {
                        Console.WriteLine("Please select an option:");
                        Console.WriteLine("1 - View account");
                        Console.WriteLine("2- View summary");
                        Console.WriteLine("3- Quit");
                        Console.WriteLine(" \r\n Enter a number to select your option: ");
                        string? Option1 = Console.ReadLine();
                    }
                }

            }
                    /*  Console.WriteLine(Person.UserName);
                    Console.WriteLine(Person.Password);
                    Console.WriteLine(Person.User_Type);
                   
                    break;
                }
                else if (items1.UserName != UserName)
                {
                    Console.WriteLine(" \r\n Your Username is invalid");
                }
                else if (items1.UserName == UserName && items1.Password != Password)
                {
                    Console.WriteLine(" \r\n Your Password is incorrect");
                }

            }
        } 



*/