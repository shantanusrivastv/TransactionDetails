using AccountTransaction.Common;
using AccountTransaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountTransaction.Helper
{
    public class TransactionHelper
    {
        public static Tuple<int,int> ValidateFile(ref List<Transaction> transactions)
        {
            try
            {
                var intialcount = transactions.Count;

                var inValidRecord = transactions.Where(x => x.Amount == 0.00m || x.Account == ConstFields.missing
                                                       || x.Description == ConstFields.missing || x.CurrencyCode == ConstFields.missing
                                                       || (!CurrencyHelper.CurrencyList.Contains(x.CurrencyCode))
                                                       ).ToList();


                int count = transactions.RemoveAll(x => x.Amount == 0.00m || x.Account == ConstFields.missing
                                                       || x.Description == ConstFields.missing || x.CurrencyCode == ConstFields.missing
                                                       || (!CurrencyHelper.CurrencyList.Contains(x.CurrencyCode)));

                int final = transactions.Count;
                return Tuple.Create(final,count);
            }
            catch (Exception)
            {

                throw new Exception("Error while validating the Trnsaction list");
            }
        }
    }
}