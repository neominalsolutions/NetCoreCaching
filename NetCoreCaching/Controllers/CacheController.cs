using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreCaching.Services;

namespace NetCoreCaching.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CacheController : ControllerBase
  {
    private readonly ICacheService _cacheService;

    public CacheController(ICacheService cacheService)
    {
      _cacheService = cacheService;
    }

    [HttpGet("{key}/{value}")]
    public async Task<IActionResult> Get(string key, string value)
    {
      // key value set ettik
      // set ederken jsonString çalışmalıyız
      //await _cacheService.Clear(key);
      await _cacheService.SetValueAsync(key, value);
      // value redisten keye göre çektik
      var data = await _cacheService.GetValueAsync(key); // jsonString 

      return Ok(data);
    }

  }
}
