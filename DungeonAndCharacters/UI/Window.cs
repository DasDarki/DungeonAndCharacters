using DungeonAndCharacters.API.UI;
using DungeonAndCharacters.API.UI.Sidebar;
using DungeonAndCharacters.UI.Layout;
using DungeonAndCharacters.UI.Pages;

namespace DungeonAndCharacters.UI
{
    internal class Window
    {
        internal Parent Sidebar { get; }

        internal Parent Pages { get; }

        internal DashboardPage Dashboard { get; private set; }

        internal Window()
        {
            Sidebar = new Parent(null, "sidebar", SetupSettings.Default());
            Pages = new Parent(null, "pages", SetupSettings.Default());
        }

        internal void Initialize()
        {
            InitializePages();
            InitializeSidebar();
        }

        private void InitializePages()
        {
            Dashboard = new DashboardPage();
        }

        private void InitializeSidebar()
        {
            ISidebarGroup mainGroup = Sidebar.Create<ISidebarGroup>(null, SetupSettings.Default().SetLabel("Dungeon and Characters"));
            AddPageToggle(mainGroup, Dashboard, true);
        }

        private void AddPageToggle(ISidebarGroup group, Page page, bool isDefault = false)
        {
            ISidebarItem item = group.Create<ISidebarItem>(null, SetupSettings.Default().SetText(page.Text));
            item.Selected += () => { page.ToggleVisiblity(true); };
            item.Unselected += () => { page.ToggleVisiblity(false); };
            if (isDefault) item.Select();
        }
    }
}
