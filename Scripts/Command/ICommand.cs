using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 命令接口，统一所有命令
/// </summary>
namespace MyFramework
{
    public interface ICommand
    {
        void Execute();
        void Execute(Object obj);
    }
}
