using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// unity����ģ��
/// </summary>
namespace MyFramework
{
    public class UnitySingleton<T>:MonoBehaviour where T:UnitySingleton<T>
    {
        public static T Instance;
        private Object myLock = new Object();
        protected virtual void Awake()
        {
            if (Instance == null)
            {
                lock (myLock)
                {
                    T[] objs = GameObject.FindObjectsOfType<T>();
                    if (objs.Length == 0)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        Instance = go.AddComponent<T>();
                    }
                    else if (objs.Length == 1) Instance = objs[0];
                    else Debug.LogWarning("���������ű����ֶ��");
                }
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
