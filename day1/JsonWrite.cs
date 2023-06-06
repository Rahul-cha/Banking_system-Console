using day1;
using Day1;
using System;

public class JsonWrite
{

    public void writejsonfile(List<AccountDetailsModel> accountDetails, List<User> users)
    {
        string accountdetailstext = @"C:\Users\acer\source\repos\intern\day1\day1\Accounts.json";


        string output = Newtonsoft.Json.JsonConvert.SerializeObject(accountDetails, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(accountdetailstext, output);


    }

}
