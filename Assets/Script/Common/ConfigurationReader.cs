using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Common
{
    public class ConfigurationReader
    {




        public static string GetConfigFile(string fileName)
        {
            string url;
            //string url = "file://"+Application.streamingAssetsPath + "/"+fileName;
            //如果在编译器下。。。
            //Application.platform==RuntimePlatform.WindowsEditor
            //unity 宏标签

            #region 分平台判断streamingAssets路径
#if UNITY_EDITOR || UNITY_STANDALONE
            url = "file://" + Application.dataPath + "/streamingAssets/" + fileName;
            //若果在PC下。。。              


            //若果在IOS平台下。。。
#elif UNITY_IPHONE
            url = "file://"+Application.dataPath + "/Raw/"+fileName;
            //如果在andriod下。。。
#elif UNITY_ANDROID
            url = "jar:file://"+Application.dataPath + "!/assets/"+fileName;
#endif
            #endregion

            //手机端只能用WWW 否则需要手机端SDK
            WWW www = new WWW(url);
            while (true)
            {
                if (www.isDone)
                    return www.text;
            }

        }

        public static void Reader(string fileContent,Action<string> handler)
        {

            using (StringReader reader = new StringReader(fileContent))
            {
                //字符串读取器，流读取，逐行读取
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    handler(line);


                }
                //using 自动调用 reader.Dispose();
            }
        }

    }
}
