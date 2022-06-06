using FinCluTech.Common.Enums;
using FinCluTech.Core.Customer;
using FinCluTechWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinCluTechWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkCustomerUploadController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public BulkCustomerUploadController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Save(BulkCustomerViewModel jsoncontent)
        {
            var res = await _customerManager.SaveBulk(jsoncontent.Full);
            if (!res.IsError)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }
    }
}
