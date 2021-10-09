using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 事件管理，负责注册，注销，触发
/// </summary>
namespace MyFramework
{
    public class EventMgr : Singleton<EventMgr>
    {
        Dictionary<EventType, Dictionary<Type,ICommand>> events = new Dictionary<EventType, Dictionary<Type, ICommand>>();
        public void Register(EventType type,ICommand command)
        {
            Dictionary<Type,ICommand> dic;
            if(events.TryGetValue(type,out dic))
            {
                if (dic.ContainsKey(command.GetType())) Debug.LogError("不能重复注册命令");
                else  dic.Add(command.GetType(),command);
            }
            else
            {
                dic = new Dictionary<Type, ICommand>();
                dic.Add(command.GetType(), command);
                events.Add(type, dic);
            }
        }
        public void UnRegister(EventType type,ICommand command)
        {

            Dictionary<Type, ICommand> dic;
            if (events.TryGetValue(type, out dic))
            {
                dic.Remove(command.GetType());
                if (dic.Count == 0) events.Remove(type);
                return;
            }
            Debug.LogWarning("命令不存在");
        }
        public void Clear()
        {
            foreach (var item in events.Values)
            {
                item.Clear();
            }
            events.Clear();
        }
        public void Trigger(EventType type)
        {
            Dictionary<Type, ICommand> dic;
            if (events.TryGetValue(type, out dic))
            {
                foreach (var command in dic.Values)
                {
                    command.Execute();
                }
            }
         }
        public void Trigger(EventType type,UnityEngine.Object obj)
        {

            Dictionary<Type, ICommand> dic;
            if (events.TryGetValue(type, out dic))
            {
                foreach (var command in dic.Values)
                {
                    command.Execute(obj);
                }
            }
        }
    }
}
