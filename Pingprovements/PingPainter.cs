using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace Pingprovements
{
    public class PingPainter
    {
        /// <summary>
        /// Color instances used for the <see cref="PingIndicator"/>s
        /// </summary>
        private readonly Dictionary<string, Color> _colors = new Dictionary<string, Color>();

        /// <summary>
        /// Field containing the config value if tiered ping colors should be used
        /// </summary>
        private readonly bool _tieredInteractablePingColor;

        public PingPainter(PingprovementsConfig config)
        {
            _colors.Add("DefaultPingColor", config.DefaultPingColorConfig.Value.ToColor());
            _colors.Add("DefaultPingSpriteColor", config.DefaultPingSpriteColorConfig.Value.ToColor());
            _colors.Add("EnemyPingColor", config.EnemyPingColorConfig.Value.ToColor());
            _colors.Add("EnemyPingSpriteColor", config.EnemyPingSpriteColorConfig.Value.ToColor());
            _colors.Add("InteractablePingColor", config.InteractablePingColorConfig.Value.ToColor());
            _colors.Add("InteractablePingSpriteColor", config.InteractablePingSpriteColorConfig.Value.ToColor());
            _tieredInteractablePingColor = config.TieredInteractablePingColor.Value;
        }

        /// <summary>
        /// Sets the ping text and sprite color for a given <see cref="PingIndicator"/>
        /// </summary>
        /// <param name="pingIndicator">Target <see cref="PingIndicator"/></param>
        /// <param name="pingType">Type of the ping</param>
        public void SetPingIndicatorColor(RoR2.UI.PingIndicator pingIndicator, RoR2.UI.PingIndicator.PingType pingType)
        {
            SpriteRenderer sprRenderer = new SpriteRenderer();
            Color textColor = Color.black;
            Color spriteColor = Color.black;

            switch (pingType)
            {
                case RoR2.UI.PingIndicator.PingType.Default:
                    sprRenderer = pingIndicator.defaultPingGameObjects[0].GetComponent<SpriteRenderer>();
                    textColor = _colors["DefaultPingColor"];
                    spriteColor = _colors["DefaultPingSpriteColor"];
                    break;
                case RoR2.UI.PingIndicator.PingType.Enemy:
                    sprRenderer = pingIndicator.enemyPingGameObjects[0].GetComponent<SpriteRenderer>();
                    textColor = _colors["EnemyPingColor"];
                    spriteColor = _colors["EnemyPingSpriteColor"];
                    break;
                case RoR2.UI.PingIndicator.PingType.Interactable:
                    sprRenderer = pingIndicator.interactablePingGameObjects[0].GetComponent<SpriteRenderer>();
                    if (_tieredInteractablePingColor)
                    {
                        Color pickupColor = GetTargetTierColor(pingIndicator.pingTarget);
                        textColor = pickupColor;
                        spriteColor = pickupColor;    
                    }
                    else
                    {
                        textColor = _colors["InteractablePingColor"];
                        spriteColor = _colors["InteractablePingSpriteColor"];
                    }
                    break;
            }

            pingIndicator.pingText.color = textColor;
            sprRenderer.color = spriteColor;
        }

        /// <summary>
        /// Method to get the interactable tier color from a ping target
        /// </summary>
        /// <param name="gameObject">The ping target</param>
        /// <returns>An Color instance of the tier color</returns>
        private Color GetTargetTierColor(GameObject gameObject)
        {
            Color color = Color.black;
            
            ShopTerminalBehavior shopTerminal = gameObject.GetComponent<ShopTerminalBehavior>();
            if (shopTerminal)
            {
                PickupIndex pickupIndex = shopTerminal.CurrentPickupIndex();
                PickupDef pickup = PickupCatalog.GetPickupDef(pickupIndex);

                if (pickup != null)
                {
                    color = pickup.baseColor;    
                }
            }
            
            GenericPickupController pickupController = gameObject.GetComponent<GenericPickupController>();
            if (pickupController)
            {
                PickupDef pickup = PickupCatalog.GetPickupDef(pickupController.pickupIndex);
                
                if (pickup != null)
                {
                    color = pickup.baseColor;    
                }
            }
            
            PurchaseInteraction purchaseInteraction = gameObject.GetComponent<PurchaseInteraction>();
            if (purchaseInteraction)
            {
                CostTypeDef costType = CostTypeCatalog.GetCostTypeDef(purchaseInteraction.costType);
                color = ColorCatalog.GetColor(costType.colorIndex);
            }

            PickupIndexNetworker pickupIndexNetworker = gameObject.GetComponent<PickupIndexNetworker>();
            if (pickupIndexNetworker)
            {
                PickupDef pickup = PickupCatalog.GetPickupDef(pickupIndexNetworker.NetworkpickupIndex);
                
                if (pickup != null)
                {
                    color = pickup.baseColor;    
                }
            }

            if (color == Color.black)
            {
                color = _colors["InteractablePingColor"];
            }

            return color;
        }
    }
}