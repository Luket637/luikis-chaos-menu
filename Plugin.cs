using BepInEx;
using UnityEngine;

namespace LukisChaosMenu
{
    [BepInPlugin(
        PluginInfo.GUID,
        PluginInfo.Name,
        PluginInfo.Version
    )]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject menuObject;

        private void Start()
        {
            Logger.LogInfo("Lukis Chaos Menu loaded!");

            menuObject = new GameObject("Lukis Chaos Menu");

            Menu menu = menuObject.AddComponent<Menu>();

            menu.Initialize();
        }
    }
}
