using BankApp.Base;
using BankApp.Factories;

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

            int inputChosen = KeyboardSelection.SelectionOfTheMenu();

            switch (inputChosen)
            {
                case 0:
                    string skapaKonto = TypeOfAccount.DifferentTypeOfAccounts(inputChosen.ToString());

                    if (skapaKonto == "0" || skapaKonto == "1" || skapaKonto == "2" || skapaKonto == "3" || skapaKonto == "4" || string.IsNullOrWhiteSpace(skapaKonto))
                    {
                        Console.Clear();
                        if (skapaKonto == "0")
                        {
                            Console.WriteLine("BANK KONTO");
                        }
                        else if (skapaKonto == "1")
                        {
                            Console.WriteLine("UDDEVALLA KONTO");
                        }
                        else if (skapaKonto == "2")
                        {
                            Console.WriteLine("ISK KONTO");
                        }
                        else if (skapaKonto == "3")
                        {
                            Console.WriteLine("SAVINGS KONTO");
                        }
                        else if (skapaKonto == "4")
                        {
                            Console.WriteLine("AKTIE KONTO");
                        }
                        else if (string.IsNullOrWhiteSpace(skapaKonto))
                        {
                            Console.WriteLine("Fel inmatning!");
                            Console.Write("Försök igen senare...");
                            Console.ReadKey();
                            break;
                        }

                        var accountDetails = TypeOfAccount.ContactInput();

                        switch (skapaKonto)
                        {
                            case "1":
                                Console.Clear();
                                accountDetails.AccountType = Types.AccountType.BankAccount;
                                break;

                            case "2":
                                Console.Clear();
                                accountDetails.AccountType = Types.AccountType.UddevallaAccount;
                                break;

                            case "3":
                                Console.Clear();
                                accountDetails.AccountType = Types.AccountType.IskAccount;
                                break;

                            case "4":
                                accountDetails.AccountType = Types.AccountType.SavingsAccount;
                                break;

                            case "5":
                                accountDetails.AccountType = Types.AccountType.AktieAccount;
                                break;
                        }

                        var accountJustCreated = AccountFactory.CreateAccount(accountDetails);

                        TypeOfAccount.AddToAccontsList(bank, accountJustCreated);
                    }
                    break;

                case 1:
                    bank.RemoveAccount(inputChosen.ToString());
                    break;

                case 2:
                    bank.ShowAllAccounts(inputChosen.ToString());
                    Console.ReadKey();
                    break;

                case 3:
                    bank.ManageAccounts(bank);
                    break;

                case 4:
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
        int.TryParse(Console.ReadLine(), out int taBort);
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