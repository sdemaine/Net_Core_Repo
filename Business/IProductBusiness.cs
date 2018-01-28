using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net_Core_Repo.Contracts;
using Net_Core_Repo.Models;

namespace Net_Core_Repo.Business
{
    public interface IProductBusiness
    {
        Task<ProductResponse> GetAsync(long id);
        Task<ProductResponse> GetAllAsync();
        Task AddAsync(ProductRequest productRequest);
    }
}