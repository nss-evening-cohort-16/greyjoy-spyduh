using Greyjoy_SpyDuh.Models;
using Greyjoy_SpyDuh.Repos;
using Microsoft.AspNetCore.Mvc;
using static Greyjoy_SpyDuh.Models.Spy;

namespace Greyjoy_SpyDuh.Controllers
{
    [Route("api/Spies")]
    [ApiController]
    public class SpyController : Controller
    {
        SpyRepository _spyRepository = new SpyRepository();

        [HttpGet]
        public List<Spy> spies()
        {
            return _spyRepository.GetAll();
        }

        [HttpPost]
        public IActionResult PostNewSpy(Spy spy)
        {
            if (spy == null)
            {
                return NotFound();
            }
            else if (!ValidNewSpy(spy))
            {
                return BadRequest();
            }
            else
            {
                _spyRepository.Post(spy);
                return Ok(spy);
            }
        }

        private bool ValidNewSpy(Spy newSpy)
        {
            if (_spyRepository.GetById(newSpy.Id) != null)
            {
                return false;
            }

            if (newSpy.Name == null)
            {
                return false;
            }

            if (newSpy.Friends != null)
            {
                foreach (var friend in newSpy.Friends)
                {
                    if (_spyRepository.GetById(friend) == null)
                    {
                        return false;
                    }
                }
            }

            if (newSpy.Enemies != null)
            {
                foreach (var enemy in newSpy.Enemies)
                {
                    if (_spyRepository.GetById(enemy) == null)
                    {
                        return false;
                    }
                }
            }

            if (newSpy.Skills != null)
            {
                foreach (var skill in newSpy.Skills)
                {
                    if (!Enum.IsDefined(typeof(SkillType), skill))
                    {
                        return false;
                    }

                }
            }

            return true;

        }
        [HttpGet("skill/{skill}")]
        public IActionResult GetSpyBySkill(SkillType skill)
        {
            var matches = _spyRepository.GetSkills(skill);
            if (matches == null)
            {
                return NotFound();
            }
            return Ok(matches);

        }
    }


}