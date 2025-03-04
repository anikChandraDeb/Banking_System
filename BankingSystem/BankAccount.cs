namespace BankingSystem;

public class BankAccount
{
    //data member are protected
    protected int AccountNumber { get; set; }
    protected string Name { get; set; }
    protected decimal Balance { get; set; }
    
    //create new account of regularAccount
    public void CreateAccount(int accountNumber, string name, decimal balance)
    {
        AccountNumber=accountNumber;
        Name=name;
        Balance = balance;
    }
    //deposit
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
    //withdraw
    public decimal Withdraw(decimal amount)
    {
        if (Balance >= amount)
            Balance -= amount;
        else amount = -1;
        return amount;
    }
    //check balance
    public decimal CheckBalance()
    {
        return Balance;
    }
    //for regular account the interest rate ar zero
    public decimal ApplyInterest()
    {
        decimal interest = 0;
        Balance += interest;
        return interest;
    }
}