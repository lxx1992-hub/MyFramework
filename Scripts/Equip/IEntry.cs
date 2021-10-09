using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public enum EntryType
    {
        property,
        effect,
    }
    public interface IEntry
    {
        public int ID { get; set; }
        public string showName { get; set; }
        public EntryType type { get; set; }
        public float value { get; set; }
    }
}
