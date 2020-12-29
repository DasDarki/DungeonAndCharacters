using DungeonAndCharacters.API.UI.Layout;

namespace DungeonAndCharacters.API.UI.Table
{
    /// <summary>
    /// The table is a common HTML structure which allows spreadsheet like ordering of data.
    /// </summary>
    public interface ITable : IParent
    {
        /// <summary>
        /// The header row of the table.
        /// </summary>
        IParent Header { get; }

        /// <summary>
        /// The footer row of the table.
        /// </summary>
        IParent Footer { get; }
    }
}