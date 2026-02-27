using BankApp.Base;

namespace BankApp;

internal class DeleteAccounts
{
    public static int? WetherAccountExists(List<AccountBase> accounts)
    {
        Console.Clear();
        if (!accounts.Any())
        {
            Console.WriteLine("Du har inga aktiva konton än");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
            Console.ReadKey();
            return null;
        }

        foreach (var konto in accounts)
        {
            Console.WriteLine($"Kontonamn: {konto.AccountName}, Kontonummer: {konto.AccountNumber}");
        }

        Console.Write("\nAnge vilket konto du vill ta bort genom att skriva dess Kontonummer: ");
        int.TryParse(Console.ReadLine(), out int taBort);
        return taBort;
    }
}
