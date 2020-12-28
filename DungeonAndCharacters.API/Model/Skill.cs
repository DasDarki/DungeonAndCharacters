namespace DungeonAndCharacters.API.Model
{
    /// <summary>
    /// The skills defines specific predefined actions the character can do.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// The name of the skill.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the skill.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The value of the skill.
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Whether the character uses this skill as proficiency and gains proficiency bonuses
        /// or not.
        /// </summary>
        public bool IsProficiency { get; set; }
    }
}