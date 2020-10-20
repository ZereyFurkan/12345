using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Models
{
    public class Item : BaseEntity
    {
        public int ItemTypeId { get; set; }
        public int SerialNumber { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public ItemType ItemType { get; set; }
        public ICollection<UserItem> UserItems { get; set; }

    }
}
