using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ÆÕÍ¨µ¥ÀýÄ£°å
/// </summary>
namespace MyFramework
{
    public class Singleton<T>where T:Singleton<T>,new()
    {
        private static T instance;
        private static Object myLock=new Object();
        public static T Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null) instance = new T();
                    return instance;
                }
            }
        }
    }
}
