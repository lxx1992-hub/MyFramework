using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyFramework
{
    public class AssetsBundle : Editor
    {
        [MenuItem("MyFramework/BuildAll")]
        static void Build()
        {
            BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
