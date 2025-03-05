namespace BankingSystem;

public class BankAccount
{
    public int AccountNumber { get;private set; }
    public string Name { get;private set; }
    public decimal Balance { get;protected set; }
    
    public BankAccount(int accountNumber, string name, decimal balance)
    {
        AccountNumber=accountNumber;
        Name=name;
        Balance = balance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public decimal Withdraw(decimal amount)
    {
        if (Balance >= amount)
            Balance -= amount;
        else amount = -1;
        return amount;
    }

    public decimal CheckBalance()
    {
        return Balance;
    }
    public decimal ApplyInterest()
    {
        decimal interest = 0;
        Balance += interest;
        return interest;
    }
}