namespace BankingSystem;

//inherited from BankAccount base class
public class SavingsAccount: BankAccount
{
    private decimal InterestRate { get; set; }
    
    //overriding CreateAccount method to create SavingsAccount type user
    public void CreateAccount(int accountNumber, string name, decimal balance,decimal interestRate)
    {
        AccountNumber=accountNumber;
        Name=name;
        Balance = balance;
        InterestRate=interestRate;
    }
    //calculate interest for savingsaccount type user
    public decimal ApplyInterest()
    {
        decimal interest = (InterestRate / 100) * Balance;
        Balance+=interest;
        return interest;
    }
}