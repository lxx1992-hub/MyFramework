using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// �¼���������ע�ᣬע��������
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
                if (dic.ContainsKey(command.GetType())) Debug.LogError("�����ظ�ע������");
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
            Debug.LogWarning("�������");
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
