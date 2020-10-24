using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Repositories;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _serv;
    public VaultsController(VaultsService serv)
    {
      _serv = serv;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Vault>>>
    GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_serv.GetById(userInfo?.Id, id));
      }
      catch (Exception error)
      {

        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public async Task<ActionResult<Vault>> Post([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        Vault created = _serv.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);
      }
    }
  }
}