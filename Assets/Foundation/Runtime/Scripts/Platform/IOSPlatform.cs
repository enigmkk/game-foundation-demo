#if UNITY_IOS && !UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astra.Foundation
{
    public class IOSPlatform : Platform
    {
        public IOSPlatform() : base()
        {
            
        }
        private string m_idfa
        {
            get
            {
                return Astra.Device.Ids.Instance.IDFA;
            }
        }
        private string m_idfv
        {
            get
            {
                return Astra.Device.Ids.Instance.IDFV;
            }
        }
        public override string UUID
        {
            get
            {
                if(!string.IsNullOrEmpty(m_idfa))
                {
                    return m_idfa;
                }
                if(!string.IsNullOrEmpty(m_idfv))
                {
                    return m_idfv;
                }
                return DeviceId;
            }
        }
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
#endif