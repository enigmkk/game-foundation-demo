using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astra.Foundation
{
    public class Foundation : Singleton<Foundation>
    {
        protected override void InitSingleton()
        {
            
        }
        void Initialize()
        {
            Astra.Device.Ids.Instance.Init();
            Platform.Instance.Initialize();
        }
    }
}
