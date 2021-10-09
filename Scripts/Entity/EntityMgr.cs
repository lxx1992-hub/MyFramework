using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class EntityMgr : Singleton<EntityMgr>
    {
        EntityFactory factory = new EntityFactory();
        public GameObject CreatEntity<T>(string entityName) where T : MonoBehaviour
        {
           return factory.CreatEntity<T>(entityName);
        }
        public void Destroy(GameObject obj)
        {

        }
    }
}
