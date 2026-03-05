using BankApp.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models;

public class AccountDetails
{
    public string AccountName { get; set; } = "";
    public int AccountNumber { get; set; }
    public decimal StartingBalance { get; set; }
    public AccountType AccountType { get; set; }
}
