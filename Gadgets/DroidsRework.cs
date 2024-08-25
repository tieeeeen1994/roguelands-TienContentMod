using GadgetCore.API;

namespace TienContentMod.Gadgets
{
    [Gadget(GADGET_NAME, true)]
    public class DroidsRework : TienGadget<DroidsRework>
    {
        public const string GADGET_NAME = "Droids Rework";

        public override string ConfigVersion => "2.1.0";

        protected override string GadgetDescription =>
            "- Droids are now affected by level scaling.\n" +
            "- Due to scaling, the vanilla base stats are too high, so they are adjusted.";

        protected override void Initialize()
        {
            Logger.Log($"{GADGET_NAME} v{Info.Mod.Version}");
        }
    }
}
