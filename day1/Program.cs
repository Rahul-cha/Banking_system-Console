using Day1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace day1
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int UID;
            while (true)
            {
                var check = false;
                Console.WriteLine("Enter Username");
                string? UserName = Console.ReadLine();

                Console.WriteLine("Enter Password");
                string? Password = Console.ReadLine();

                string jsonFile = File.ReadAllText(@"A:\Rahul laptop\intern\day1\day1\User.json");
                string accountdetailstext = File.ReadAllText(@"A:\Rahul laptop\intern\day1\day1\Accounts.json");
             

                var Person = JsonSerializer.Deserialize<List<User>>(jsonFile);
                var Accountdetials = JsonSerializer.Deserialize<List<AccountDetailsModel>>(accountdetailstext);
            
                if (Accountdetials != null)
                {
                    if (Person != null)
                    {

                        foreach (var items in Person)
                        {

                            if (items.UserName == UserName && items.Password == Password)
                            {
                                check = true;
                                UID = Convert.ToInt32(items.User_Id);
                                //Username and Password is correct
                                Console.WriteLine(" \r\n You are on it");


                                /*Checking the user type
                                string jsonFile2 = File.ReadAllText(@"C:\Users\acer\source\repos\intern\day1\day1\credentials2.json");
                                Console.WriteLine(jsonFile2);
                                //   Console.WriteLine(jsonFile.GetType()); */


                                if (items.User_Type == "admin")
                                {
                                    Console.WriteLine(" \n Welcome admin \n");
                                    var admin = new Admin(Person, Accountdetials);

                                    admin.AdminOption(Convert.ToInt32(items.User_Id));


                                }
                                else if (items.User_Type == "customer")
                                {
                                    Console.WriteLine("Welcome user \n");
                                    var customer = new Customer(Person, Accountdetials, Convert.ToInt32(UID));
                                    customer.Customeroption();


                                    //customer.Viewaccount(Convert.ToInt32(UID));
                                    //  customer.Customeroption(Convert.ToInt32(items.User_Id));


                                }
                                break;
                            }


                            /*  Console.WriteLine(Person.UserName);
                            Console.WriteLine(Person.Password);
                            Console.WriteLine(Person.User_Type);
                           */




                        }
                        if(check == true)
                        {
                            break;
                        }
                        Console.WriteLine(" \r\n Your Username or password is invalid");



                    }
                }



            }
    }



      


}
   }

