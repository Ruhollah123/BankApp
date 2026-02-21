using BankApp.Accounts;
using BankApp.Base;

namespace BankApp;

internal class Bank
{
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

    internal List<AccountBase> GetAccounts()
    {
        return accounts;
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
                    Console.Clear();

                    Console.WriteLine("1. Bank Konto");
                    Console.WriteLine("2. Uddevalla Konto");
                    Console.WriteLine("3. Isk Konto");

                    Console.Write("Vilken typ av konto vill du skapa: ");
                    var skapaKonto = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(skapaKonto))
                    {
                        Console.Clear();
                        Console.WriteLine("Fel inmatning!");
                        Console.Write("Försök igen senare...");
                        Console.ReadKey();
                        break;
                    }

                    switch (skapaKonto)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var kontoNamn = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int kontoNummer);


                            AccountBase nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString(), 2);
                            bank.AddAccount(nyttKonto);
                            Console.WriteLine("Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;

                        case "2":

                            AccountBase uddevallaKontot;

                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var uddevallaKonto = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int UddevallaKontoNummer);

                            AccountBase förUddevalla = new BankAccount(uddevallaKonto, UddevallaKontoNummer.ToString(), 2);
                            bank.AddAccount(förUddevalla);

                            Console.WriteLine("Uddevalla-Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;

                        case "3":
                            AccountBase iskKontot;
                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var iskKonto = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int iskKontoNummer);

                            AccountBase förIsk = new BankAccount(iskKonto, iskKontoNummer.ToString(), 2);
                            bank.AddAccount(förIsk);

                            Console.WriteLine("Isk-Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;
                    }

                    break;


                case "2":
                    Console.Clear();

                    if (!bank.accounts.Any())
                    {
                        Console.WriteLine("Du har inga aktiva konton än");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                        continue;
                    }

                    foreach (var konto in bank.accounts)
                    {
                        Console.WriteLine($"Kontonamn: {konto.AccountName}, Kontonummer: {konto.AccountNumber}");
                    }


                    Console.Write("\nAnge vilket konto du vill ta bort genom att skriva dess ID: ");

                    var taBort = Console.ReadLine();

                    var kontoTaBort = bank.accounts.FirstOrDefault(z => z.AccountNumber == taBort);

                    if (kontoTaBort != null)
                    {
                        bank.RemoveAccount(kontoTaBort.Id);
                        Console.WriteLine("Kontot har succesivt tagits bort!");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                    }
                    else
                    {
                        Console.WriteLine("Det angivna kontonumret finns inte");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                    }
                    break;


                case "3":
                    Console.Clear();

                    if (!bank.accounts.Any())
                    {
                        Console.WriteLine("Du har inga aktiva konton än");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                        continue;
                    }

                    foreach (var account in bank.accounts)
                    {
                        Console.WriteLine($"Namn: {account.AccountName}");
                        Console.WriteLine($"Kontonummer: {account.AccountNumber}");
                        Console.WriteLine($"Saldo: {account.Balance()}");
                        Console.WriteLine($"Ränta: {Math.Round(account.CalculateInterestRate(), 2)}kr"); /*Eller ha en siffra inuti argumenten här inuti parentesen men då får du ändra där uppe, ena är att du hämtar ett konto och den andra en siffra */
                        Console.WriteLine("-----------------------------");
                    }

                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();

                    if (!bank.accounts.Any())
                    {
                        Console.WriteLine("Ingen konto har registrerats ännu");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                        continue;
                    }


                    Console.WriteLine("Alla aktiva konton: ");
                    foreach (var konton in bank.accounts)
                    {
                        Console.WriteLine($"\nNamn: {konton.AccountName}, Kontonummer: {konton.AccountNumber}");
                    }

                    Console.Write("\nSkriv någon av följande Konto-nummer du vill hantera: ");
                    var hantering = Console.ReadLine();

                    var kontona = bank.accounts.FirstOrDefault(x => x.AccountNumber == hantering);

                    if (kontona != null)
                    {
                        Console.Clear();

                        Console.WriteLine("1. Insättning");
                        Console.WriteLine("2. Uttag");
                        Console.WriteLine("3. Visa saldo");
                        Console.WriteLine("4. Insättningar");
                        Console.Write("Välj vänligen en av alternativen ovan: ");
                        int.TryParse(Console.ReadLine(), out int inputs);

                        switch (inputs)
                        {
                            case 1:

                                Console.Write("Ange belopp du vill sätta in: ");
                                decimal.TryParse(Console.ReadLine(), out decimal amount);
                                kontona.Deposit(amount);
                                Console.Write("Tryck Enter för att fortsätta till menyn...");
                                Console.ReadKey();
                                break;

                            case 2:
                                Console.Write("Ange beloppet du vill ta ut: ");
                                int.TryParse(Console.ReadLine(), out int taUtBelopp);
                                kontona.Withdraw(taUtBelopp);
                                Console.Write("Tryck Enter för att fortsätta till menyn...");
                                Console.ReadKey();

                                break;

                            case 3:

                                Console.WriteLine($"\nDitt saldo är: {kontona.Balance()}");
                                Console.Write("Tryck Enter för att fortsätta till menyn...");
                                Console.ReadKey();
                                break;

                            case 4:
                                Console.Clear();

                                Console.WriteLine("Alla insättningar under året: ");

                                var myAccount = new BankAccount("", "", 2);

                                myAccount.SeedTransactions();

                                foreach (var t in myAccount.SeedTransactions())
                                {
                                    Console.WriteLine($"\nBelopp: {t.Amount}kr");
                                    Console.WriteLine($"Datum: {t.TransactionalDate}");
                                }

                                Console.WriteLine($"\nRänta: {Math.Round(myAccount.CalculateInterestRate(), 2)}kr");
                                Console.Write("\nTryck Enter för att fortsätta till menyn...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Konto med angivna Id finns inte.");
                    }

                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }
}
