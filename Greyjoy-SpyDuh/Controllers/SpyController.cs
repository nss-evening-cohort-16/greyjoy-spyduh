using Greyjoy_SpyDuh.Models;
using Greyjoy_SpyDuh.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Greyjoy_SpyDuh.Controllers
{
    [Route("api/Spies")]
    [ApiController]
    public class SpyController : Controller
    {
        SpyRespository _spyRespository = new SpyRespository();

        [HttpGet]
        public List<Spy> spies()
        {
            return _spyRespository.GetAll();
        }
    }
}
