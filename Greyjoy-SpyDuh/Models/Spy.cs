﻿namespace Greyjoy_SpyDuh.Models
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
        Sabatoge = 1,
        Sneaking = 2, 
        LockPicking = 3,
        Disguise = 4,
        Assassination = 5,
        Deception = 6,
        Seduction = 7,
        }

    }
}