using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using AccountTransaction.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using AccountTransaction.DAL;
using EntityFramework.BulkInsert.Extensions;
using CsvHelper;
using CsvHelper.Configuration;
using AccountTransaction.Common;

namespace AccountTransaction.Helper
{
    public class MyCsvHelper
    {
        static int count = 0;        
        ITransactionDb _db = new TransactionContext();


        public List<Transaction> ReadFile(Stream stm)
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
        public void ParseCsvFile(Stream stm)
        {
            try
            {
                using (var csvReader = new StreamReader(stm))
                {
                    // work out where we should split on comma, but not in a sentence
                    Regex reg = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    
                    
                    string line = string.Empty;                   

                    var uploadModelList = new List<Transaction>();
                    List<string[]> Transactions = new List<string[]>();
                    //while (!csvReader.EndOfStream)

                    while ((line = csvReader.ReadLine()) != null)
                    {               
                        Transactions.Add(reg.Split(line));
                    }                  

                    Transactions.Remove(Transactions[0]);   
                 
                    foreach (var transaction in Transactions)
                    {
                        try
                        {
                            var uploadModelRecord = new Transaction();
                            uploadModelRecord.Account = transaction[0] != "" ? transaction[0] : ConstFields.missing;
                            uploadModelRecord.Description = transaction[1] != "" ? transaction[1] : ConstFields.missing;
                            uploadModelRecord.CurrencyCode = transaction[2] != "" ? transaction[2] : ConstFields.missing;
                            uploadModelRecord.Amount = decimal.Parse(transaction[3], CultureInfo.InvariantCulture) != 0.00m ? decimal.Parse(transaction[3], CultureInfo.InvariantCulture) : 0.00m;
                            uploadModelList.Add(uploadModelRecord);                            
                        }
                        catch (Exception)
                        {
                            
                            count++;
                            
                        }     
                 


                    }

                    _db.Add(uploadModelList);
                    
                }
            }
            catch (Exception)
            {
                throw new Exception("Error while Reading the File Content");
            }
        }


      

    }



}
