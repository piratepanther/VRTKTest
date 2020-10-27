using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class GenerateResScript :Editor
{
    [MenuItem("Tools/Resources/Generate ResConfig File")]
    public static void Generate()
    {
        //Debug.Log("ok");
        //生成资源配置文件
        //1.查找Resources 目录下的所有预制件完整路径
        string[] resFiles = AssetDatabase.FindAssets("t:prefab",new string[]{"Assets/Resources"});
        //GUID
        for (int i = 0; i < resFiles.Length; i++)
        {
            resFiles[i] = AssetDatabase.GUIDToAssetPath(resFiles[i]);
            //resFiles[i].LastIndexOf('/')
            //2.生成对应关系
            // 名称=路径
            string fileName = Path.GetFileNameWithoutExtension(resFiles[i]);
            string filePath = resFiles[i].Replace("Assets/Resources/", string.Empty).Replace(".prefab", string.Empty);
            resFiles[i]=fileName+"="+filePath;
        }
        // 3.写入文件,StreamingAssets兼容所有平台只能读
        File.WriteAllLines("Assets/StreamingAssets/ConfigMap.txt", resFiles);
        //自动刷新
        //AssetDatabase.Refresh();
        //Application.persistentDataPath 可以读写



    }
    


}
