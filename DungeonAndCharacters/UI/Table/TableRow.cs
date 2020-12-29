using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Table;
using DungeonAndCharacters.UI.Layout;

namespace DungeonAndCharacters.UI.Table
{
    internal class TableRow : Parent, ITableRow
    {
        internal TableRow(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
        }

        internal override string GetHTML(string classes)
        {
            return $"<tr class=\"{classes}\" id=\"{ID}\"></tr>";
        }
    }
}