using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net_Core_Repo.Models;

namespace Net_Core_Repo.Data
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}