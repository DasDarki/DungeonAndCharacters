using DungeonAndCharacters.API.UI.Layout;

namespace DungeonAndCharacters.API.UI.Table
{
    /// <summary>
    /// The cell is a part of a <see cref="ITableRow"/> which holds data for the table.
    /// Use <see cref="SetupSettings.SetHeaderCell"/> to change if this cell is a header.
    /// </summary>
    public interface ITableCell : IParent
    {
    }
}