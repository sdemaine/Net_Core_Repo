using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net_Core_Repo.Business;
using Net_Core_Repo.Contracts;
using Net_Core_Repo.Data;
using Net_Core_Repo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Net_Core_Repo.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET api/v1/products/{id}
        [HttpGet("{id}")]
        public async Task<ProductResponse> Get(long id)
        {
            return await _productBusiness.GetAsync(id);
        }

        // GET api/v1/products
        [HttpGet]
        public async Task<ProductResponse> Get()
        {
            return await _productBusiness.GetAllAsync();
        }

        // POST api/v1/products
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]ProductRequest productRequest)
        {
            await _productBusiness.AddAsync(productRequest);
        }
    }
}