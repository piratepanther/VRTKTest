using System.Collections.Generic;


namespace Assets.Script.FSM2
{
    class AIConfigurationReaderFactory
    {
        private static Dictionary<string, AIConfigurationReader> cache;

        static AIConfigurationReaderFactory()
        {
            cache=new Dictionary<string, AIConfigurationReader>();
        }


        public static Dictionary<string, Dictionary<string, string>> GetMap(string fileName)
        {
            if (cache.ContainsKey(fileName))
            {
                cache.Add(fileName, new AIConfigurationReader(fileName));
            }


            return cache[fileName].map;

        }

    }
}
