using HarmonyLib;
using UnityEngine;
using CatUIPanel;

namespace MetadataBoost
{
    [HarmonyPatch]
    public static class MetadataBoostPage
    {
        private static readonly int[] MatrixIds = { 6001, 6002, 6003, 6004, 6005, 6006 };
        private static readonly string[] MatrixNames = { "电磁", "能量", "结构", "信息", "引力", "宇宙" };

        [HarmonyPostfix]
        [HarmonyPatch(typeof(GameMain), nameof(GameMain.Begin))]
        public static void OpenOnEnter()
        {
            if (GameMain.instance == null || GameMain.instance.isMenuDemo || !MetadataBoost.AutoOpenOnEnter.Value)
            {
                return;
            }
            UIPanel.OpenPage(MetadataBoost.PageKey);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIGame), "_OnUpdate")]
        public static void ToggleKey()
        {
            if (Input.GetKeyDown(KeyCode.F9) && !VFInput.inputing)
            {
                UIPanel.TogglePage(MetadataBoost.PageKey);
            }
        }

        public static void Boost(int amount)
        {
            if (GameMain.data == null || GameMain.data.gameDesc == null)
            {
                MetadataBoost.Log.LogWarning("游戏未运行");
                return;
            }

            PropertySystem propertySystem = DSPGame.propertySystem;
            if (propertySystem == null)
            {
                MetadataBoost.Log.LogWarning("PropertySystem 不存在");
                return;
            }

            long seedKey = GameMain.data.gameDesc.seedKey64;
            for (int i = 0; i < MatrixIds.Length; i++)
            {
                int itemId = MatrixIds[i];

                int currentProduction = propertySystem.GetItemProduction(seedKey, itemId);
                propertySystem.SetItemProduction(seedKey, itemId, currentProduction + amount);
                GameMain.data.history.propertyData.AddItemProduction(itemId, amount);

                int currentConsumption = propertySystem.GetItemConsumption(seedKey, itemId);
                propertySystem.SetItemConsumption(seedKey, itemId, currentConsumption + amount);
                GameMain.data.history.propertyData.AddItemConsumption(itemId, amount);

                MetadataBoost.Log.LogInfo($"已增加 {MatrixNames[i]}矩阵 {amount} 点生产和消耗");
            }

            string amountStr = amount >= 100000000 ? (amount / 100000000) + "亿" : (amount >= 10000 ? (amount / 10000) + "万" : amount.ToString());
            UIRealtimeTip.Popup($"已增加 6 种矩阵各 {amountStr} 点生产和消耗");
        }
    }
}
