using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using YummiUIHarness;

namespace MetadataBoost
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency(UIHarness.Guid)]
    public class MetadataBoost : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "com.yummi.dsp.metadataboost";
        public const string PLUGIN_NAME = "元神启动 (Metadata Boost)";
        public const string PLUGIN_VERSION = "0.0.0";
        public const string PageKey = "metadata_cheats";
        public const string PageTitleZh = "元数据作弊";
        public const string PageTitleEn = "Metadata Cheats";

        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);
        internal static ManualLogSource Log;
        internal static ConfigEntry<bool> AutoOpenOnEnter;

        private const float BoostButtonWidth = 200f;

        private void Awake()
        {
            Log = Logger;
            AutoOpenOnEnter = Config.Bind("General", "AutoOpenOnEnter", true,
                "Open this page in the Yummi panel after entering a game. | 进入游戏后自动打开 Yummi 面板的本页。");

            UIHarness.RegisterPage(PageKey, PageTitleZh, PageTitleEn)
                .AddCheckbox(AutoOpenOnEnter, "进入游戏后自动打开本页", "Open this page after entering game")
                .AddLabel(
                    "为 6 种矩阵各增加等量的生产和消耗，可用元数据不变。F9 打开/关闭本页。",
                    "Add equal production and consumption for all 6 matrix types; available Metadata unchanged. F9 toggles this page.")
                .AddButton("1万 矩阵", "10k matrices", () => MetadataBoostPage.Boost(10000), BoostButtonWidth)
                .AddButton("1亿 矩阵", "100M matrices", () => MetadataBoostPage.Boost(100000000), BoostButtonWidth)
                .AddButton("10亿 矩阵", "1B matrices", () => MetadataBoostPage.Boost(1000000000), BoostButtonWidth);

            harmony.PatchAll(typeof(MetadataBoostPage));
            Log.LogInfo($"{PLUGIN_NAME} v{PLUGIN_VERSION} 已加载");
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }
}
