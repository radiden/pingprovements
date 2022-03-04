using BepInEx.Configuration;

namespace Pingprovements
{
    public class PingprovementsConfig
    {
        public PingprovementsConfig(ConfigFile config)
        {
            DefaultPingLifetime = config.Bind(
                "Durations",
                "DefaultPingLifetime",
                6,
                "Time in seconds how long a regular 'walk to' ping indicator should be shown on the map"
            );

            EnemyPingLifetime = config.Bind(
                "Durations",
                "EnemyPingLifetime",
                8,
                "Time in seconds how long a ping indicator for enemies should be shown on the map"
            );

            InteractablePingLifetime = config.Bind(
                "Durations",
                "InteractablePingLifetime",
                30,
                "Time in seconds how long a ping indicator for interactables should be shown on the map"
            );

            DefaultPingColorConfig = config.Bind(
                "Colors",
                "DefaultPingColor",
                "0.525,0.961,0.486,1.000",
                "Color of the default ping, in UnityEngine.Color R/G/B/A Float format"
            );

            DefaultPingSpriteColorConfig = config.Bind(
                "SpriteColors",
                "DefaultPingSpriteColor",
                "0.527,0.962,0.486,1.000",
                "Color of the default ping sprite, in UnityEngine.Color R/G/B/A Float format"
            );

            EnemyPingColorConfig = config.Bind(
                "Colors",
                "EnemyPingColor",
                "0.820,0.122,0.122,1.000",
                "Color of the enemy ping, in UnityEngine.Color R/G/B/A Float format"
            );

            EnemyPingSpriteColorConfig = config.Bind(
                "SpriteColors",
                "EnemyPingSpriteColor",
                "0.821,0.120,0.120,1.000",
                "Color of the enemy ping sprite, in UnityEngine.Color R/G/B/A Float format"
            );

            InteractablePingColorConfig = config.Bind(
                "Colors",
                "InteractablePingColor",
                "0.886,0.871,0.173,1.000",
                "Color of the interactable ping, in UnityEngine.Color R/G/B/A Float format"
            );

            InteractablePingSpriteColorConfig = config.Bind(
                "SpriteColors",
                "InteractablePingSpriteColor",
                "0.887,0.870,0.172,1.000",
                "Color of the interactable ping sprite, in UnityEngine.Color R/G/B/A Float format"
            );

            ShowPickupText = config.Bind(
                "ShowPingText",
                "Pickups",
                true,
                "Shows item names on pickup pings"
            );

            ShowChestText = config.Bind(
                "ShowPingText",
                "Chests",
                true,
                "Shows item names and cost on chest pings"
            );

            ShowShopText = config.Bind(
                "ShowPingText",
                "ShopTerminals",
                true,
                "Shows item names and cost on shop terminal pings"
            );

            ShowDroneText = config.Bind(
                "ShowPingText",
                "Drones",
                true,
                "Shows drone type on broken drone pings"
            );

            ShowShrineText = config.Bind(
                "ShowPingText",
                "Shrines",
                true,
                "Shows shrine type on shrine pings"
            );
            
            ShowEnemyText = config.Bind(
                "ShowPingText",
                "Enemies",
                true,
                "Shows names on enemy pings"
            );

            ShowPingDistance = config.Bind(
                "ShowPingText",
                "Distance",
                true,
                "Show distance to ping in ping label"
            );

            HideOffscreenPingText = config.Bind(
                "ShowPingText",
                "HideOffscreenPingText",
                true,
                "Hide text of offscreen pings to prevent cluttering"
            );

            ShowItemNotification = config.Bind(
                "Notifications",
                "ShowItemNotification",
                true,
                "Show pickup-style notification with description on ping of an already discovered item"
            );

            TieredInteractablePingColor = config.Bind(
                "Colors",
                "TieredInteractablePingColor",
                true,
                "Color pings in their target tier color"
            );
        }
        
        #region Durations Configuration Options
        
        /// <summary>
        /// Configuration value for the default ping lifetime
        /// </summary>
        public ConfigEntry<int> DefaultPingLifetime { get; set; }
        
        /// <summary>
        /// Configuration value for the enemy ping lifetime
        /// </summary>
        public ConfigEntry<int> EnemyPingLifetime { get; set; }
        
        /// <summary>
        /// Configuration value for the interactable ping lifetime
        /// </summary>
        public ConfigEntry<int> InteractablePingLifetime { get; set; }
        
        #endregion

        #region Colors Configuration Options
        
        /// <summary>
        /// Configuration value for the default ping color
        /// </summary>
        public ConfigEntry<string> DefaultPingColorConfig { get; set; }
        
        /// <summary>
        /// Configuration value for the enemy ping color
        /// </summary>
        public ConfigEntry<string> EnemyPingColorConfig { get; set; }
        
        /// <summary>
        /// Configuration value for the interactable ping color
        /// </summary>
        public ConfigEntry<string> InteractablePingColorConfig { get; set; }
        
        /// <summary>
        /// Configuration value for the interactable ping color
        /// </summary>
        public ConfigEntry<bool> TieredInteractablePingColor { get; set; }
        
        #endregion
        
        #region SpriteColors Configuration Options
        
        /// <summary>
        /// Configuration value for the default ping sprite color
        /// </summary>
        public ConfigEntry<string> DefaultPingSpriteColorConfig { get; set; }
        
        /// <summary>
        /// Configuration value for the enemy ping sprite color
        /// </summary>
        public ConfigEntry<string> EnemyPingSpriteColorConfig { get; set; }
        
        /// <summary>
        /// Configuration value for the interactable ping sprite color
        /// </summary>
        public ConfigEntry<string> InteractablePingSpriteColorConfig { get; set; }
        
        #endregion

        #region ShowPingText Configuration Options
        
        /// <summary>
        /// Configuration value to enable showing shop text on pings
        /// </summary>
        public ConfigEntry<bool> ShowShopText { get; set; }
        
        /// <summary>
        /// Configuration value to enable showing chest text on pings
        /// </summary>
        public ConfigEntry<bool> ShowChestText { get; set; }

        /// <summary>
        /// Configuration value to enable showing pickup text on pings
        /// </summary>
        public ConfigEntry<bool> ShowPickupText { get; set; }

        /// <summary>
        /// Configuration value to enable showing drone text on pings
        /// </summary>
        public ConfigEntry<bool> ShowDroneText { get; set; }
        
        /// <summary>
        /// Configuration value to enable showing shrine text on pings
        /// </summary>
        public ConfigEntry<bool> ShowShrineText { get; set; }
        
        /// <summary>
        /// Configuration value to enable showing enemy names on pings
        /// </summary>
        public ConfigEntry<bool> ShowEnemyText { get; set; }
        
        /// <summary>
        /// Configuration value to enable showing the distance to a ping
        /// </summary>
        public ConfigEntry<bool> ShowPingDistance { get; set; }
        
        /// <summary>
        /// Configuration value to hide the ping label if a ping is offscreen
        /// </summary>
        public ConfigEntry<bool> HideOffscreenPingText { get; set; }
        
        #endregion
        
        #region Notification Configuration Options
        
        /// <summary>
        /// Configuration value to hide the ping label if a ping is offscreen
        /// </summary>
        public ConfigEntry<bool> ShowItemNotification { get; set; }
        
        #endregion
    }
}