using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Expense : BaseEntity
    {
        public int AccountHeadId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public byte[]? Attachment { get; set; }

        [DataType(DataType.Date)] 
        public DateTime CreateDate { get; set; }

        public string LastUpdatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
        public AccountHead AccountHead { get; set; }
    }
}
