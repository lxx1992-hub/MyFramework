using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class MonsterEntity : MonoBehaviour,IEntity
    {
        public int ID { get; set; }
        public EntityHelper helper { get; private set; }
        protected virtual void Start()
        {
            helper = new MonsterEntityHelper(this);
        }
        protected virtual void Update()
        {
            
        }
        public virtual void Init()
        {

        }
    }
}
