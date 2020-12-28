namespace DungeonAndCharacters.API.Model.Characteristics
{
    /// <summary>
    /// The background describes the past or the actions of the past that a <see cref="Character"/> lived through at the time.
    /// </summary>
    public abstract class Background
    {
        /// <summary>
        /// The name of the background.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the background.
        /// </summary>
        public string Description { get; set; }
    }
}