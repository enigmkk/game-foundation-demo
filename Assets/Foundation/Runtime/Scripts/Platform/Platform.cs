using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astra.Foundation
{
    public abstract class Platform
    {
        private static Platform s_instance;

        public static Platform Instance
        {
            get
            {
                if (null == s_instance)
                {
#if UNITY_ANDROID && !UNITY_EDITOR
                    s_instance = new AndroidPlatform();
#elif UNITY_IOS && !UNITY_EDITOR
                    s_instance = new IOSPlatform();
#else
                    s_instance = new DefaultPlatform();
#endif
                }
                return s_instance;
            }
        }
        public Platform()
        {
            
        }
        public virtual bool NetworkState { get; set; }
        public virtual string Version { get; set; }
        public virtual string VersionCode { get; set; }
        public virtual string UUID { get; set; }
        public virtual string DeviceId { get; set; }
        public virtual void Initialize()
        {
            Astra.Network.NetworkMonitor.OnChanged = OnNetworkChanged;
            DeviceId = Astra.Device.Ids.Instance.DeviceId;
        }
        public virtual string GetFilesRootPath()
        {
            return Application.persistentDataPath;
        }
        public void OnNetworkChanged(Astra.Network.NetworkStatus netstate)
        {
            NetworkState = netstate != Astra.Network.NetworkStatus.None ? true: false;
        }
    }
}
