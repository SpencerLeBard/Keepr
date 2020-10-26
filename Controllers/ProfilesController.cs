using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly VaultsService _vs;

    public ProfilesController(ProfilesService ps, VaultsService vs)
    {
      _ps = ps;
      _vs = vs;
    }


    [HttpGet]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        return Ok(_ps.GetProfileById(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/vaults")] //api/profiles/:profileId/vaults
    public async Task<ActionResult<IEnumerable<VaultsController>>> GetVaults(string id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Profile queryProfile = _ps.GetProfileById(id);
        return Ok(_vs.GetVaultsByCreatorId(queryProfile.Id, userInfo?.Id));
      }
      catch (Exception error)
      {

        return BadRequest(error.Message);
      }
    }
  }
}