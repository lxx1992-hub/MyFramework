using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class SkillFactory 
    {
        public static GameObject CreatSkill<T>(string skillName,params IEffect[] effect)where T:Skill
        {
            GameObject obj = GameObject.Instantiate(Game.Resource.LoadFromEditor(skillName)) as GameObject;
            T t= obj.AddComponent<T>();
            foreach (var item in effect)
            {
                t.AddEffect(item);
            }
            return obj;
        }
     
    }
}
