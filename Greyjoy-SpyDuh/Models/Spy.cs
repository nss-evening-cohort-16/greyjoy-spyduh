namespace Greyjoy_SpyDuh.Models
{
    public class Spy
    {
        public List<Spy> Enemies { get; set; }
        public List<Spy> Friends { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<SkillType> Skills { get; set; }

        public enum SkillType
        {
        Sabatoge,
        Sneaking, 
        LockPicking,
        Disguise,
        Assassination,
        Deception,
        Seduction,


        }

    }
}
