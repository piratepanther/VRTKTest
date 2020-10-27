using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    namespace common
{
	public class GameObjectPool : MonoSingleton<GameObjectPool>
	{
        private Dictionary<string,List<GameObject>> cache;

        public override void Init()
        {
            base.Init();
            cache = new Dictionary<string,List<GameObject>>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefab"></param>
        /// <param name="pos"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotate)
        {
            GameObject go = null;
            if(cache.ContainsKey(key))
            {
                go = cache[key].Find(g => !g.activeInHierarchy);
            }
            if(go == null)
            {
                go = Instantiate(prefab);
                if(cache.ContainsKey(key))
                {
                    cache[key].Add(go);
                }
                else
                {
                    cache.Add(key,new List<GameObject>());
                    cache[key].Add(go);
                }

            }
            //使用
            go.transform.position = pos;
            go.transform.rotation = rotate;
            go.SetActive(true);
            return go;
        }

        public void CollectObject(GameObject go,float delay=0)
        {
            StartCoroutine(CollectObjectDelay(go, delay));
        }


        private IEnumerator CollectObjectDelay(GameObject go, float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }
        /// <summary>
        /// 清空某个类别
        /// </summary>
        /// <param name="key"></param>
        public void Clear(string key)
        {
            //Destroy 对象
            //类别
        }
        /// <summary>
        /// 清空全部
        /// </summary>
        public void ClearAll()
        {
            
        }

	}
}
