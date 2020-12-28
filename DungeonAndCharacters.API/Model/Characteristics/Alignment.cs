namespace DungeonAndCharacters.API.Model.Characteristics
{
    /// <summary>
    /// The alignment is composed of the two aspects of moral attitude as well as attitude towards the law.
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// Belonging to moral as well as law attitude.
        /// </summary>
        [Value("Neutral")]
        Neutral,
        /// <summary>
        /// Belonging to moral attitude.
        /// </summary>
        [Value("Gut")]
        Good, 
        /// <summary>
        /// Belonging to moral attitude.
        /// </summary>
        [Value("Böse")]
        Evil,
        /// <summary>
        /// Belonging to law attitude.
        /// </summary>
        [Value("Rechtmäßig")]
        Lawful, 
        /// <summary>
        /// Belonging to law attitude.
        /// </summary>
        [Value("Chaotisch")]
        Chaotic
    }
}