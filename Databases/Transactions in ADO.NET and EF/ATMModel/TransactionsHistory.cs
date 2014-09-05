namespace ATM.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TransactionsHistory
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
    }
}