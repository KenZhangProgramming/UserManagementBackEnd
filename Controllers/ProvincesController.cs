using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserManagementBackEnd.Data;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Controllers
{
    [Route("api/provinces")]
    public class ProvincesController : ControllerBase
    {
        IProvincesRepository _ProvincesRepository;
        ILogger _Logger;

        public ProvincesController(IProvincesRepository provincesRepo, ILoggerFactory loggerFactory)
        {
            _ProvincesRepository = provincesRepo;
            _Logger = loggerFactory.CreateLogger(nameof(ProvincesController));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Province>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> provinces()
        {
            try
            {
                var provinces = await _ProvincesRepository.GetProvincesAsync();
                return Ok(provinces);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}
