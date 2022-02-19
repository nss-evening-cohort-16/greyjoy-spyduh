
    namespace Greyjoy_SpyDuh.Models
    {
        public class Spy
        {
            public List<int> Enemies { get; set; }
            public List<int> Friends { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public List<SkillType> Skills { get; set; }

            public enum SkillType
            {
                Sabatoge = 1,
                Sneaking = 2,
                LockPicking = 3,
                Disguise = 4,
                Assassination = 5,
                Deception = 6,
                Seduction = 7,
            }

        public void AddFriend(int id)
        {
            Friends.Add(id);
        }
        
        public void AddEnemy(int id)
        {
            Enemies.Add(id);
        }

        }
    }
