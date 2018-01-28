using System;
using System.Collections.Generic;

namespace Net_Core_Repo.Contracts
{
    public class ProductRequest
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}