using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace MyFramework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InjectAttribute:Attribute
    {
    }

    public class IOCcontainer
    {
        Dictionary<string, Type> dic = new Dictionary<string, Type>();
        public void Register(Type _interface,Type instance)
        {
            dic.Add(_interface.FullName, instance);
        }
        public T GetInstance<T>()
        {
            if(dic.TryGetValue(typeof(T).FullName,out Type instance))
            {
                return (T)Activator.CreateInstance(instance);
            }
            return default(T);
        }
        public  void InitInjector()
        {
            Assembly assembly= Assembly.GetExecutingAssembly();
            Type[] types=assembly.GetTypes();
            foreach (var type in types)
            {
               MemberInfo[] members= type.FindMembers(MemberTypes.Property,BindingFlags.Default,null,null);
                foreach (var member in members)
                {
                  object[] array= member.GetCustomAttributes(typeof(InjectAttribute), true);
                    if (array.Length > 0)
                    {
                     if( dic.TryGetValue(member.GetType().FullName,out Type value))
                       {
                            PropertyInfo property = member as PropertyInfo;
                            property.SetValue(new object(),Activator.CreateInstance(value));
                       }
                    }
                }        
            }
        }
    }
}
