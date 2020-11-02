using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Common
{
    public class ResourcesManager
    {
        private static Dictionary<string, string> configMap;
        //string fileName = "ConfigMap.txt";
        private ResourcesManager(string fileName="ConfigMap.txt")
        //static ResourcesManager()
        {
            configMap=new Dictionary<string,string>();
            string fileContent = ConfigurationReader.GetConfigFile(fileName);
            //BuildMap(fileContent);
            ConfigurationReader.Reader(fileContent, BuildMap);
        }

        private void BuildMap(string line)
        {

            string[] keyValue = line.Split('=');
            //keyValue[0] keyValue[1] wenjianming    he  lujing
            configMap.Add(keyValue[0], keyValue[1]);
            //line = reader.ReadLine();


        }


//         private static string GetConfigFile(string fileName)
//         {
//             string url;
//             //string url = "file://"+Application.streamingAssetsPath + "/"+fileName;
//             //如果在编译器下。。。
//             //Application.platform==RuntimePlatform.WindowsEditor
//             //unity 宏标签
// 
//             #region 分平台判断streamingAssets路径
// #if UNITY_EDITOR || UNITY_STANDALONE
//             url = "file://" + Application.dataPath + "/streamingAssets/" + fileName;
//             //若果在PC下。。。              
//          
//             
//             //若果在IOS平台下。。。
// #elif UNITY_IPHONE
//             url = "file://"+Application.dataPath + "/Raw/"+fileName;
//             //如果在andriod下。。。
// #elif UNITY_ANDROID
//             url = "jar:file://"+Application.dataPath + "!/assets/"+fileName;
// #endif
//             #endregion
// 
//             //手机端只能用WWW 否则需要手机端SDK
//             WWW www=new WWW(url);
//             while (true)
//             {
//                 if (www.isDone)
//                     return www.text;
//             }
// 
//         }


//         private static void BuildMap(string fileContent)
//         {
//             configMap = new Dictionary<string, string>();
//             //解析fileContent 转换为dictionary
//             //fileContent.Split()
//             using(StringReader reader=new StringReader(fileContent))
//             {
//                 //字符串读取器，流读取，逐行读取
//                 string line;
//                 while((line = reader.ReadLine())!=null)
//                 {
//                     string[] keyValue = line.Split('=');
//                     //keyValue[0] keyValue[1] wenjianming    he  lujing
//                     configMap.Add(keyValue[0],keyValue[1]);
//                     //line = reader.ReadLine();
//                 }
//                 //using 自动调用 reader.Dispose();
//             }
//         }

        public static T Load<T>(string prefabName) where T:UnityEngine.Object
        {
            //prefabName=>prefabPath
            string prefabPath = configMap[prefabName];

            return Resources.Load<T>("prefabPath");
        }

    }
}
