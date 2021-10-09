using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ¿ªÊ¼³¡¾°£¬×´Ì¬
/// </summary>
namespace MyFramework
{
    public class StartSceneState : SceneState
    {
        public override void Init()
        {
            base.Init();
            GameObject entry= GameObject.Find("GameEntry");
            entry.AddComponent<Game>();
            entry.AddComponent<DownloadAssets>();
        }

    }
}
