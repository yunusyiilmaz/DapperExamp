using Dapper;
using DapperExamp.Context;
using DapperExamp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DapperExamp.Service
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _context;

        public ProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto product)
        {
            var query = "insert into Products (ProductName,Piece) values (@productName,@piece)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName",product.ProductName);
            parameters.Add("@piece", product.Piece);
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var query = "Delete From Products where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("productId",id);
            using (var connection = _context.CreateConnection()) 
            { 
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var query = "Select * From Products";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var query = "Select * From Products where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using(var connection = _context.CreateConnection()) 
            {
                var values =await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateProductAsync(UpdateProductDto product)
        {
            var query = "Update Products Set ProductName=@productName,Piece=@piece where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", product.ProductId);
            parameters.Add("@productName", product.ProductName);
            parameters.Add("@piece", product.Piece);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
