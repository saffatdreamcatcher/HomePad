using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class PasswordVaultDetail : BaseEntity
    {
        public int PasswordVaultId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public PasswordVault PasswordVault { get; set; }
    }
}
