using Content.Client._Sunrise.Mentor.Systems;
using Robust.Shared.GameObjects;

namespace Content.Client._Sunrise.Mentor;

public sealed class MentorClientModule : ClientModule
{
    public override void Init()
    {
        base.Init();
        IoCManager.Resolve<IEntitySystemManager>().LoadExtraSystemType<MentorSystem>();
    }
} 