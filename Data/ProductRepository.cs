using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly UserManagementBackEndContext _Context;
        private readonly ILogger _Logger;


        public ProductRepository(UserManagementBackEndContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("ProductsRepository");
        }


        public async Task<List<Product>> GetProductsAsync()
        {

        }
    }
}
