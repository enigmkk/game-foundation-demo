#if UNITY_ANDROID && !UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astra.Foundation
{
    public class AndroidPlatform : Platform
    {
        public AndroidPlatform() : base()
        {
            
        }
        AndroidJavaClass m_foundationBridge;
        private string m_gaid
        {
            get
            {
                return Astra.Device.Ids.Instance.GAID;
            }
        }
        public override string UUID
        {
            get
            {
                if(!string.IsNullOrEmpty(m_gaid))
                {
                    return m_gaid;
                }
                return DeviceId;
            }
        }
        public override void Initialize()
        {
            base.Initialize();
            m_foundationBridge = new AndroidJavaClass("com.astra.foundation.FoundationBridge");
            m_foundationBridge.CallStatic("start");
            VersionCode = m_foundationBridge.CallStatic<string>("getVersionCode");
        }
        private string m_internalPath = null;
        public override string GetFilesRootPath()
        {
            if (m_internalPath != null) return m_internalPath;
            try
            {
                using (AndroidJavaObject filesDir = MainActivity.Call<AndroidJavaObject>("getFilesDir"))
                {
                    m_internalPath = filesDir.Call<string>("getAbsolutePath");
                }
            }
            catch (System.Exception e)
            {
                m_internalPath = Application.persistentDataPath;
            }
            return m_internalPath;
        }
    }
}
#endif