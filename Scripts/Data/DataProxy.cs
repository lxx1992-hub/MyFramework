using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
/// <summary>
/// 数据代理，管理所有数据相关逻辑
/// </summary>
namespace MyFramework
{
    public class DataProxy :Singleton<DataProxy>
    {
        Dictionary<Type, Data> datas = new Dictionary<Type, Data>();
        public void Init()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(Data)))
                {
                    datas.Add(type, Activator.CreateInstance(type) as Data);
                }
            }
        }
        public T GetData<T>()where T:Data
        {
            Data data;
            if(datas.TryGetValue(typeof(T),out data))
                {
                return data as T;
            }
            Debug.LogError("找不到该数据类型");
            return null;
        }
        public void Clear()
        {
            datas.Clear(); 
        }
    }
}
