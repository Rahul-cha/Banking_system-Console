using Day1;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace day1
{


    public class Admin
    {

        private List<User> _users;
        private List<AccountDetailsModel> _accountdetails;
        public Admin(List<User> person, List<AccountDetailsModel> Accountdetials)
        {
            _users = person;
            _accountdetails = Accountdetials;
        }



        Validation validation = new Validation();


        public string AdminOption(int Option1)
        {

          
            while (true)
            {
                Console.WriteLine("Please select an option: \n 1 -Customer Summary \n 2- Financial Forecast \n 3- Transfer Money - GUI \n 4- Account Management - GUI \n 5- Quit \n Enter a number to select your option: ");

                Option1 = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(Option1, 5);
                if(isinvalid == true)
                {
                    break;
                }
            }


           



            switch (Option1)
            {
                case 1:
                    CustomerSummary();
                    break;
                case 2:
                    FinancialForecast();
                    break;
                case 3:
                    TransferMoney();
                    break;

                case 4:
                    AccountManagement();
                    break;

                case 5:
                    Quit();
                    break;

                default:
                    Console.WriteLine("\n Choose a proper option : \n");
                    AdminOption(Option1); 
                    break;



            }
            return "22";
        }


        public void CustomerSummary()
        {
            Console.WriteLine("Listing all customer's information, for each customer \n");

            //Console.WriteLine(jsonFile3.GetType());

            foreach (var item in _accountdetails)
            {
                Console.WriteLine("User_ID : " + item.User_Id);

                if (item.AccountType == "Current Account")
                {
                    Console.WriteLine("Overdarft: " + item.OverdraftorInterest);
                }

                else
                {
                    Console.WriteLine("Interest: " + item.OverdraftorInterest);
                }
                Console.WriteLine("Account ID:" + item.Account_ID);
                Console.WriteLine("Account Type: " + item.AccountType);
                Console.WriteLine("\n");
                /*    Console.WriteLine(item.Balance);
                    Console.WriteLine(item.Overdraft);
                    Console.WriteLine(item.Interest_Rate); */
            }


        }
        //   Console.WriteLine(CPerson.Name");


        public void FinancialForecast()
        {



            var listoffinancialforcast = new List<FinancialForcastModel>();



            foreach (var useritem in _users)//search in a
                                            //llusers
            {

                if (useritem.User_Type != "admin")
                {

                    int accountcount = 0;
                    decimal totalbalance = 0;
                    decimal totalbalanceafteryear = 0;

                    string UserName = useritem.UserName;

                    foreach (var accountitem in _accountdetails)
                    {
                        if (useritem.User_Id == accountitem.User_Id)
                        {
                            decimal balanceafterayear = 0;
                            accountcount++;
                            totalbalance = totalbalance + Convert.ToDecimal(accountitem.Balance);

                            if (accountitem.AccountType == "Saving_Account")
                            {
                                balanceafterayear = Convert.ToDecimal(accountitem.Balance) + (Convert.ToDecimal(accountitem.Balance) * 1 * Convert.ToDecimal(accountitem.OverdraftorInterest)) / 100;
                            }
                            else
                            {
                                balanceafterayear = Convert.ToDecimal(accountitem.Balance);
                            }

                            totalbalanceafteryear = totalbalance + balanceafterayear;


                        }
                    }
                    var financialforcast = new FinancialForcastModel()
                    {
                        Name = UserName,
                        Totalamount = totalbalance,
                        Totalamountafterayear = totalbalanceafteryear,
                        Numberofaccountinbank = accountcount,
                    };

                    listoffinancialforcast.Add(financialforcast);

                }
            }
            foreach (var i in listoffinancialforcast)
            {
                Console.WriteLine("Name: " + i.Name + "\n" + "Number of account: " + i.Numberofaccountinbank + "\n" + "Total Amount: " + i.Totalamount + "\n" + "Total amount after a year:  " + i.Totalamountafterayear + "\n");



            }
        }


        public void TransferMoney()
        {
            Console.WriteLine("\n -- ACCOUNTS -- \n");

            int count = 0;
            var ListOfUserAccounts = new List<AccountDetailsModel>();

            foreach (var i in _accountdetails)
            {



                count += 1;
                Console.WriteLine(count + " - User Id: " + i.User_Id + "\n" + "Account ID: " + i.Account_ID + "\n" + "Balance: " + i.Balance + "\n");
                // ? 
                ListOfUserAccounts.Add(i);

            }

            int acc1;
            int acc2;
            while (true)
            {

                Console.WriteLine("Please select a user account from which the money is to be transfered\n");

                acc1 = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(acc1, ListOfUserAccounts.Count);
                if (isinvalid == true)
                {
                    break;
                }
            }
           // int acc1 = Convert.ToInt32(Console.ReadLine());
            

                while (true)
                {
                    Console.WriteLine("Please select a user account in which the money is to be transfered\n");


                    acc2 = validation.intergervalidation();
                    bool isinvalid = validation.rangervalidatoin(acc2, ListOfUserAccounts.Count);
                    if (isinvalid == true)
                    {
                        break;
                    }
                }

                /*  Console.WriteLine("\n Please select a user account in which the money is to be transfered\n");
                  try
                  {
                      acc2 = Convert.ToInt32(Console.ReadLine());
                  }
                  catch
                  {
                      Console.WriteLine("the input should be an integer!!");
                      continue;

                  }
                  if (acc2<1 || acc2 > _accountdetails.Count)
                  {
                      Console.WriteLine("The input is out of bound!!");
                      continue;
                  }//true*/

               
            Console.WriteLine("Enter the amount you want to transfer : \n");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
            AccSendMoney(ListOfUserAccounts[acc1 - 1], transferAmount);
            AccGetMoney(ListOfUserAccounts[acc2 - 1], transferAmount);
            JsonWrite jsonWrite = new JsonWrite();
            jsonWrite.writejsonfile(_accountdetails, _users);

            // euta acc ma ghatnu paryo arko ma increase (twoo different functions ??)

        }
        public void AccSendMoney(AccountDetailsModel accounts, decimal transferAmount)
        {
            Console.WriteLine("You selected the user account with \n Account ID: " + accounts.Account_ID + "\n" + "Current Balance: " + accounts.Balance);
            int currentBalance = Convert.ToInt32(accounts.Balance);



            // Console.WriteLine("Balance after transfer: " + finalAmount);
            foreach (var i in _accountdetails)
            {
                if (i.Account_ID == accounts.Account_ID)
                {
                    i.Balance = (Convert.ToDecimal(i.Balance) - transferAmount).ToString();
                }
            }



            //Admin p = new Admin();
            //p.AccGetMoney(Convert.ToInt32(finalAmount));

            //dui time kata dukheko teta kapada le pusera two drops - daily two times (morning day) - 2 days lagaune 3 days gap loop
            // arko chai same as before
            //next tuesday 11am 

        }

        public void AccGetMoney(AccountDetailsModel accounts, decimal transferAmount)
        {

            Console.WriteLine(" \n ---Notification --- \n \n The money has been transfered to Account Id: " + accounts.Account_ID + "\n");
            foreach (var i in _accountdetails)
            {
                if (i.Account_ID == accounts.Account_ID)
                {
                    i.Balance = (Convert.ToDecimal(i.Balance) + transferAmount).ToString();
                }
            }



        }

        public void AccountManagement()
        {
            int option;
            while (true)
            {
                Console.WriteLine(" \n Choose an option: \n 1- Add a new account to the customer. \n 2- close(delete) an existing account");


                option = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(option, 2);
                if (isinvalid == true)
                {
                    break;
                }
            }



            switch (option)
            {
                case 1:
                    CreateAccount();
                    break;

                case 2:
                    DeleteAccount();
                    break;
            }


        }

        //Need to check
        public void CreateAccount()
        {
            int count = 0;
            var ListOfUserAccount = new List<User>();

            foreach (var i in _users)
            {

                if (i.User_Type != "admin")
                {

                    count += 1;
                    Console.WriteLine(count + " - User Id: " + i.User_Id + "\n" + "User Name: " + i.UserName + "\n");
                    // ? 
                    ListOfUserAccount.Add(i);
                }
            }

            int select;

            while (true)
            {
                Console.WriteLine("Select an account : \t ");

                select = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(select, ListOfUserAccount.Count);
                if (isinvalid == true)
                {
                    break;
                }
            }


            Selection(ListOfUserAccount[select - 1]);


        }
        public void Selection(User user)
        {


            int AccType;
            Console.WriteLine("You selected Account with User Id :" + user.User_Id + "\n ");
            while (true)
            {
                Console.WriteLine("Enter Account Type: \n 1 - Savings Account \n  2- Current Account ");


                AccType = validation.intergervalidation();
                bool isinvalid = validation.rangervalidatoin(AccType,2 );
                if (isinvalid == true)
                {
                    break;
                }
            }



           
            /* bool hascurrentaccount = false;

             foreach(var items in _accountdetails)
             {
                 if (items.User_Id == user.User_Id)
                 {

                     if (items.AccountType == "curentaccount")
                     {
                         hascurrentaccount = true;
                     }



                 }
             }

           */



            

            if (AccType != 1 && AccType != 2)
            {
                Console.WriteLine("INvalid input");
                Selection(user);
            }
            var AccountType = "a";
            if (AccType == 1)
            {
                AccountType = "Savings Account";
            }
            else
            {
                foreach (var i in _accountdetails)
                {
                    while (i.User_Id == user.User_Id)
                    {

                        if (i.AccountType != "Current Account")
                        {
                            AccountType = "Current Account";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n You cannot have more than one Current Account \n If you wish to create a savings account \n then please select option 1 \n");

                            Selection(user);
                        }

                    }
                }


            }


            Console.WriteLine("\n Enter Balance: ");
            string AccountBalance = Console.ReadLine();

            Console.WriteLine("\nEnter Interest or OverDraft: ");
            string AcInterestorOverDraft = Console.ReadLine();


            string AccountId = autogen();
            var Select = new AccountDetailsModel()
            {
                User_Id = user.User_Id,
                Account_ID = AccountId,
                AccountType = AccountType,
                OverdraftorInterest = AcInterestorOverDraft,
                Balance = AccountBalance

            };
            _accountdetails.Add(Select);




            JsonWrite jsonWrite = new JsonWrite();
            jsonWrite.writejsonfile(_accountdetails, _users);



        }




        public string autogen()
        {
            string num = "123456789";
            int len = num.Length;
            string otp = string.Empty;
            int otpdigit = 5;
            string finaldigit;

            int getindex;

            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();

                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }

            return otp;
        }




        public void DeleteAccount()
        {
            Console.WriteLine("\n--Accounts-- \n");
            int count = 0;
            var ListOfUserAccounts = new List<AccountDetailsModel>();
            foreach (var i in _accountdetails)
            {
                count += 1;
                Console.WriteLine(count + " User ID: " + i.User_Id + "\n Account ID: " + i.Account_ID + "\n Account Type: " + i.AccountType + "\n Interest or OverDraft: " + i.OverdraftorInterest + "\n Balance: " + i.Balance);
                ListOfUserAccounts.Add(i);
            }
            Console.WriteLine("Choose an Account: \n");
            int choose = Convert.ToInt32(Console.ReadLine());
            Choose(ListOfUserAccounts[choose - 1]);
        }

        public void Choose(AccountDetailsModel account)
        {
            _accountdetails.Remove(account);
            JsonWrite jsonWrite = new JsonWrite();
            jsonWrite.writejsonfile(_accountdetails, _users);
        }

        public void Quit()
        {

        }


    }

}
