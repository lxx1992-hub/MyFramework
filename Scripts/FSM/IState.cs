using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ×´Ì¬½Ó¿ÚÀà
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
