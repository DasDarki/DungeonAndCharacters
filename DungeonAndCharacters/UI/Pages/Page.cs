using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Layout;

namespace DungeonAndCharacters.UI.Pages
{
    internal abstract class Page
    {
        public string Text { get; }
        
        protected IParent Container { get; }

        protected IParent Columns { get; }

        protected Page(string text)
        {
            Text = text;
            Container = MainForm.Instance.Window.Pages.Create<IParent>();
            Container.Visible = false;
            Columns = Container.Create<IParent>(null, SetupSettings.Default("columns is-centered"));
        }

        internal void ToggleVisiblity(bool visible)
        {
            Container.Visible = visible;
        }
    }
}