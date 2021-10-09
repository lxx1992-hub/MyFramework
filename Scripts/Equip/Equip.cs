using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public enum EquipType
    {
        weapon,
        armor,

    }
    public class Equip : Item
    {       
        public List<IEntry> entries = new List<IEntry>();
        public EquipType type;
        public int level;
    }

}
