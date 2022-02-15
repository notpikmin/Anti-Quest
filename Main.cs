using HarmonyLib;
using MelonLoader;
using System.Reflection;

namespace anti_quest
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            HarmonyInstance.Patch(
                typeof(NetworkManager).GetMethod(nameof(NetworkManager.Method_Public_Void_Player_0)),
                typeof(Main).GetMethod(nameof(PrettyGay), BindingFlags.Static | BindingFlags.NonPublic).ToNewHarmonyMethod()
            );
        }

        private static void PrettyGay(ref VRC.Player __0)
        {
            if (__0.field_Private_APIUser_0.IsOnMobile)
            {
                __0.gameObject.active = false;
                MelonLogger.Msg("[AntiQuest] Locally Blocked Quest Player ---> " + __0.prop_APIUser_0.displayName);
            }
        }
    }
}