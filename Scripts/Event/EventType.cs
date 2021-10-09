using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 事件类型，与命令一一对应
/// </summary>
namespace MyFramework
{
    public enum EventType
    {
        DataUpdateEvent,
        LoginEvent,
        DownLoadEvent,
        LoadBundleEvent,
    }
}
