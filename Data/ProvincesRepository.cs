using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public class ProvincesRepository : IProvincesRepository
    {
        private readonly UserManagementBackEndContext _Context;
        private readonly ILogger _Logger;

        public ProvincesRepository(UserManagementBackEndContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("ProvincesRepository");
        }

        public async Task<List<Province>> GetProvincesAsync()
        {
            return await _Context.Province.OrderBy(p => p.Abbreviation).ToListAsync();
        }
    }

}

