using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Repositories;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _serv;
    public KeepsController(KeepsService serv)
    {
      _serv = serv;
    }
    [HttpGet]
    public ActionResult<Keep> Get()
    {
      try
      {
        return Ok(_serv.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Keep>>> GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        var something = Ok(_serv.GetById(userInfo?.Id, id));
        return something;
      }
      catch (Exception error)
      {

        return BadRequest(error.Message);
      }
    }

    //NOTE GET KEEPS BY VAULT ID (ONLY KNOW THIS BY CHECKING VAULTKEEPS)

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Post([FromBody] Keep newKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        Keep created = _serv.Create(newKeep);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_serv.Delete(id, userInfo.Id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);

      }
    }
    [HttpPut("{id}")] //keeps/:keepId
    public async Task<ActionResult<Keep>> KeepViewCounter(int id, [FromBody] Keep keepData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        keepData.CreatorId = userInfo.Id;
        keepData.Creator = userInfo;
        keepData.Id = id;
        return Ok(_serv.KeepViewCounter(keepData, userInfo.Id));
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);

      }
    }
    [HttpPut("{id}/keepscount")]

    public async Task<ActionResult<Keep>> KeepsCounter(int id, [FromBody] Keep keepData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        keepData.CreatorId = userInfo.Id;
        keepData.Creator = userInfo;
        keepData.Id = id;
        return Ok(_serv.KeepsCounter(keepData, userInfo.Id));
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);

      }
    }
  }
}