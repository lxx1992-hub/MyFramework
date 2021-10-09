using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// ���ܹ����ͷ�
/// </summary>
namespace MyFramework
{
    public class SkillMgr : Singleton<SkillMgr>
    {
        Dictionary<int, GameObject> skills = new Dictionary<int, GameObject>();
        public  GameObject CreatSkill<T>(string skillName, params IEffect[] effect) where T : Skill
        {
            GameObject obj= SkillFactory.CreatSkill<T>(skillName, effect);
            skills.Add(obj.GetComponent<T>().ID, obj);
            return obj;
        }
        public void ReleaseSkill<T>(int ID)where T:Skill
        {
            if (skills.TryGetValue(ID, out GameObject skill))
            {
                GameObject obj = Game.Pool.TakeGameObject<T>(skill.name);
                obj.GetComponent<T>().Release();
            }
            else Debug.Log("δ�ҵ��ü���");
        }
        public void DestroySkill(GameObject obj)
        {
            Game.Pool.RecycleGameObject(obj);
        }
    }
}
