using DungeonAndCharacters.API.Converters;
using Newtonsoft.Json;

namespace DungeonAndCharacters.API.Traits
{
    /// <summary>
    /// A trait adds specific abilities to a character. Traits can be passive or active.
    /// </summary>
    public class Trait
    {
        /// <summary>
        /// The name of the trait.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the trait.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The action of the trait.
        /// </summary>
        [JsonConverter(typeof(TraitActionConverter))]
        public ITraitAction Action { get; set; }
    }
}