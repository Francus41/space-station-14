using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.MenuBar;

public sealed class MenuBarUIController : UIController
{
    public override void Initialize()
    {
        base.Initialize();
        UIManager.LoadController<GameTopMenuBarController>();
    }
} 