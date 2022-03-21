using System;
using System.Collections.Generic;

#nullable disable

namespace ZaszloArusAPI_EF.Models
{
    public partial class User
    {
        public User()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Lvl { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
