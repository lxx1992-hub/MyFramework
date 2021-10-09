using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����״̬�������л�
/// </summary>
namespace MyFramework
{
    public class SceneState : IState
    {
        protected string sceneAssetsPath;
        public virtual void Init()
        {
            Game.Resource.LoadBundle(this.sceneAssetsPath, null, null);
        }

        public virtual  void OnEnter()
        {
          
        }

        public virtual  void OnExecute()
        {
           
        }

        public virtual void OnExit()
        {
            Resources.UnloadUnusedAssets();
            Resources.UnloadAsset(null);
        }
    }
}
