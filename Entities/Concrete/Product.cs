using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstarct;

namespace Entities.Concrete
{
    public class Product :IEntity   //class is not default it is internal in C#.  
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}
