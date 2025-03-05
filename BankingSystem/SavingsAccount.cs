namespace BankingSystem;

public class SavingsAccount: BankAccount
{
    private decimal InterestRate { get; set; }
    public SavingsAccount(int accountNumber, string name, decimal balance,decimal interestRate):base(accountNumber,name,balance)
    {
        InterestRate=interestRate;
    }

    public decimal ApplyInterest()
    {
        decimal interest = (InterestRate / 100) * Balance;
        Balance+=interest;
        return interest;
    }
}