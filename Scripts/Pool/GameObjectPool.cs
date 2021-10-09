using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 游戏物体对象池
/// </summary>
namespace MyFramework
{
    public class GameObjectPool
    {
        Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();
        public GameObject Take<T>(string name)where T:MonoBehaviour
        {
            Queue<GameObject> queue;
            GameObject obj;
            if(pool.TryGetValue(name, out queue))
            {
                if (queue.Count > 0) obj= queue.Dequeue();
                else obj=Game.Entity.CreatEntity<T>(name);
            }
            else obj= Game.Entity.CreatEntity<T>(name);
            obj.SetActive(true);
            return obj;
        }
        public void Recycle(GameObject obj)
        {
            Queue<GameObject> queue;
            obj.SetActive(false);
            if (pool.TryGetValue(obj.name, out queue))
            {
                queue.Enqueue(obj);
            }
            else
            {
                queue = new Queue<GameObject>();
                queue.Enqueue(obj);
                pool.Add(obj.name, queue);
            }
        }
        public void Clear()
        {
            foreach (var item in pool.Values)
            {
                item.Clear();
            }
            pool.Clear();
        }
    }
}
