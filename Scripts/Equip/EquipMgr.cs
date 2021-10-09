using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class EquipMgr : UnitySingleton<EquipMgr>
    {
        Dictionary<int, GameObject> equips = new Dictionary<int, GameObject>();
        public GameObject CreatEquip<T>(string imageName, params IEntry[] entry) where T : Equip
        {
            GameObject obj = EquipFactory.CreatEquip<T>(imageName, entry);
            int ID = obj.GetComponent<T>().ID;
            equips.Add(ID, obj);
            return obj;
        }
        public void DestroyEquip(int ID)
        {
            if (equips.TryGetValue(ID, out GameObject obj))
            {
                GameObject.Destroy(obj);
                equips.Remove(ID);
            }
            else Debug.LogError("装备不存在");
        }
    }
}
