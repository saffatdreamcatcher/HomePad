using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class PasswordVault : BaseEntity
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? OneTimePassword { get; set; } 
        public string Url { get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime LastUpdatedBy { get; set; }
        public bool IsRemoved { get; set; }
        public ICollection<PasswordVaultDetail> PasswordVaultDetails { get; set; }


    }
}
