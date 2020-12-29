using System.Collections.Generic;
using DungeonAndCharacters.API.Traits;

namespace DungeonAndCharacters.API.Model
{
    /// <summary>
    /// The class describes what the character can do
    /// and which abilities the character has.
    /// </summary>
    public abstract class Class
    {
        /// <summary>
        /// The name of the class.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the class.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The current selected level of the class.
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// A list containing all traits coming with this class.
        /// </summary>
        public List<Trait> Traits { get; set; } = new List<Trait>();
         
    }
}