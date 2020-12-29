using System.Collections.Generic;
using DungeonAndCharacters.API.Traits;

namespace DungeonAndCharacters.API.Model
{
    /// <summary>
    /// The race describes on the one hand the appearance, as well as the general customs of a <see cref="Character"/>,
    /// on the other hand, however, also enables this certain abilities as well as bonuses.
    /// </summary>
    public abstract class Race
    {
        /// <summary>
        /// The name of the race.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the race.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// A list containing all traits coming with this race.
        /// </summary>
        public List<Trait> Traits { get; set; } = new List<Trait>();
    }
}