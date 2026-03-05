namespace BankApp;

public class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        Bank.ShowBankMenu(bank);
    }
}
