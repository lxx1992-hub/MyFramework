using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 引用对象池
/// </summary>
namespace MyFramework
{ 
    public class ReferencePool
    {
        Dictionary<Type, Queue> pool = new Dictionary<Type, Queue>();
        public T Take<T>() where T : class, new()
        {
            Queue queue;
            if (pool.TryGetValue(typeof(T), out queue))
            {
                if (queue.Count > 0) return queue.Dequeue() as T;
                return new T();
            }
            return new T();
        }
        public void Recycle<T>(T obj) where T:class
        {
            Queue queue;
            if (pool.TryGetValue(obj.GetType(), out queue))
            {
                queue.Enqueue(obj);
            }
            else
            {
                queue = new Queue();
                queue.Enqueue(obj);
                pool.Add(obj.GetType(), queue);
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

