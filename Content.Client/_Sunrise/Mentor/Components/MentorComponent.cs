using Robust.Shared.GameStates;

namespace Content.Client._Sunrise.Mentor.Components;

[RegisterComponent, NetworkedComponent]
public sealed partial class MentorComponent : Component
{
    [DataField("mentorId")]
    public string MentorId = string.Empty;

    [DataField("mentorName")]
    public string MentorName = string.Empty;

    [DataField("isActive")]
    public bool IsActive = true;
} 