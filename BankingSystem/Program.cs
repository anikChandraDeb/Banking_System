// See https://aka.ms/new-console-template for more information

using System.Net;

namespace BankingSystem;

class BankingProcess
{
    public static Dictionary<int, BankAccount> regularAccountStorage = new Dictionary<int, BankAccount>();  
    public static Dictionary<int, SavingsAccount> savingsAccountStorage = new Dictionary<int, SavingsAccount>();
    //create account method
    public static void CreateAccount()
    {
        try
        {
            Console.WriteLine("Enter account type: (1 - Regular, 2 - Savings");
            int type = Convert.ToInt32(Console.ReadLine());
            if (type == 1)
            {
                Console.WriteLine("Enter Account  Number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name: ");
                string holderName = Console.ReadLine();
                Console.WriteLine("Enter Initial Balance: ");
                decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                if (regularAccountStorage.ContainsKey(number))
                {
                    Console.WriteLine("Account already exists!");
                    return;
                }

                var regularAccount = new BankAccount();
                regularAccount.CreateAccount(number, holderName, initialBalance);
                regularAccountStorage.Add(number, regularAccount);
                Console.WriteLine("Regular account created successfully.");
            }
            else if (type == 2)
            {
                Console.WriteLine("Enter Account  Number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name: ");
                string holderName = Console.ReadLine();
                Console.WriteLine("Enter Initial Balance: ");
                decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Interest Rate(%): ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());
                if (savingsAccountStorage.ContainsKey(number))
                {
                    Console.WriteLine("Account already exists!");
                    return;
                }

                var savingsAccount = new SavingsAccount();
                savingsAccount.CreateAccount(number, holderName, initialBalance, interestRate);
                savingsAccountStorage.Add(number, savingsAccount);
                Console.WriteLine("Savings account created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid Account Number enter account type: (1 - Regular, 2 - Savings");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            CreateAccount();
        }
    }

    public static void Deposit()
    {
        try
        {
            Console.WriteLine("Enter Account  Number: ");
            int number=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Deposit Amount: ");
            decimal depositAmount=Convert.ToDecimal(Console.ReadLine());
            if(depositAmount<=0) throw new Exception("Deposit amount cannot be negative or zero");
            if (regularAccountStorage.ContainsKey(number))
            {
                var  regularAccount = regularAccountStorage[number];
                regularAccount.Deposit(depositAmount);
                Console.WriteLine($"Deposited ${depositAmount}. New balance ${regularAccount.CheckBalance()}");
            }
            else if (savingsAccountStorage.ContainsKey(number))
            {
                var   savingsAccount = savingsAccountStorage[number];
                savingsAccount.Deposit(depositAmount);
                Console.WriteLine($"Deposited ${depositAmount}. New balance ${savingsAccount.CheckBalance()}");
            }
            else Console.WriteLine("Account not exists!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Deposit();
        }
    }

    public static void Withdraw()
    {
        try
        {
            Console.WriteLine("Enter Account  Number: ");
            int number=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Withdraw Amount: ");
            decimal withdrawAmount=Convert.ToDecimal(Console.ReadLine());
            if(withdrawAmount<=0) throw new Exception("Withdraw amount cannot be negative or zero");
            if (regularAccountStorage.ContainsKey(number))
            {
                var regularAccount = regularAccountStorage[number];
                var withdraw = regularAccount.Withdraw(withdrawAmount);
                if (withdraw == -1) 
                {
                    Console.WriteLine("Can't withdraw amount less balance!");
                    return;
                }

                Console.WriteLine($"Withdraw amount ${withdraw}. New balance ${regularAccount.CheckBalance()}");
            }
            else if (savingsAccountStorage.ContainsKey(number))
            {
                var   savingsAccount = savingsAccountStorage[number];
                var withdraw = savingsAccount.Withdraw(withdrawAmount);
                if (withdraw == -1) 
                {
                    Console.WriteLine("Can't withdraw amount less balance!");
                    return;
                }

                Console.WriteLine($"Withdraw amount ${withdraw}. New balance ${savingsAccount.CheckBalance()}");
            }
            else Console.WriteLine("Account not exists!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Withdraw();
        }
    }

    public static void CheckBalance()
    {
        try
        {
            Console.WriteLine("Enter Account  Number: ");
            int number=Convert.ToInt32(Console.ReadLine());
            
            if (regularAccountStorage.ContainsKey(number))
            {
                var  regularAccount = regularAccountStorage[number];

                Console.WriteLine($"Balance ${regularAccount.CheckBalance()}");
            }
            else if (savingsAccountStorage.ContainsKey(number))
            {
                var   savingsAccount = savingsAccountStorage[number];
                
                Console.WriteLine($"Balance ${savingsAccount.CheckBalance()}");
            }
            else Console.WriteLine("Account not exists!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            CheckBalance();
        }
    }

    public static void ApplyInterest()
    {
        try
        {
            Console.WriteLine("Enter Account  Number: ");
            int number=Convert.ToInt32(Console.ReadLine());
            
            if (regularAccountStorage.ContainsKey(number))
            {
                var  regularAccount = regularAccountStorage[number];
                decimal interest = regularAccount.ApplyInterest();
                string print=$"Interest applied ${interest}. New balance ${regularAccount.CheckBalance()}";
                Console.WriteLine(print);
            }
            else if (savingsAccountStorage.ContainsKey(number))
            {
                var   savingsAccount = savingsAccountStorage[number];
                decimal interest = savingsAccount.ApplyInterest();
                
                string print=$"Interest applied ${interest}. New balance {savingsAccount.CheckBalance()}";
                Console.WriteLine(print);
            }
            else Console.WriteLine("Account not exists!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            ApplyInterest();
        }
    }
    public static void Main()
    {
        bool fg = true;
        while (fg)
        {
            Console.WriteLine("\nSimple Banking System");
            Console.WriteLine("1. Create Account \n2. Deposit \n3. Withdraw \n4. Check Balance\n5.Apply Interest(Savings Account)\n6. Exit");
            Console.WriteLine("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    CheckBalance();
                    break;
                case 5:
                    ApplyInterest();
                    break;
                case 6:
                    fg = false;
                    break;
            }
        }
    }
}