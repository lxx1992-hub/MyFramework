using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对象池管理
/// </summary>
namespace MyFramework
{
    public class PoolMgr : Singleton<PoolMgr>
    {
        GameObjectPool goPool = new GameObjectPool();
        ReferencePool refPool = new ReferencePool();
        public T TakeReference<T>() where T : class, new()
        {
           return refPool.Take<T>();
        }
        public void RecycleReference<T>(T obj)where T:class
        {
            refPool.Recycle(obj);
        }
        public GameObject TakeGameObject<T>(string name)where T:MonoBehaviour
        {
            return goPool.Take<T>(name);
        }
        public void RecycleGameObject(GameObject obj)
        {
            goPool.Recycle(obj);
        }
        public void ClearReferencePool()
        {
            refPool.Clear();
        }
        public void ClearGameObjectPool()
        {
            goPool.Clear();
        }
    }
}
