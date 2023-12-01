using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<DocumentDetail> DocumentDetails { get; set; }
    }
}
