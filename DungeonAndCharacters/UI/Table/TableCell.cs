using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Table;
using DungeonAndCharacters.UI.Layout;

namespace DungeonAndCharacters.UI.Table
{
    internal class TableCell : Parent, ITableCell
    {
        private readonly bool _isHeader;
        
        internal TableCell(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
            _isHeader = settings.IsHeaderCell;
        }

        internal override string GetHTML(string classes)
        {
            string data = _isHeader ? "h" : "d";
            return $"<t{data} class=\"{classes}\" id=\"{ID}\"></t{data}>";
        }
    }
}