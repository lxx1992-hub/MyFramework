using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class ResourceMgr : Singleton<ResourceMgr>
    {
        GameObject obj;
        public GameObject Load(string name)
        {
            if(Game.isLoadFromEditor)
             return Resources.Load<GameObject>(name);
            else
            {
                return obj;
            }
             
        }
        public Object LoadFromEditor(string path,bool isFromResources=true)
        {
            if (isFromResources)
            {
               return EditorLoad.LoadResources(path);
            }
            else
            {
                return EditorLoad.Load(path);
            }
        }
        public void DownLoadFromWeb(ICommand callBack)
        {
            DownloadAssets.Instance.StartDownLoad(callBack);
        }
        public void LoadBundle(string path,string name,ICommand callback)
        {
            DownloadAssets.Instance.StartLoadBundle(path, name, callback);
        }
     
    }
}
