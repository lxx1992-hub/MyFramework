using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态机,挂载到游戏物体上
/// </summary>
namespace MyFramework
{
    public class FSM:UnitySingleton<FSM>
    {
        protected Dictionary<Type, IState> allState = new Dictionary<Type, IState>();
        protected IState current;
        protected override void Awake()
        {
            base.Awake();
            Init();
        }
        protected virtual void Init()
        {
            foreach (var state in allState.Values)
            {
                state.Init();
            }
        }
        protected virtual void Update()
        {
            if (current != null) current.OnExecute();
        }
        protected virtual void AddState<T>()where T:IState,new()
        {
            if (allState.TryGetValue(typeof(T), out IState t1))
            {
                Debug.LogError("状态已存在");
                return;
            }
             T t = new T();
            allState.Add(t.GetType(), t);
        }
        protected virtual void ChangeState<T>() where T : IState, new()
        {
            if (current != null)
            {
                current.OnExit();
                IState t;
                if (allState.TryGetValue(typeof(T),out t))
                {
                    current = t;
                    current.OnEnter();
                    return;
                }
                Debug.LogError("未找到此状态");
            }
        }
        protected virtual void RemoveState<T>() where T : IState, new()
        {
            if (allState.TryGetValue(typeof(T), out IState t))
            {
                allState.Remove(typeof(T));
                return;
            }
            Debug.LogError("未找到该状态");
        }
    }
}
