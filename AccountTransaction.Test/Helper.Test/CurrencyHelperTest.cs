using AccountTransaction.Helper;
using AccountTransaction.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using AccountTransaction.Common;

namespace AccountTransaction.Test.Helper.Test
{
    [TestFixture]
    public class CurrencyHelperTest
    {

        
        [Test]
        public void GetCurrencyCodeTest()
        {
            //Arrange

            //CurrencyHelper sut = new CurrencyHelper();
            //sut.GetCurrencyCode();

            //Act
            //var list = ParseCsvFile();

            //new CsvHelper().Validation(list);

            //Assert

            CsvParse();

        }


        public List<Transaction> ParseCsvFile()
        {
            try
            {
                using (var csvReader = new StreamReader(@"E:\Assignments\AccountDetailsPLAY.csv"))
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
                            uploadModelRecord.Amount = decimal.Parse(transaction[3], NumberStyles.Currency) != 0.00m ? decimal.Parse(transaction[3], CultureInfo.InvariantCulture) : 0.00m;
                            uploadModelList.Add(uploadModelRecord);
                        }
                        catch (Exception)
                        {


                            return null;
                        }



                    }

                    return uploadModelList;

                }
            }
            catch (Exception)
            {
                throw new Exception("Error while Reading the File Content");
            }
        }


        public static void CsvParse()
        {
            var csv = new CsvReader(File.OpenText(@"E:\Assignments\AccountDetailsPLAY.csv"));
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.TrimHeaders = true;
            csv.Configuration.RegisterClassMap(new MyCustomObjectMap());
            var transactionList = csv.GetRecords<Transaction>().ToList();             
        }


        public sealed class MyCustomObjectMap : CsvClassMap<Transaction>
        {   
            public MyCustomObjectMap()
            {

                Map(m => m.Account).Index(0).Name("Account").Default(ConstFields.missing);
                Map(m => m.Description).Index(1).Name("Description").Default(ConstFields.missing);
                Map(m => m.CurrencyCode).Index(2).Name("Currency Code").Default(ConstFields.missing);
                Map(m => m.Amount).Index(3).Name("Amount").Default(0.00m); 
                Map(m => m.Id).Ignore(true);
                

            }
        }

    }

}
