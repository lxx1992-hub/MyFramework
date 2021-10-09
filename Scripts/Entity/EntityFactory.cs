using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class EntityFactory 
    {
       public GameObject CreatEntity<T>(string entityName)where T:MonoBehaviour
        {
            GameObject go= Game.Resource.LoadFromEditor(entityName) as GameObject;
            GameObject entity= GameObject.Instantiate(go);
            entity.name = entityName;
            return entity.AddComponent<T>().gameObject;
        }
    }
}
