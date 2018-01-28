using System;
using System.Collections.Generic;
using Net_Core_Repo.Models;
using Newtonsoft.Json;

namespace Net_Core_Repo.Contracts
{
    public class ProductResponse
    {
        public ProductResponse()
        {
            Products = new List<Product>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Product> Products { get; set; }
    }
}