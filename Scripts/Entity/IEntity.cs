using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public interface IEntity 
    {
        public int ID { get; set; }
        public EntityHelper helper { get;  }
        void Init();
    }
}
