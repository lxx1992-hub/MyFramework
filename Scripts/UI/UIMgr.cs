using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class UIMgr : Singleton<UIMgr>
    {
        Dictionary<string, GameObject> allUI = new Dictionary<string, GameObject>();
        EntityFactory factory = new EntityFactory();
        public GameObject CreatUI<T>(string UIname)where T:MonoBehaviour
        {
            GameObject go=factory.CreatEntity<T>(UIname);
            go.transform.parent = GameObject.Find("UIRoot").transform;
            allUI.Add(go.name, go);
            return go;
        }
        public void OpenUI(string name)
        {
            GameObject ui;
            if(allUI.TryGetValue(name,out ui))
            {
                ui.SetActive(true);
                return;
            }
            Debug.LogError("UI不存在");
        }
        public void CloseUI(string name)
        {
            GameObject ui;
            if (allUI.TryGetValue(name, out ui))
            {
                ui.SetActive(false);
                return;
            }
            Debug.LogError("UI不存在");
        }
        public void CloseAllUI()
        {
            foreach (var ui in allUI.Values)
            {
                ui.SetActive(false);
            }
        }
        public void Clear()
        {
            allUI.Clear();
        }
    }
}
