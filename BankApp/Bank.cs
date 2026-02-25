using BankApp.Accounts;
using BankApp.Base;

namespace BankApp;

internal class Bank
{
    /*Farzad
         * RemoveAccount arbetar med Guid, men användarinmatningen är en sträng, vilket leder till en typmässig och logisk inkonsekvens.
         */
    internal List<AccountBase> accounts = new List<AccountBase>();
    internal void AddAccount(AccountBase account)
    {
        accounts.Add(account);
    }

    internal void RemoveAccount(Guid accountId)
    {
        var account = accounts.FirstOrDefault(x => x.Id == accountId);

        if (account != null)
        {
            accounts.Remove(account);
        }
    }

    public List<AccountBase> GetAccounts()
    {
        return accounts;
    }

    public void InputToDeleteAccount(AccountBase kontoTaBort)
    {
        if (kontoTaBort != null)
        {
            RemoveAccount(kontoTaBort.Id);
            Console.WriteLine("Kontot har succesivt tagits bort!");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Det angivna kontonumret finns inte");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
            Console.ReadKey();
        }
    }

    public static void ShowBankMenu(Bank bank)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("MENY");
            Console.WriteLine("1. Skapa Konto"); //Isk konto, uddevalla konto vanlig Bank konto
            Console.WriteLine("2. Ta bort konto");// kunna ta bort konto
            Console.WriteLine("3. Visa konton"); // gå in på kontot och visa balance 
            Console.WriteLine("4. Hantera konto"); //sätta in pengar och ta ut pengar, kunna använda välja en specifik konto och sedan visa dess specifika information
            Console.WriteLine("5. Stäng");

            Console.Write("Ange någon av alternativen ovan: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    string skapaKonto = TypeOfAccount.DifferentTypeOfAccounts(input);

                    if (skapaKonto == "1" || skapaKonto == "2" || skapaKonto == "3" || string.IsNullOrWhiteSpace(skapaKonto))
                    {
                        Console.Clear();
                        if (skapaKonto == "1")
                        {
                            Console.WriteLine("BANK KONTO");
                        }
                        else if (skapaKonto == "2")
                        {
                            Console.WriteLine("UDDEVALLA KONTO");
                        }
                        else if (skapaKonto == "3")
                        {
                            Console.WriteLine("ISK KONTO");
                        }
                        else if (string.IsNullOrWhiteSpace(skapaKonto))
                        {
                            Console.WriteLine("Fel inmatning!");
                            Console.Write("Försök igen senare...");
                            Console.ReadKey();
                            break;
                        }

                        var (kontoNamn, kontoNummer) = TypeOfAccount.ContactInput();
                        AccountBase nyttKonto = null;
                        string kontoTyp = "";

                        switch (skapaKonto)
                        {
                            case "1":
                                Console.Clear();
                                nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString(), 2);
                                kontoTyp = "Bank Konto";
                                break;

                            case "2":
                                nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString(), 2); 
                                kontoTyp = "Uddevalla Konto";

                                break;

                            case "3":
                                nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString(), 2); 
                                kontoTyp = "Isk Konto";
                                break;
                        }

                        TypeOfAccount.AddToAccontsList(bank, nyttKonto);
                    }
                    break;

                case "2":
                    bank.RemoveAccount(input);
                    break;

                case "3":
                    bank.ShowAllAccounts(input);
                    Console.ReadKey();
                    break;

                case "4":
                    bank.ManageAccounts(bank);

                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }

    public void ShowAllAccounts(string input)
    {
        Console.Clear();

        if (!accounts.Any())
        {
            Console.WriteLine("Du har inga aktiva konton än");
            Console.Write("Tryck Enter för att fortsätta till menyn...");
        }

        foreach (var account in accounts)
        {
            Console.WriteLine($"Namn: {account.AccountName}");
            Console.WriteLine($"Kontonummer: {account.AccountNumber}");
            Console.WriteLine($"Saldo: {account.Balance()}");
            Console.WriteLine($"Ränta: {Math.Round(account.CalculateInterestRate(), 2)}kr"); /*Eller ha en siffra inuti argumenten här inuti parentesen men då får du ändra där uppe, ena är att du hämtar ett konto och den andra en siffra */
            Console.WriteLine("-----------------------------");
        }
    }

    public void RemoveAccount(string input)
    {
        DeleteAccounts.WetherAccountExists(accounts);

        Console.Write("\nAnge vilket konto du vill ta bort genom att skriva dess Kontonummer: ");
        var taBort = Console.ReadLine();
        var kontoTaBort = accounts.FirstOrDefault(z => z.AccountNumber == taBort);
        InputToDeleteAccount(kontoTaBort);
    }

    public void ManageAccounts(Bank bank)
    {
        Console.Clear();

        HandleAccount.AccountNotExisting(bank);
        Console.WriteLine("Alla aktiva konton: ");
        AccountBase account = HandleAccount.CurrentActiveAccounts(bank);

        bool run = true;
        while (run)
        {
            Console.Clear();
            if (account == null)
            {
                Console.WriteLine("Konto med angivna Kontonummer finns inte.");
            }


            Console.WriteLine("1. Insättning");
            Console.WriteLine("2. Uttag");
            Console.WriteLine("3. Visa saldo");
            Console.WriteLine("4. Insättningar");
            Console.WriteLine("\n5. Tillbaka till menyn");
            Console.Write("\nVälj vänligen en av alternativen ovan (1-5): ");
            int.TryParse(Console.ReadLine(), out int inputs);

            switch (inputs)
            {
                case 1:
                    HandleAccount.DepositIntoAccount(account);
                    break;

                case 2:
                    HandleAccount.WithdrawFromAccount(account);

                    break;

                case 3:
                    HandleAccount.CurrentBalance(account);
                    break;

                case 4:
                    Console.Clear();
                    HandleAccount.TransactionsDuringTheYear();
                    break;

                case 5:
                    run = false;
                    break;
            }
        }
    }
}