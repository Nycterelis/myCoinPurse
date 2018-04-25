using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myCoinPurse.Models
{
    public class DashboardViewModel
    {
        PersonalAccount PersonalAccounts { get; set; }
        List<Transaction> Transactions { get; set; }
        Budget Budgets { get; set; }
        Household Household { get; set; }

    }
}