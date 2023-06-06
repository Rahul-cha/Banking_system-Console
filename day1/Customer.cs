using Day1;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace day1
{
    public class Customer
    {

        private List<User> _users;
        private List<AccountDetailsModel> _accountdetails;
        private int _id;
        public Customer(List<User> Customer, List<AccountDetailsModel> Accountdetials, int uid)
        {
            _users = Customer;
            _accountdetails = Accountdetials;
            _id = uid;
        }

        Validation validation = new Validation();

        public string Customeroption()
        {
            int options;
            while (true) { 
            

                Console.WriteLine("Please select an option:\n 1 - View account \n 2- View summary \n 3- Quit \n Enter a number to select your option: ");
            // var validation = new Validation();

            options = validation.intergervalidation();
           // bool isvalid = validation.rangervalidatoin(options, 3);

             bool isvalid = validation.rangervalidatoin(options, 3);
               if (isvalid == true)
               {
                   break;
               }


           } 

            switch (options)
            {
                case 1:
                    Viewaccount();
                    break;

                case 2:
                    ViewSummary();
                    break;

                case 3:
                    Quit();
                    break;

                default:
                    Console.WriteLine("\n Enter a valid option \n");
                    Customeroption();
                    break;

            }

            return "0";

        }

        public void Viewaccount()
        {

            var ListOfUserAccount = new List<AccountDetailsModel>();

            Console.WriteLine("\n -- Account list -- \n Please select an option ");

            var count = 0;

            foreach (var item in _accountdetails)
            {
                if (Convert.ToInt32(item.User_Id) == _id)
                {

                    if (item.AccountType == "Saving Account")
                    {


                        //++count;
                        count += 1;
                        Console.WriteLine(count + " - Saving Account: \n Balance:" + item.Balance + "\n" + "Account ID: " + item.Account_ID + "\n");


                    }
                    //if (item.AccountType == "Current Account")
                    else
                    {
                        count += 1;
                        Console.WriteLine(count + " - Current Account: \n Balance:" + item.Balance + "\n" + "Account ID: " + item.Account_ID + "\n");
                    }

                    ListOfUserAccount.Add(item);
                }

            }
            int choose;
            while (true)
            {
                Console.WriteLine("Enter a number to select your option");

                choose = validation.intergervalidation();
                bool isvalid = validation.rangervalidatoin(choose, ListOfUserAccount.Count);
                if(isvalid == true)
                {
                    break;
                }
               
            }
            //int choose = Convert.ToInt32(Console.ReadLine());
            //  var lists = ListOfUserAccount[choose - 1];

            transactions(ListOfUserAccount[choose - 1]);
          

        }

        void transactions(AccountDetailsModel account)
        {
            
            //throw new AccountDetailsModel account;
            Console.WriteLine("You selected " + " - " + account.AccountType + ": " + account.Balance);
            int option;
            while (true)
            {
                Console.WriteLine("Please select an option: \n 1 - Deposit \n 2 - Withdraw \n 3 - Go back \n Enter a number to select your option:  ");

                option = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(option, 3);
                if(isinvalid == true)
                {
                    break;
                }
            }
            //var option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    Deposit(account.Account_ID, account.User_Id, account);
                    break;
                case 2:
                    Withdraw(account);
                    break;
                case 3:
                    goback();
                    break;
                default:
                    Console.WriteLine("\n Enter a valid Option");
                    transactions(account);
                    break;

            }
        }


            void Withdraw(AccountDetailsModel account)
            {
            Console.WriteLine("enter your amount");
            
                
                decimal withdrawl = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("BALANCE = " + account.Balance + "\n");

                decimal afterwithdrawlamount = Convert.ToDecimal(account.Balance) - withdrawl;
                Console.WriteLine("after withdrawl = " + afterwithdrawlamount);

            account.Balance = afterwithdrawlamount.ToString();

            string accountdetailstext = @"C:\Users\acer\source\repos\intern\day1\day1\Accounts.json";
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(_accountdetails, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(accountdetailstext, output);

        }

            void goback()
            {
                // transactions(account);
                Viewaccount();

            }

        

        void Deposit(string accountId, string userId, AccountDetailsModel account)
        {
            decimal afterdepositamount = 0;


            if (accountId == account.Account_ID && userId == account.User_Id)
            {
                Console.WriteLine("enter your amount");
                decimal depositamount = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("BALANCE = " + Convert.ToString(account.Balance) + "\n");

                afterdepositamount = Convert.ToDecimal(account.Balance) + depositamount;

                Console.WriteLine("after deposit = " + afterdepositamount);

            }

            foreach(var items in _accountdetails)
            {
                if(items.Account_ID==accountId && items.User_Id == userId)
                {
                    items.Balance = afterdepositamount.ToString();
                }
            }




            string accountdetailstext = @"C:\Users\acer\source\repos\intern\day1\day1\Accounts.json";
       

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(_accountdetails, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(accountdetailstext, output);

            //  var newData = JObject.ReadFrom(AccountDetailsModel);
            /* var newData = JsonObject.GetValue<T>("Balance") as JArray;
             var newd = JObject.Parse(Convert.ToString(afterdepositamount));
             newData.Add(newd);

             jsonObj["Balance"] = newData;
             string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                    Newtonsoft.Json.Formatting.Indented);
             File.WriteAllText(jsonFile, newJsonResult);
*/
        }


        public void ViewSummary()
        {
            var Listsummary = new List<ViewSummary>();
            int accountcount = 0;
            decimal cbalance = 0;
            var Address = "NA";
            decimal sbalance = 0;
            decimal totalbalance = 0;

            foreach (var item in _accountdetails)
            {
                if (Convert.ToInt32(item.User_Id) == _id)
                {
                    accountcount++;
                    if (Convert.ToInt32(item.User_Id) == _id)
                    {
                        if (item.AccountType == "Saving Account")
                        {
                            sbalance += Convert.ToInt32(item.Balance);
                        }
                        if (item.AccountType == "Current Account")
                        {
                            cbalance += Convert.ToInt32(item.Balance);
                        }
                        totalbalance = sbalance + cbalance;
                    }
                }

                // Numberofaccountinbank = accountcount;
            }
            var Summary = new ViewSummary()
            {
                Numberofaccountinbank = accountcount,
                TotalBalance = totalbalance,
                Address = Address,
            };
            Listsummary.Add(Summary);
            foreach(var i in Listsummary)
            {
                Console.WriteLine("Number of Bank account : " + i.Numberofaccountinbank + "\n" + "Total Balance: " + i.TotalBalance + "\n" + "Address : " + i.Address);
            }
        }
        //listofviewsummary.Add(vsummary);


        // Console.WriteLine(" Displaying the following information:  \n Total number of accounts in the bank :   \n Total balance of all accounts:  \n Address  ");
        public void Quit()
        {

        }
    }



}

