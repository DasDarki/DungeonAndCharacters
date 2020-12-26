using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Layout;

namespace DungeonAndCharacters.UI.Pages
{
    internal class DashboardPage : Page
    {
        internal ICard ListCard { get; }

        internal DashboardPage() : base("Dashboard")
        {
            IColumn column = Columns.Create<IColumn>();
            ListCard = column.Create<ICard>();
            ListCard.Header = "Deine Charaktere";
            ListCard.AddFooterButton("Charakter erstellen", OnCharacterCreate);
        }

        private void OnCharacterCreate()
        {
            
        }
    }
}
