using Content.Shared._Sunrise.Mentor.Components;
using Content.Shared._Sunrise.Mentor.Events;
using Content.Shared._Sunrise.Mentor.Systems;
using Robust.Server.Player;
using Robust.Shared.Player;

namespace Content.Server._Sunrise.Mentor.Systems;

public sealed class MentorSystem : SharedMentorSystem
{
    [Dependency] private readonly IPlayerManager _playerManager = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeNetworkEvent<MentorHelpMessage>(OnMentorHelpMessage);
    }

    private void OnMentorHelpMessage(MentorHelpMessage message, EntitySessionEventArgs args)
    {
        var sender = args.SenderSession;
        var senderName = sender.Name;
        var senderId = sender.UserId;

        // Find an available mentor
        var mentor = FindAvailableMentor();
        if (mentor == null)
        {
            // No mentors available, send to all admins
            foreach (var admin in _playerManager.Sessions)
            {
                if (admin.AttachedEntity == null || !IsMentor(admin))
                    continue;

                RaiseNetworkEvent(new MentorHelpMessage(senderId, $"[MENTOR HELP] {senderName}: {message.Message}"), admin.ConnectedClient);
            }
        }
        else
        {
            // Send to specific mentor
            RaiseNetworkEvent(new MentorHelpMessage(senderId, $"[MENTOR HELP] {senderName}: {message.Message}"), mentor.ConnectedClient);
        }
    }

    private IPlayerSession? FindAvailableMentor()
    {
        foreach (var session in _playerManager.Sessions)
        {
            if (session.AttachedEntity == null || !IsMentor(session))
                continue;

            return session;
        }

        return null;
    }
} 