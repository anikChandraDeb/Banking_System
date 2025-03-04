namespace BankingSystem;

public class BankAccount
{
    protected int AccountNumber { get; set; }
    protected string Name { get; set; }
    protected decimal Balance { get; set; }
    
    public void CreateAccount(int accountNumber, string name, decimal balance)
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