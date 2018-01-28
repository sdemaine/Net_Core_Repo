using System;
using System.Collections.Generic;
using Net_Core_Repo.Models;
using Newtonsoft.Json;

namespace Net_Core_Repo.Contracts
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
            Items = new List<T>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<T> Items { get; set; }
    }
}