using AccountTransaction.Common;
using AccountTransaction.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountTransaction.Helper
{
    public sealed class CustomObjectMap : CsvClassMap<Transaction>
    {       
        public CustomObjectMap()
        {
            Map(m => m.Account).Index(0).Name("Account").Default(ConstFields.missing);
            Map(m => m.Description).Index(1).Name("Description").Default(ConstFields.missing);
            Map(m => m.CurrencyCode).Index(2).Name("Currency Code").Default(ConstFields.missing);
            Map(m => m.Amount).Index(3).Name("Amount").Default(0.00m);
            Map(m => m.Id).Ignore(true);
        }
    }
}