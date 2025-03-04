namespace BankingSystem;

public class SavingsAccount: BankAccount
{
    private decimal InterestRate { get; set; }
    public void CreateAccount(int accountNumber, string name, decimal balance,decimal interestRate)
    {
        AccountNumber=accountNumber;
        Name=name;
        Balance = balance;
        InterestRate=interestRate;
    }

    public decimal ApplyInterest()
    {
        decimal interest = (InterestRate / 100) * Balance;
        Balance+=interest;
        return interest;
    }
}