using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ״̬��,���ص���Ϸ������
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
                Debug.LogError("״̬�Ѵ���");
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
                Debug.LogError("δ�ҵ���״̬");
            }
        }
        protected virtual void RemoveState<T>() where T : IState, new()
        {
            if (allState.TryGetValue(typeof(T), out IState t))
            {
                allState.Remove(typeof(T));
                return;
            }
            Debug.LogError("δ�ҵ���״̬");
        }
    }
}
