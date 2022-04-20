using System.Collections.Generic;

namespace Hatuatech.Test.Models
{
    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public IList<string> Sizes { get; set; }
        public string Description { get; set; }
    }

    public class ApiKeys
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
    }

    public class ProductDataResponse
    {
        public IList<Product> Products { get; set; }
        public ApiKeys ApiKeys { get; set; }
    }

}
