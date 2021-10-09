using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyFramework
{
    public class EditorLoad 
    {
        public static Object Load(string path)
        {
            string fullPath = "Assets/" + path;
#if UNITY_EDITOR
            return AssetDatabase.LoadAssetAtPath<Object>(fullPath);
#endif
        }
        public static Object LoadResources(string path)
        {
#if UNITY_EDITOR
            return Resources.Load<Object>(path);
#endif
        }
    }
}
