using System.Collections.Generic;
using Assets.Script.Common;

namespace Assets.Script.FSM2
{
    class AIConfigurationReader
    {
        //数据结构：
        //大字典key状态      value映射
        //小字典key条件编号  value状态编号
        public Dictionary<string,Dictionary<string,string>> map{get;private set;}

        public AIConfigurationReader(string fileName)
        {
            map=new Dictionary<string,Dictionary<string,string>>();
        //读配置文件
            string configFile = ConfigurationReader.GetConfigFile(fileName);

            ConfigurationReader.Reader(configFile, BuildMap);

        //解析配置文件



        }

        private string mainKey;
        private void BuildMap(string line)
        {
            line = line.Trim();
            //1. if (line == ""||line == null) return;
            if (string.IsNullOrEmpty(line)) return;
            if (line.StartsWith("["))
            {
                //2.状态[Idle]
                mainKey = line.Substring(1,line.Length-2);


                map.Add(mainKey, new Dictionary<string, string>());
            }
            else
            {
                //3.映射NoHealth>Dead
                string[] keyValue = line.Split('>');
                map[mainKey].Add(keyValue[0], keyValue[1]);

            }

            
            //map.add
        }



        




    }
}
