using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏整体流程
/// </summary>
namespace MyFramework
{
    public class Procedure : FSM
    {
        protected override void Awake()
        {
            base.Awake();
            allState.Add(typeof(StartSceneState), new StartSceneState());
            current = allState[typeof(StartSceneState)];
            Init();
        }
        protected override void Init()
        {
            foreach (var state in allState.Values)
            {
                state.Init();
            }
        }
    }
}
