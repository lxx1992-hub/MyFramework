using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ʵ�帨���࣬����ʵ����ص��߼�
/// </summary>
namespace MyFramework
{
    public abstract class EntityHelper
    {
        protected Data data;
        protected IEntity parent;
        public  EntityHelper(IEntity parent)
        {

        }
    }
}
