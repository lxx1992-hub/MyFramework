using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace MyFramework
{
    public class DownloadAssets : UnitySingleton<DownloadAssets>
    {
        string loadPath;
        private void Awake()
        {
            loadPath = Resources.Load<TextAsset>("AssetsDownloadPath").text;
        }
        public void StartDownLoad(ICommand callBack)
        {
            StartCoroutine(Down(callBack));
        }
        public void StartLoadBundle(string path, string name, ICommand callBack)
        {
            StartCoroutine(LoadBundle(path, name, callBack));
        }
        IEnumerator Down(ICommand callBack)
        {
            Game.Event.Register(EventType.DownLoadEvent, callBack);
            UnityWebRequest www = new UnityWebRequest(loadPath);
            www.SendWebRequest();
            while (!www.isDone) yield return null;
            if (www.isDone)
            {
                AssetBundle asset = DownloadHandlerAssetBundle.GetContent(www);
                Game.Event.Trigger(EventType.DownLoadEvent, asset);
            }
        }
        IEnumerator LoadBundle(string path, string name, ICommand callBack)
        {
            Game.Event.Register(EventType.DownLoadEvent, callBack);
            UnityWebRequest www = new UnityWebRequest(path);
            www.SendWebRequest();
            while (!www.isDone) yield return null;
            if (www.isDone)
            {
                AssetBundle asset = DownloadHandlerAssetBundle.GetContent(www);
                Object obj = asset.LoadAsset<Object>(name);
                Game.Event.Trigger(EventType.LoadBundleEvent, obj);
            }
        }
    }
}
