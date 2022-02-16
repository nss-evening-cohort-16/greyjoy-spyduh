using Greyjoy_SpyDuh.Models;
using static Greyjoy_SpyDuh.Models.Spy;

namespace Greyjoy_SpyDuh.Repos
{
    public class SpyRepository
    {
        public static List<Spy> spys = new List<Spy>()
        {
            new Spy()
            {
                Name = "Sterling Archer",
                Id = 1,
                Skills = new List<SkillType> { SkillType.Seduction, SkillType.Sabatoge, SkillType.Deception },
                Friends = new List<int> {},
                Enemies = new List<int> {},
            },

            new Spy()
            {
                Name = "Lana Kane",
                Id = 2,
                Skills = new List<SkillType> { SkillType.Seduction, SkillType.Disguise, SkillType.LockPicking },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
            new Spy()
            {
                Name = "Woodhouse",
                Id = 3,
                Skills = new List<SkillType> { SkillType.Seduction, SkillType.Sabatoge, SkillType.Assassination },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
            new Spy()
            {
                Name = "Cyril",
                Id = 4,
                Skills = new List<SkillType> { SkillType.Sneaking, SkillType.Disguise, SkillType.Deception, SkillType.Sabatoge },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
             new Spy()
            {
                Name = "Barry the Cyborg",
                Id = 5,
                Skills = new List<SkillType> { SkillType.Sneaking, SkillType.Disguise, SkillType.Deception, SkillType.Sabatoge },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
              new Spy()
            {
                Name = "Ray Gillette",
                Id = 6,
                Skills = new List<SkillType> { SkillType.Sneaking, SkillType.Deception, SkillType.LockPicking, SkillType.Sabatoge },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
               new Spy()
            {
                Name = "Pam Poovey",
                Id = 7,
                Skills = new List<SkillType> { SkillType.Sneaking, SkillType.LockPicking, SkillType.Deception, SkillType.Sabatoge },
                Friends = new List<int> {  },
                Enemies = new List<int> {},
            },
        };

        internal List<Spy> GetAll()
        {
            return spys;
        }

        internal object GetById(int id)
        {
            var match = spys.FirstOrDefault(r => r.Id == id);

            return match;
        }

        internal void Post(Spy newSpy)
        {
            spys.Add(newSpy);
        }
        internal object GetSkills(SkillType skill)
        {
            var matchingSkills = spys.Where(x => x.Skills.Contains(skill));
            return matchingSkills;
        }
        
    }
}