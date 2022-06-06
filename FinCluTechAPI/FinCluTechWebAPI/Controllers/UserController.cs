using FinCluTech.BusinessObject.Models;
using FinCluTech.Core.User;
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
    [Authorize(Roles = "Administrator")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var res = await _userManager.GetAll();
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
            var res = await _userManager.Get(id);
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
        public async Task<ActionResult> Save(UserBo user)
        {
            var res = await _userManager.Save(user);
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
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _userManager.Delete(id);
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
