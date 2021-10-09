using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class Skill : MonoBehaviour,ISkill
    {
        public int ID { get; set; }
        protected SkillData data = new SkillData();
        protected List<GameObject> allEnemy = new List<GameObject>();
        protected List<IEffect> effects = new List<IEffect>();
        protected virtual void Awake()
        {
            SearchEnemy();
            Release();
        }
        public virtual void SearchEnemy()
        {

        }
        public virtual void AddEffect(IEffect effect)
        {
            effects.Add(effect);
        }
        public virtual void Release()
        {
            foreach (var enemy in allEnemy)
            {
                foreach (var effect in effects)
                {
                    effect.Execute(enemy);
                }
            }
        }

    }
}
