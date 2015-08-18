using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AccountTransaction.Models;
using CsvHelper;

namespace AccountTransaction.Helper
{
    public class MyCsvHelper
    {
        public  static List<Transaction> ReadFile(Stream stm)
        {
            try
            {
                var csv = new CsvReader(new StreamReader(stm));
                
                    csv.Configuration.HasHeaderRecord = true;                    
                    csv.Configuration.TrimHeaders = true;
                    csv.Configuration.RegisterClassMap(new CustomObjectMap());
                    var transactionList = csv.GetRecords<Transaction>().ToList();
                    return transactionList;
                
            }
            catch (Exception)
            {
                throw new Exception("Error while reading the Csv file");
            }            
        }
    }
}
