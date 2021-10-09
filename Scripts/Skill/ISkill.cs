using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public interface ISkill
    {
        public int ID { get; set; }
        void SearchEnemy();
        void AddEffect(IEffect effect);
        void Release();
    }
}
