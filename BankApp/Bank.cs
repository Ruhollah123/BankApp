using BankApp.Accounts;
using BankApp.Base;

namespace BankApp;

internal class Bank
{
    /*Tashakor*/
    /*Farzad
         * Nested switch-satser skapar onödig komplexitet och försämrar kodens läsbarhet.
         * Användning av TryParse utan att kontrollera resultatet kan leda till att ogiltig indata tyst accepteras.
         * Val av konto sker via AccountNumber, men användarens prompt refererar till ID, vilket skapar logisk inkonsekvens.
         * RemoveAccount arbetar med Guid, men användarinmatningen är en sträng, vilket leder till en typmässig och logisk inkonsekvens.
         * Variabelnamnen är inkonsekventa och kan upplevas som förvirrande.
         * Det finns onödig kodduplicering vid skapandet av konton, vilket bryter mot DRY-principen och försämrar underhållbarheten.
         * Kontohantering bör flyttas till en separat metod för bättre struktur och ansvarsfördelning
         */
    internal List<AccountBase> accounts = new List<AccountBase>();
    internal void AddAccount(AccountBase account)
    {
        accounts.Add(account);
    }


    public Bank()
    {
        accounts.Add(new BankAccount("Markus", "897"));
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

    public static void ShowBankMenu()
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


            // Switchen kan förbättras genom att lägga in metoder istället för att ha all logik i switchen.
            switch (input)
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("1. Bank Konto");
                    Console.WriteLine("2. Uddevalla Konto");
                    Console.WriteLine("3. Isk Konto");

                    Console.Write("Vilken typ av konto vill du skapa: ");
                    var skapaKonto = Console.ReadLine();

                    // Du kan kan istället spara kontotyp-valet och fråga om kontonamn och kontonummer.
                    // Efter att namn och nummer är ifyllt så kan du lägga in switchen och skapa konto baserat på det valda kontotypen.
                    // Om du vill ha en referens så kolla på min kod.
                    switch (skapaKonto)
                    {
                        case "1":
                            Bank nyaTillägg = new Bank();
                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var kontoNamn = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int kontoNummer);


                            AccountBase nyttKonto = new BankAccount(kontoNamn, kontoNummer.ToString()); // "possibly null reference" på kontoNamn.
                            nyaTillägg.AddAccount(nyttKonto);
                            Console.WriteLine("Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;

                        case "2":
                            AccountBase uddevallaKontot; // Oanvänd variabel, kan tas bort.
                            Bank skapandet = new Bank();
                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var uddevallaKonto = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int UddevallaKontoNummer);

                            AccountBase förUddevalla = new BankAccount(uddevallaKonto, UddevallaKontoNummer.ToString()); // "possibly null reference" på uddevallaKonto.
                            skapandet.AddAccount(förUddevalla);

                            Console.WriteLine("Uddevalla-Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;

                        case "3":
                            AccountBase iskKontot; // Oanvänd variabel, kan tas bort.
                            Bank sammaSak = new Bank();
                            Console.Clear();
                            Console.Write("Ange Kontonamn: ");
                            var iskKonto = Console.ReadLine();

                            Console.Write("Ange Kontonummer: ");
                            int.TryParse(Console.ReadLine(), out int iskKontoNummer);

                            AccountBase förIsk = new BankAccount(iskKonto, iskKontoNummer.ToString()); // "possibly null reference" på iskKonto.
                            sammaSak.AddAccount(förIsk);

                            Console.WriteLine("Isk-Kontot har skapats");
                            Console.Write("Tryck Enter för att fortsätta till menyn...");
                            Console.ReadKey();
                            break;
                    }
                    break;

                case "2":
                    Console.Clear();

                    // Du skapar en ny bank här?? Detta skapar en ny instans av bank.cs.
                    // Det du vill göra är att använda den bank-instansen som redan finns, där alla konton är sparade.
                    // Den instansen som finns skapades i program.cs och du behöver inte skapa en ny här eller någon annanstans.
                    var bank = new Bank(); 


                    // Detta fungerar men är inte optimalt. Istället testa använda List av konton som vi har,
                    // och visa alla konton därifrån. Eftersom det är en list så kan du använda index (0, 1, 2 ,3, 4) med en
                    // for-loop. Då kan du också använda indexet för att välja ett konto lättare exempelvis 1 eller 2 eller 3 osv.
                    // Här är ett exempel från min kod på hur du kan göra det:
                    
                    // for (int i = 0; i < accounts.Count; i++)
                    // {
                    //     Console.WriteLine($"{i + 1}. Kontonamn: {Accounts[i].AccountName}, Kontonummer: {Accounts[i].AccountNumber}");
                    // }

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
                    }

                    Console.ReadKey();
                    break;


                case "3":
                    Console.Clear();
                    Bank banken = new Bank();
                    if (!banken.accounts.Any())
                    {
                        Console.WriteLine("Du har inga aktiva konton än");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                        continue;
                    }

                    foreach (var account in banken.accounts)
                    {
                        Console.WriteLine($"Namn: {account.AccountName}");
                        Console.WriteLine($"Kontonummer: {account.AccountNumber}");
                        Console.WriteLine($"Saldo: {account.Balance()}");
                        Console.WriteLine("-----------------------------");
                    }

                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();

                    Bank bankerna = new Bank(); // ny instans?
                    if (!bankerna.accounts.Any())
                    {
                        Console.WriteLine("Ingen konto har registrerats ännu");
                        Console.Write("Tryck Enter för att fortsätta till menyn...");
                        Console.ReadKey();
                        continue;
                    }


                    Console.WriteLine("Alla aktiva konton: ");
                    foreach (var konton in bankerna.accounts)
                    {
                        Console.WriteLine($"\nNamn: {konton.AccountName}, Kontonummer: {konton.AccountNumber}");
                    }

                    Console.Write("\nSkriv någon av följande Konto-nummer du vill hantera: ");
                    var hantering = Console.ReadLine();

                    var kontona = bankerna.accounts.FirstOrDefault(x => x.AccountNumber == hantering);

                    if (kontona != null)
                    {
                        Console.Clear();

                        Console.WriteLine("1. Insättning");
                        Console.WriteLine("2. Uttag");
                        Console.WriteLine("3. Visa saldo");
                        Console.Write("Välj vänligen en av alternativen ovan: ");
                        int.TryParse(Console.ReadLine(), out int inputs);

                        
                        // Här kan du använda en while-loop för att låta användaren göra flera val utan att gå tillbaka till huvudmenyn.
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
