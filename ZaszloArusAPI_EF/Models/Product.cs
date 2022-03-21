using System;
using System.Collections.Generic;

#nullable disable

namespace ZaszloArusAPI_EF.Models
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public string Flagimg { get; set; }

        public int getPrice(int db)
        {
            if (db<=0)
            {
                throw new RosszDarabException();
            }
            if (db>Qty)
            {
                throw new ArgumentOutOfRangeException("Nincs készleten ennyi darab!");
            }
            if (db>=50)
            {
                return (int)(Price * db * .9);
            }
            if (db>=20)
            {
                return (int)(Price * db * .95);
            }
            return Price*db;
        }
        public virtual ICollection<Sale> Sales { get; set; }

        public class RosszDarabException:Exception
        {

        }
    }
}
