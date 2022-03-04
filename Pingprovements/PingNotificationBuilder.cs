using RoR2;
using RoR2.UI;
using UnityEngine;

namespace Pingprovements
{
    public class PingNotificationBuilder
    {
        private PingprovementsConfig _config;

        public PingNotificationBuilder(PingprovementsConfig config)
        {
            _config = config;
        }
        
        public void SetUnlockedItemNotification(RoR2.UI.PingIndicator pingIndicator)
        {
            GenericPickupController pickupController = pingIndicator.pingTarget.GetComponent<GenericPickupController>();
            if (pickupController && _config.ShowItemNotification.Value)
            {
                BuildNotification(pickupController.pickupIndex, pingIndicator);
            }

            PurchaseInteraction purchaseInteraction = pingIndicator.pingTarget.GetComponent<PurchaseInteraction>();
            if (purchaseInteraction && _config.ShowItemNotification.Value)
            {
                ShopTerminalBehavior shopTerminalBehavior = purchaseInteraction.GetComponent<ShopTerminalBehavior>();
                if (shopTerminalBehavior && !shopTerminalBehavior.pickupIndexIsHidden)
                {
                    BuildNotification(shopTerminalBehavior.CurrentPickupIndex(), pingIndicator);
                }
            }
        }

        private void BuildNotification(PickupIndex pickupIndex, RoR2.UI.PingIndicator pingIndicator)
        {
            LocalUser localUser = LocalUserManager.GetFirstLocalUser();
            CharacterMaster characterMaster = pingIndicator.pingOwner.GetComponent<CharacterMaster>();
            CharacterMasterNotificationQueue notificationQueueForMaster = CharacterMasterNotificationQueue.GetNotificationQueueForMaster(characterMaster);

            if (localUser.currentNetworkUser.userName ==
                Util.GetBestMasterName(characterMaster))
            {
                if (localUser.userProfile.HasDiscoveredPickup(pickupIndex))
                {
                    PickupDef pickup = PickupCatalog.GetPickupDef(pickupIndex);
                    
                    ItemDef item = ItemCatalog.GetItemDef(pickup.itemIndex);
                    EquipmentDef equip = EquipmentCatalog.GetEquipmentDef(pickup.equipmentIndex);
                    ArtifactDef artifact = ArtifactCatalog.GetArtifactDef(pickup.artifactIndex);

                    if (item != null)
                    {
                        notificationQueueForMaster.PushNotification(new CharacterMasterNotificationQueue.NotificationInfo(item), 6f);
                    }
                    else if (equip != null)
                    {
                        notificationQueueForMaster.PushNotification(new CharacterMasterNotificationQueue.NotificationInfo(equip), 6f);
                    }
                    else if (artifact != null)
                    {
                        notificationQueueForMaster.PushNotification(new CharacterMasterNotificationQueue.NotificationInfo(artifact), 6f);
                    }
                }
            }
        }
    }
}