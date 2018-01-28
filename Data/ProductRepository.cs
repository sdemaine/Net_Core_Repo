using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Net_Core_Repo.Models;
using Dapper;

namespace Net_Core_Repo.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ProductRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=.\\SQL2014;Initial Catalog=RestfulSampleDb;Trusted_Connection=True;";
        }

        public async Task<Product> GetAsync(long id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[CategoryId]
                                ,[Name]
                                ,[Description]
                                ,[Price]
                                ,[CreatedDate]
                                FROM [dbo].[Products]
                                WHERE [Id] = @Id";

                query = "SELECT * FROM Products";

                var product = await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { @Id = id });

                return product;
            }
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[CategoryId]
                                ,[Name]
                                ,[Description]
                                ,[Price]
                                ,[CreatedDate]
                                FROM [dbo].[Products]";

                var product = await dbConnection.QueryAsync<Product>(query);

                return product;
            }
        }

        public async Task AddAsync(Product product)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[Products] (
                                [Id],
                                [CategoryId],
                                [Name],
                                [Description],
                                [Price],
                                [CreatedDate]) VALUES (
                                @Id,
                                @CategoryId,
                                @Name,
                                @Description,
                                @Price,
                                @CreatedDate)";

                await dbConnection.ExecuteAsync(query, product);
            }
        }
    }
}