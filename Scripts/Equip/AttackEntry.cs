using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public struct AttackEntry :IEntry
    {
        public int ID { get; set; } 
        public string showName { get; set; }
        public EntryType type { get; set; }
        public float value { get; set; }
        public AttackEntry(int ID,string showName,EntryType type,float value)
        {
            this.ID = ID;
            this.showName = showName;
            this.type = type;
            this.value = value;
        }
    }
}
