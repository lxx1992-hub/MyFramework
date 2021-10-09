using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ״̬�ӿ���
/// </summary>
namespace MyFramework
{
    public interface IState
    {
        void Init();
        void OnEnter();
        void OnExecute();
        void OnExit();
    }
}
