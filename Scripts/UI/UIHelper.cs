using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class UIHelper
    {
        public UI parent { get; private set; }
        public UIHelper(UI parent)
        {
            this.parent = parent;
        }

    }
}
