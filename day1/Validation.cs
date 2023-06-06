using day1;
using Day1;
using System;

public class Validation
{

   

    public int intergervalidation()
    {
        int a;
        
        while (true)
        {
           // Console.WriteLine("\n Please select a user account in which the money is to be transfered\n");
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("the input should be an integer!!");
                continue;

            }

            break;
        }
        return a;

    }

    public bool rangervalidatoin(int input, int ranger)
    {
        if (input < 1 || input > ranger)
            {
                Console.WriteLine("The input is out of bound!!");
                return false;
                
            }
            
        
        return true;
    }
    


}

