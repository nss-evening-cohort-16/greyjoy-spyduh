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

        [HttpPost("{id}/friends")]
        public IActionResult AddFriend(int id, FriendsAndEnemies friend)
        {
            if (_spyRepository.GetById(friend.FriendOrEnemyId) == null)
            {
                return BadRequest("Friend to add does not exist.");
            }
            if (_spyRepository.GetById(id) == null)
            {
                return BadRequest("Friend cannot be added as Spy does not exist.");
            }
            if(((Spy)_spyRepository.GetById(id)).Friends.Contains(friend.FriendOrEnemyId))
            {
                return BadRequest("Friend already added");
            }
            else
            {
               ((Spy)_spyRepository.GetById(id)).AddFriend(friend.FriendOrEnemyId);
                string spyName = ((Spy)_spyRepository.GetById(id)).Name;
                string friendName = ((Spy)_spyRepository.GetById(friend.FriendOrEnemyId)).Name;
                return Ok($"Added (ID:{friend.FriendOrEnemyId}){friendName} to (ID:{id}){spyName}'s list of enemies.");
            }
        }

        [HttpPost("{id}/enemies")]
        public IActionResult AddEnemy(int id, FriendsAndEnemies enemy)
        {
            if (_spyRepository.GetById(enemy.FriendOrEnemyId) == null)
            {
                return BadRequest("Enemy to add does not exist.");
            }
            if (_spyRepository.GetById(id) == null)
            {
                return BadRequest("Enemy cannot be added as Spy does not exist.");
            }
            if (((Spy)_spyRepository.GetById(id)).Enemies.Contains(enemy.FriendOrEnemyId))
            {
                return BadRequest("Enemy already added");
            }
            else
            {
               ((Spy)_spyRepository.GetById(id)).AddEnemy(enemy.FriendOrEnemyId);
                string spyName = ((Spy)_spyRepository.GetById(id)).Name;
                string enemyName = ((Spy)_spyRepository.GetById(enemy.FriendOrEnemyId)).Name;
                return Ok($"Added (ID:{enemy.FriendOrEnemyId}){enemyName} to (ID:{id}){spyName}'s list of enemies.");
            }
        }

    }



}