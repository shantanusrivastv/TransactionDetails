using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountTransaction.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}