﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
