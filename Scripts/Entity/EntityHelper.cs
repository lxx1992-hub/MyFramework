using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 实体辅助类，处理实体相关的逻辑
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
