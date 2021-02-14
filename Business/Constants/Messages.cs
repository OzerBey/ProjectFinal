using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //sürekli new lememek için ve sabit oldugu için 'static' olarak verdik !!
    {
        //Public olanlar Pascal Case yazılır ...=> ProducAddedMessage gibi
        public static string ProductAdded = "Product has been added.";  
        public static string ProductNameInvalid = "ProductName is invalid";
        public static string MaintananceTime = "System is maintenance now";
        public static string ProductListed="Product has been listed";
    }
}
