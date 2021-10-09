using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public interface UI
    {
        public int ID { get ; set; }

        public UIHelper helper { get; }

        void Init();
    }
}
