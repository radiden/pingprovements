using BepInEx;
using UnityEngine.SceneManagement;

namespace Pingprovements
{
    // [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.pixeldesu.pingprovements", "Pingprovements", "1.7.0")]
    public class Pingprovements : BaseUnityPlugin
    {
        #region Private Fields

        /// <summary>
        /// Configuration instance
        /// </summary>
        private static PingprovementsConfig _config;

        #endregion

        public PingprovementsConfig GetConfig() => _config;

        #region Configuration and Startup

        public Pingprovements()
        {
            _config = new PingprovementsConfig(Config);
        }

        public void Awake()
        {
            PingIndicator pingIndicator = new PingIndicator(this);
            PingerController pingerController = new PingerController(this);

            On.RoR2.PingerController.SetCurrentPing += pingerController.SetCurrentPing;

            On.RoR2.UI.PingIndicator.Update += pingIndicator.Update;

            SceneManager.sceneUnloaded += pingerController.OnSceneUnloaded;
        }

        #endregion
    }
}