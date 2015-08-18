using AccountTransaction.Common;
using AccountTransaction.Models;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace AccountTransaction.Helper
{
    public sealed class CustomObjectMap : CsvClassMap<Transaction>
    {       
        public CustomObjectMap()
        {
            Map(m => m.Account).Index(0).Name("Account").TypeConverter<NullValueTextConverter>().Default(ConstFields.missing);
            Map(m => m.Description).Index(1).Name("Description").TypeConverter<NullValueTextConverter>().Default(ConstFields.missing);
            Map(m => m.CurrencyCode).Index(2).Name("Currency Code").TypeConverter < NullValueTextConverter>().Default(ConstFields.missing);
            Map(m => m.Amount).Index(3).Name("Amount").TypeConverter<NullValueDecimaleConverter>().Default(0.00m);
            Map(m => m.Id).Ignore(true);    
        }


        public class NullValueDecimaleConverter : DecimalConverter
        {
           
            public override object ConvertFromString(TypeConverterOptions options, string text)
            {
                return String.IsNullOrEmpty(text) || Convert.ToString(text)== "null" ? 0.00m : base.ConvertFromString(options, text);
            }

            public override bool CanConvertFrom(Type type)
            {
                return type == typeof(string);
            }
        }


        public class NullValueTextConverter : StringConverter
        {

            public override object ConvertFromString(TypeConverterOptions options, string text)
            {
                return String.IsNullOrEmpty(text) || Convert.ToString(text) == "null" ? ConstFields.missing : base.ConvertFromString(options, text);
            }

            public override bool CanConvertFrom(Type type)
            {
                return type == typeof(string);
            }
        }


    }
}