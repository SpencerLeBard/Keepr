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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _serv;
    public VaultKeepsController(VaultKeepsService serv)
    {
      _serv = serv;
    }
    [HttpPost]
    public ActionResult<string> Create([FromBody] VaultKeep newVK)
    {
      try
      {
        _serv.Create(newVK);
        return Ok("nice");
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    //NOTE GET BY VAULT ID (?)
  }
}