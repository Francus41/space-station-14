using Content.Server._Sunrise.Mentor.Systems;
using Robust.Shared.GameObjects;

namespace Content.Server._Sunrise.Mentor;

public sealed class MentorServerModule : ServerModule
{
    public override void Init()
    {
        base.Init();
        IoCManager.Resolve<IEntitySystemManager>().LoadExtraSystemType<MentorSystem>();
    }
} 