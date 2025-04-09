using Content.Client._Sunrise.Mentor.UI.Bwoink;
using Content.Client.UserInterface.Systems.MenuBar.Widgets;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Input.Binding;

namespace Content.Client.UserInterface.Systems.MenuBar;

public sealed class GameTopMenuBarController : UIController
{
    [Dependency] private readonly IUserInterfaceManager _uiManager = default!;

    private GameTopMenuBar? _gameTopMenuBar;

    public override void Initialize()
    {
        base.Initialize();

        var gameplayStateLoad = UIManager.GetUIController<GameplayStateLoadController>();
        gameplayStateLoad.OnScreenLoad += OnScreenLoad;
        gameplayStateLoad.OnScreenUnload += OnScreenUnload;

        CommandBinds.Builder
            .Bind(ContentKeyFunctions.OpenMHelp, InputCmdHandler.FromDelegate(_ => OpenMHelp()))
            .Register<GameTopMenuBarController>();
    }

    private void OnScreenLoad()
    {
        _gameTopMenuBar = UIManager.GetActiveUIWidget<GameTopMenuBar>();
        _gameTopMenuBar.MHelpButton.OnPressed += _ => OpenMHelp();
    }

    private void OnScreenUnload()
    {
        if (_gameTopMenuBar != null)
        {
            _gameTopMenuBar.MHelpButton.OnPressed -= _ => OpenMHelp();
            _gameTopMenuBar = null;
        }
    }

    private void OpenMHelp()
    {
        var window = new MentorBwoinkWindow();
        _uiManager.WindowRoot.AddChild(window);
        window.Open();
    }
} 