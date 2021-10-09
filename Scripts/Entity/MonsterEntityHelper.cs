using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class MonsterEntityHelper : EntityHelper
    {
        public MonsterEntityHelper(IEntity parent):base(parent)
        {
            this.parent = parent;
            
        }
    }
}
