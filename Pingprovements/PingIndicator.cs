using RoR2;
using UnityEngine;

namespace Pingprovements
{
    public class PingIndicator
    {
        /// <summary>
        /// Configuration instance
        /// </summary>
        private static PingprovementsConfig _config;
        
        public PingIndicator(Pingprovements plugin)
        {
            _config = plugin.GetConfig();
        }

        public void Update(On.RoR2.UI.PingIndicator.orig_Update orig, RoR2.UI.PingIndicator self)
        {
            LocalUser localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser != null)
            {
                if (_config.ShowPingDistance.Value && localUser.cachedBody)
                {
                    Vector3 origin = new Vector3(0,0,0);
                    origin = localUser.cachedBody.footPosition;

                    float distance = Vector3.Distance(origin, self.transform.position);
                    int index = self.pingText.text.IndexOf((char)0x200B);
                    string sub = index >= 0 ? self.pingText.text.Substring(0, index) : self.pingText.text;
                    self.pingText.text = sub + (char) 0x200B + $" ({distance:0.0}m)";   
                }

                if (_config.HideOffscreenPingText.Value)
                {
                    if (!localUser.cameraRigController.sceneCam.IsObjectVisible(self.transform))
                    {
                        self.pingText.alpha = 0;
                    }
                    else
                    {
                        self.pingText.alpha = 1;
                    }   
                }    
            }

            if (self.pingTarget)
            {
                BarrelInteraction barrelInteraction = self.pingTarget.GetComponent<BarrelInteraction>();
                if (barrelInteraction)
                {
                    if (barrelInteraction.Networkopened)
                    {
                        Object.Destroy(self.gameObject);
                    }
                }    
            }

            orig(self);
        }
    }
}