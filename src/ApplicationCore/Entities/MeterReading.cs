using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MeterReading : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public decimal Reading { get; set; }
        public string Note { get; set; }
        public byte[]? Attachment { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
    }
}
