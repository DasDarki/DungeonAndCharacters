using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Layout;
using DungeonAndCharacters.API.UI.Table;
using DungeonAndCharacters.UI.Layout;

namespace DungeonAndCharacters.UI.Table
{
    internal class Table : Parent, ITable
    {
        public IParent Header { get; }
        
        public IParent Footer { get; }
        
        internal Table(IElement parent, string id, SetupSettings settings) : base(parent, id, settings)
        {
            Header = new Parent(this, id + "_head", SetupSettings.Default());
            Footer = new Parent(this, id + "_foot", SetupSettings.Default());
        }

        internal override string GetHTML(string classes)
        {
            return $"<table class=\"table {classes}\" id=\"{ID}_table\"><thead id=\"{ID}_head\"></thead><tbody id=\"{ID}\"></tbody><tfoot id=\"{ID}_foot\"></tfoot></table>";
        }

        public override void Destroy()
        {
            if (DenyDestroy) return;
            CefUI.CreatedElements.Remove(this);
            CefUI.DestroyElement(ID + "_table");
        }
    }
}