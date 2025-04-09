using Content.Client._Sunrise.Mentor.Components;
using Robust.Shared.Player;

namespace Content.Client._Sunrise.Mentor.Systems;

public abstract class SharedMentorSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<MentorComponent, ComponentInit>(OnMentorInit);
    }

    private void OnMentorInit(EntityUid uid, MentorComponent component, ComponentInit args)
    {
        // Initialize mentor state
        if (component.MentorId == string.Empty)
        {
            if (TryComp<ActorComponent>(uid, out var actor))
            {
                component.MentorId = actor.PlayerSession.UserId.UserId.ToString();
            }
        }
    }

    public bool IsMentor(EntityUid uid)
    {
        return HasComp<MentorComponent>(uid);
    }

    public bool IsMentor(ICommonSession session)
    {
        if (session.AttachedEntity == null)
            return false;

        return IsMentor(session.AttachedEntity.Value);
    }
} 