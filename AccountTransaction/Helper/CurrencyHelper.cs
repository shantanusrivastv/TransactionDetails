using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;

namespace AccountTransaction.Helper
{
    public static class CurrencyHelper
    {

         static CurrencyHelper()
        {
            PopulateCurrencyCode();

        }
        private static void PopulateCurrencyCode()    
        {

            try
            {
                string path = Path.Combine(HostingEnvironment.MapPath("~/Data/"), "Currency code.xml");
                XElement po = XElement.Load(path);

                var emplyees = from emp in po.Descendants("CcyTbl").Descendants("CcyNtry")
                               select (string)emp.Element("Ccy");


                CurrencyList = emplyees.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Exception occured while Populating Currency Code");
            }
        }

        public static List<string> CurrencyList
        {
            private set;

            //Public Get
            get;

        }
    }
}