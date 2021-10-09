using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class EquipFactory
    {
        public static GameObject CreatEquip<T>(string imageName,params IEntry[] entry)where T:Equip
        {
            GameObject obj= GameObject.Instantiate(Game.Resource.LoadFromEditor(imageName)) as GameObject;
            List<IEntry> entries= obj.AddComponent<T>().entries;
            for (int i = 0; i < entry.Length; i++)
            {
                entries.Add(entry[i]);
            }
            return obj;
        }
    }
}
