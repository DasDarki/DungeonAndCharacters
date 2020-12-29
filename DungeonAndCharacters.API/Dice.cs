namespace DungeonAndCharacters.API
{
    /// <summary>
    /// The dice enum is used for specific special values for dice rolling.
    /// </summary>
    public enum Dice
    {
#pragma warning disable 1591
        [Value("W3")]
        D3 = 3, 
        [Value("W4")]
        D4 = 4, 
        [Value("W6")]
        D6 = 6, 
        [Value("W8")]
        D8 = 8, 
        [Value("W10")]
        D10 = 10, 
        [Value("W20")]
        D20 = 20, 
        [Value("W100")]
        D100 = 100
#pragma warning restore 1591
    }
}