using FinCluTech.BusinessObject.Models;
using FinCluTech.Core.Customer;
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
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _customerManager.GetAll();
            if (!res.IsError)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _customerManager.Get(id);
            if (!res.IsError)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Save(CustomerBo customer)
        {
            var res = await _customerManager.Save(customer);
            if (!res.IsError)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res.ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _customerManager.Delete(id);
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
