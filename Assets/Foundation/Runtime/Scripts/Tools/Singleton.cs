using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astra.Foundation
{
    public abstract class Singleton<T> where T: Singleton<T>, new()
    {
        private static T s_instance;
        public static T Instance
        {
            get
            {
                if(null == s_instance)
                {
                    s_instance = new T();
                    s_instance.InitSingleton();
                }
                return s_instance;
            }
        }
        protected abstract void InitSingleton();
    } 
}

