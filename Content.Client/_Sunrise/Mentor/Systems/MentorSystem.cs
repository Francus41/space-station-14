using Content.Client._Sunrise.Mentor.UI.Bwoink;
using Content.Client._Sunrise.Mentor.Components;
using Content.Client._Sunrise.Mentor.Systems;
using Robust.Client.Player;
using Robust.Shared.Player;

namespace Content.Client._Sunrise.Mentor.Systems;

public sealed class MentorSystem : SharedMentorSystem
{
    [Dependency] private readonly IPlayerManager _playerManager = default!;

    private MentorBwoinkWindow? _mentorWindow;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeNetworkEvent<MentorHelpMessage>(OnMentorHelpMessage);
    }

    private void OnMentorHelpMessage(MentorHelpMessage message)
    {
        if (_mentorWindow == null)
        {
            _mentorWindow = new MentorBwoinkWindow();
            _mentorWindow.Closed += () => _mentorWindow = null;
        }

        _mentorWindow.ReceiveMessage(message.Message);
        _mentorWindow.Open();
    }

    public void SendMentorHelpMessage(string message)
    {
        if (_playerManager.LocalPlayer?.Session is not { } session)
            return;

        RaiseNetworkEvent(new MentorHelpMessage(session.UserId, message));
    }
} 