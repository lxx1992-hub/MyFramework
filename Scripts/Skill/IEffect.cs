using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public enum EffectType
    {
        damage,
        debuff,
        control,
    }
    public interface IEffect
    {
        public int Id { get; set; }
        public EffectType type { get; set; }
        public float value { get; set; }
        void Execute(GameObject obj);
    }
  
}
