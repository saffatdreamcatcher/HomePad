using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomePad.Models
{
    public class IncomeVM
    {
        public IncomeVM(int id)
        {
            Id = id;
        }

        public IncomeVM()
        {

        }

        public int Id { get; set; }
        public int AccountHeadId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public byte[]? Attachment { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public string AccountHeadName { get; set; }


    }
}
