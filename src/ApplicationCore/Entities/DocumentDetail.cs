using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class DocumentDetail : BaseEntity
    {
        public int DocumentId { get; set; }
        public byte[]? Attachment { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }

        public string LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
        public Document Document { get; set; }
    }
}
