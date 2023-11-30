using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Income : BaseEntity
    {
        public string Title { get; set;}
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }

        public ICollection<AccountHead> AccountHeads { get; set; }



    }
}
