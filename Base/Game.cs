using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 总管理类，游戏入口
/// </summary>
namespace MyFramework
{
    public class Game : UnitySingleton<Game>
    {
        public static EventMgr Event;
        public static PoolMgr Pool;
        public static ResourceMgr Resource;
        public static SkillMgr Skill;
        public static UIMgr UI;
        public static EntityMgr Entity;
        public static DataProxy dataProxy;
        public static EquipMgr Equip;
        public static DBMgr DB;
        public static bool isLoadFromEditor = true;
        protected override void Awake()
        {
            base.Awake();
            Event = EventMgr.Instance;
            Pool = PoolMgr.Instance;
            Resource = ResourceMgr.Instance;
            Skill = SkillMgr.Instance;
            UI = UIMgr.Instance;
            Entity = EntityMgr.Instance;
            dataProxy = DataProxy.Instance;
            Equip = EquipMgr.Instance;
            DB = DBMgr.Instance;
            Init();
        }
        void Init()
        {
            dataProxy.Init();
            DB.Init();
            new IOCcontainer().InitInjector();
        }

    }
}
