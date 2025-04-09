using Robust.Shared.Player;

namespace Content.Shared._Sunrise.Mentor.Events;

public sealed class MentorHelpMessage : EntityEventArgs
{
    public NetUserId UserId { get; }
    public string Message { get; }

    public MentorHelpMessage(NetUserId userId, string message)
    {
        UserId = userId;
        Message = message;
    }
} 