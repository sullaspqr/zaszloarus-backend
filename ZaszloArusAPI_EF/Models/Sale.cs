using System;
using System.Collections.Generic;

#nullable disable

namespace ZaszloArusAPI_EF.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public int Pricetag { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }

        public int getPriceQty(int productPrice)
        {
            return Qty * productPrice;
        }

        public int getPricetag()
        {
            return Pricetag;
        }
    }
}
