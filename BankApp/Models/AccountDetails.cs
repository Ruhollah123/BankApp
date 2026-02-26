using BankApp.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Models;

internal class AccountDetails
{
    internal string AccountName { get; set; } = "";
    internal int AccountNumber { get; set; }
    internal decimal StartingBalance { get; set; }
    internal AccountType AccountType { get; set; }
}
