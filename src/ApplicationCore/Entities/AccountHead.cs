using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class AccountHead : BaseEntity
    {
        public string Name { get; set; }

        //public Income Income { get; set; }

        public ICollection<Income> Incomes { get; set; }

        public ICollection<Expense> Expences { get; set; }


    }

    
}
