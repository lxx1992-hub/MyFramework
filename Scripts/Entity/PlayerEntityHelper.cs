using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class PlayerEntityHelper : EntityHelper
    {
        public PlayerEntityHelper(IEntity parent):base(parent)
        {
            this.parent = parent;
            data = new PlayerData();
        }
    }
}
