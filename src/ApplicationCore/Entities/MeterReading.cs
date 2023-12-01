using System;
using System.Collections.Generic;
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
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
    }
}
